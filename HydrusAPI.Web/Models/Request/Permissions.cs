namespace HydrusAPI.Web;

/// <summary>
///     Ключи, указывающие какие разрешения доступны.
/// </summary>
public enum Permissions
{
	/// <summary>
	///     Import and Edit URLs
	/// </summary>
	ImportEditUrls = 0,

	/// <summary>
	///     Import and Delete Files
	/// </summary>
	ImportDeleteFiles = 1,

	/// <summary>
	///     Edit File Tags
	/// </summary>
	EditFileTags = 2,

	/// <summary>
	///     Search for and Fetch Files
	/// </summary>
	SearchFetchFiles = 3,

	/// <summary>
	///     Manage Pages
	/// </summary>
	ManagePages = 4,

	/// <summary>
	///     Manage Cookies and Headers
	/// </summary>
	ManageCookiesHeaders = 5,

	/// <summary>
	///     Manage Database
	/// </summary>
	ManageDatabase = 6,

	/// <summary>
	///     Edit File Notes
	/// </summary>
	EditFileNotes = 7,

	/// <summary>
	///     Edit File Relationships
	/// </summary>
	EditFileRelationships = 8,

	/// <summary>
	///     Edit File Ratings
	/// </summary>
	EditFileRatings = 9,

	/// <summary>
	///     Manage Popups
	/// </summary>
	ManagePopups = 10,

	/// <summary>
	///     Edit File Times
	/// </summary>
	EditFileTimes = 11,

	/// <summary>
	///     Commit Pending
	/// </summary>
	CommitPending = 12,

	/// <summary>
	///     See Local Paths
	/// </summary>
	SeeLocalPaths = 13
}
