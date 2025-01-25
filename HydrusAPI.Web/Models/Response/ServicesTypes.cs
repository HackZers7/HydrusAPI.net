namespace HydrusAPI.Web;

/// <summary>
///     Типы сервисов Hydrus.
/// </summary>
public enum ServicesTypes
{
	/// <summary>
	///     Tag repository
	/// </summary>
	TagRepository = 0,

	/// <summary>
	///     File repository
	/// </summary>
	FileRepository = 1,

	/// <summary>
	///     A local file domain like 'my files'
	/// </summary>
	LocalFileDomain = 2,

	/// <summary>
	///     A local tag domain like 'my tags'
	/// </summary>
	LocalTagDomain = 5,

	/// <summary>
	///     A 'numerical' rating service with several stars
	/// </summary>
	NumericRatingService = 6,

	/// <summary>
	///     a 'like/dislike' rating service with on/off status
	/// </summary>
	CheckRatingService = 7,

	/// <summary>
	///     All known tags -- a union of all the tag services
	/// </summary>
	AllKnownTags = 10,

	/// <summary>
	///     All known files -- a union of all the file services and files that appear in tag services
	/// </summary>
	AllKnownFiles = 11,

	/// <summary>
	///     The local booru -- you can ignore this
	/// </summary>
	LocalBooru = 12,

	/// <summary>
	///     IPFS
	/// </summary>
	IPFS = 13,

	/// <summary>
	///     Trash
	/// </summary>
	Trash = 14,

	/// <summary>
	///     All local files -- all files on hard disk ('all my files' + updates + trash)
	/// </summary>
	AllLocalFiles = 15,

	/// <summary>
	///     file notes
	/// </summary>
	FileNotes = 17,

	/// <summary>
	///     Client API
	/// </summary>
	ClientApi = 18,

	/// <summary>
	///     All deleted files -- you can ignore this
	/// </summary>
	AllDeletedFiles = 19,

	/// <summary>
	///     Local updates -- a file domain to store repository update files in
	/// </summary>
	LocalUpdates = 20,

	/// <summary>
	///     All my files -- union of all local file domains
	/// </summary>
	AllMyFiles = 21,

	/// <summary>
	///     A 'inc/dec' rating service with positive integer rating
	/// </summary>
	IntegerRatingService = 22,

	/// <summary>
	///     Server administration
	/// </summary>
	ServerAdministration = 99
}
