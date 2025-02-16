namespace HydrusAPI.Web;

/// <summary>
///     Представляет клиент для работы со связями файлов.
/// </summary>
public interface IRelationshipsClient
{
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
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает коллекцию хэшей (SHA256).</returns>
	Task<List<string>> GetRandomPotentials(GetPotentialsRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemovePotentials(string hash, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemovePotentials(params string[] hashes);

	/// <summary>
	///     Удаляет потенциальные дубликаты..
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemovePotentials(ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemovePotentials(params ulong[] ids);

	/// <summary>
	///     Удаляет потенциальные дубликаты.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> RemovePotentials(FilesRequest request, CancellationToken cancel = default);

	/// <summary>
	///     Добавляет связь между файлами.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Коллекция со связями.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetFileRelationships(IEnumerable<Relationships> request, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hash">Хэш (SHA256) файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetKings(string hash, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="hashes">Хэши (SHA256) файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetKings(params string[] hashes);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="fileId">Идентификатор файл.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetKings(ulong fileId, CancellationToken cancel = default);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="ids">Идентификаторы файлов.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetKings(params ulong[] ids);

	/// <summary>
	///     Устанавливает лучшего "короля" родителя.
	/// </summary>
	/// <remarks>
	///     Требуется аутентификация. Для отправки требуется область видимости (разрешение):
	///     <see cref="Permissions.EditFileRelationships" />.
	/// </remarks>
	/// <param name="request">Запрос.</param>
	/// <param name="cancel">Токен отмены запроса.</param>
	/// <returns>Возвращает метку был ли успешно отправлен запрос.</returns>
	Task<bool> SetKings(FilesRequest request, CancellationToken cancel = default);
}
