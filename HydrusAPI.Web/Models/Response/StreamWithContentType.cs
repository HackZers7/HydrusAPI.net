namespace HydrusAPI.Web;

/// <inheritdoc/>
public class StreamWithContentType : Stream
{
	private Stream _input;

	/// <inheritdoc/>
	public override bool CanRead => _input.CanRead;

	/// <inheritdoc/>
	public override bool CanSeek => _input.CanSeek;

	/// <inheritdoc/>
	public override bool CanWrite => _input.CanWrite;

	/// <inheritdoc/>
	public override long Length => _input.Length;

	/// <inheritdoc/>
	public override long Position { get => _input.Position; set => _input.Position = value; }

	/// <summary>
	/// 	Тип медиа контента в потоке.
	/// </summary>
	public string ContentType { get; }

	/// <inheritdoc/>
	public StreamWithContentType(Stream stream, string contentType)
	{
		ThrowHelper.ArgumentNotNull(stream);
		ThrowHelper.ArgumentNotNullOrWhiteSpace(contentType);

		_input = stream;
		ContentType = contentType;
	}

	/// <inheritdoc/>
	public override void Flush()
	{
		_input.Flush();
	}

	/// <inheritdoc/>
	public override int Read(byte[] buffer, int offset, int count)
	{
		return _input.Read(buffer, offset, count);
	}

	/// <inheritdoc/>
	public override long Seek(long offset, SeekOrigin origin)
	{
		return _input.Seek(offset, origin);
	}

	/// <inheritdoc/>
	public override void SetLength(long value)
	{
		_input.SetLength(value);
	}

	/// <inheritdoc/>
	public override void Write(byte[] buffer, int offset, int count)
	{
		_input.Write(buffer, offset, count);
	}

	/// <inheritdoc/>
	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			_input.Dispose();
		}
		base.Dispose(disposing);
	}
}
