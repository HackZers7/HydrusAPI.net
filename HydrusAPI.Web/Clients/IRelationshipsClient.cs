namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы со связями файлов.
/// </summary>
public interface IRelationshipsClient
{
	/// <summary>
	///     Запрашивает связи файлов. Используется файловый домен по умолчанию - "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FileRelationshipsResponse" />.</returns>
	Task<FileRelationshipsResponse> GetFileRelationships(string hash, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает связи файлов. Используется файловый домен по умолчанию - "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FileRelationshipsResponse" />.</returns>
	Task<FileRelationshipsResponse> GetFileRelationships(IList<string> hashes, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает связи файлов. Используется файловый домен по умолчанию - "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файла.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FileRelationshipsResponse" />.</returns>
	Task<FileRelationshipsResponse> GetFileRelationships(ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает связи файлов. Используется файловый домен по умолчанию - "all my files".
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="fileIds">Идентификаторы файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FileRelationshipsResponse" />.</returns>
	Task<FileRelationshipsResponse> GetFileRelationships(IList<ulong> fileIds, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает связи файлов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="FileRelationshipsResponse" />.</returns>
	Task<FileRelationshipsResponse> GetFileRelationships(FilesWithDomainRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает потенциальное количества оставшихся пар дубликатов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает количество дубликатов.</returns>
	Task<int> GetPotentialsCount(CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает потенциальное количества оставшихся пар дубликатов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает количество дубликатов.</returns>
	Task<int> GetPotentialsCount(GetPotentialsRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает потенциальные оставшиеся пары дубликатов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="PotentialDuplicatePairsResponse" />.</returns>
	Task<PotentialDuplicatePairsResponse> GetPotentialsPairs(CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает потенциальные оставшиеся пары дубликатов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="PotentialDuplicatePairsResponse" />.</returns>
	Task<PotentialDuplicatePairsResponse> GetPotentialsPairs(GetPotentialsPairsRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает потенциальные оставшиеся пары дубликатов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию хешей (SHA256).</returns>
	Task<RandomPotentialDuplicateHashesResponse> GetRandomPotentials(CancellationToken cancel = default);

	/// <summary>
	///     Запрашивает потенциальные оставшиеся пары дубликатов.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию хешей (SHA256).</returns>
	Task<RandomPotentialDuplicateHashesResponse> GetRandomPotentials(GetPotentialsRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RemovePotentials(string hash, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RemovePotentials(IList<string> hashes, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты..
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RemovePotentials(ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RemovePotentials(IList<ulong> ids, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task RemovePotentials(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет связь между файлами.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Коллекция со связями.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileRelationships(IList<Relationships> request, CancellationToken cancel = default);

		/// <summary>
	///     Добавляет связь между файлами.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetFileRelationships(SetFileRelationshipsRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetKings(string hash, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hashes">Хеши (SHA256) файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetKings(IList<string> hashes, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetKings(ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetKings(IList<ulong> ids, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает <see cref="Task"/>.</returns>
	Task SetKings(FilesRequest request, CancellationToken cancel = default);
}
