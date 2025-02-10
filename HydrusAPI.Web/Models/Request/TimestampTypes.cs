namespace HydrusAPI.Web;

/// <summary>
///     Типы времени.
/// </summary>
public enum TimestampTypes
{
	/// <summary>
	///     File modified time (web domain)
	/// </summary>
	FileModifiedTimeWeb = 0,

	/// <summary>
	///     File modified time (on the hard drive)
	/// </summary>
	FileModifiedTimeDrive = 1,

	/// <summary>
	///     File import time
	/// </summary>
	FileImportTime = 3,

	/// <summary>
	///     File delete time
	/// </summary>
	FileDeleteTime = 4,

	/// <summary>
	///     Archived time
	/// </summary>
	ArchivedTime = 5,

	/// <summary>
	///     Last viewed (in the media viewer)
	/// </summary>
	LastViewed = 6,

	/// <summary>
	///     File originally imported time
	/// </summary>
	FileOriginallyImportedTime = 7
}
