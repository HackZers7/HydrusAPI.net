using System.Net;

namespace HydrusAPI.Web.Http;

/// <summary>
/// 	HTTP контент, который возвращает информацию о процессе передачи файла.
/// </summary>
public class ProgressStreamContent : HttpContent
{
	private const int defaultBufferSize = 4096;

	private HttpContent _content;
	private int _bufferSize;
	private IProgress<int>? _progressCallback;

	private bool _useProgress;

	/// <summary>
	/// 	Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="content">Поток для передачи.</param>
	/// <param name="progressCallback">Функция обратного вызова для отображения процесса отправки.</param>
	public ProgressStreamContent(HttpContent content, IProgress<int>? progressCallback)
		: this(content, progressCallback, defaultBufferSize)
	{
	}

	/// <summary>
	/// 	Инициализирует новый экземпляр класса.
	/// </summary>
	/// <param name="content">Поток для передачи.</param>
	/// <param name="progressCallback">Функция обратного вызова для отображения процесса отправки.</param>
	/// <param name="bufferSize">Размер буфера.</param>
	public ProgressStreamContent(HttpContent content, IProgress<int>? progressCallback, int bufferSize)
	{
		ThrowHelper.ArgumentNotNull(content);
		ThrowHelper.ArgumentNegativeOrZero(bufferSize);

		_content = content;
		_bufferSize = bufferSize;
		_progressCallback = progressCallback;
		_useProgress = progressCallback != null;
	}

	/// <inheritdoc/>
	protected override Task SerializeToStreamAsync(Stream stream, TransportContext? context)
	{
		return SerializeToStreamAsyncCore(stream, default);
	}

	private async Task SerializeToStreamAsyncCore(Stream stream, CancellationToken ct)
	{
		long position = 0;
		int oldProgress = -1;
		int bytesRead = 0;
		var buffer = new byte[_bufferSize];

		TryComputeLength(out var length);

		using (var input = await _content.ReadAsStreamAsync())
		{
			while ((bytesRead = await input.ReadAsync(buffer, 0, buffer.Length, ct)) > 0)
			{
				await stream.WriteAsync(buffer, 0, bytesRead, ct);

				position += bytesRead;
				int progress = (int)(position * 100 / length);

				if (_useProgress && progress != oldProgress)
				{
					oldProgress = progress;
					_progressCallback!.Report(progress);
				}

				stream.Flush();
			}
		}
		stream.Flush();
	}

	/// <inheritdoc/>
	protected override bool TryComputeLength(out long length)
	{
		length = _content.Headers.ContentLength.GetValueOrDefault();
		return true;
	}

	/// <inheritdoc/>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_content.Dispose();
		}
		base.Dispose(disposing);
	}
}
