namespace HydrusAPI.Web;

/// <summary>
///     Тип сортировки.
/// </summary>
public enum SortingType
{
	/// <summary>
	///     File size (smallest first/largest first).
	/// </summary>
	FileSize = 0,

	/// <summary>
	///     Duration (shortest first/longest first).
	/// </summary>
	Duration = 1,

	/// <summary>
	///     Import time (oldest first/newest first).
	/// </summary>
	ImportTime = 2,

	/// <summary>
	///     File type (N/A).
	/// </summary>
	FileType = 3,

	/// <summary>
	///     Random (N/A).
	/// </summary>
	Random = 4,

	/// <summary>
	///     Width (slimmest first/widest first).
	/// </summary>
	Width = 5,

	/// <summary>
	///     Height (shortest first/tallest first).
	/// </summary>
	Height = 6,

	/// <summary>
	///     Ratio (tallest first/widest first).
	/// </summary>
	Ratio = 7,

	/// <summary>
	///     Number of pixels (ascending/descending).
	/// </summary>
	NumberOfPixels = 8,

	/// <summary>
	///     Number of tags (on the current tag domain) (ascending/descending).
	/// </summary>
	NumberOfTags = 9,

	/// <summary>
	///     Number of media views (ascending/descending).
	/// </summary>
	NumberOfMediaViews = 10,

	/// <summary>
	///     Total media view time (ascending/descending).
	/// </summary>
	TotalMediaViewTime = 11,

	/// <summary>
	///     Approximate bitrate (smallest first/largest first).
	/// </summary>
	ApproximateBitrate = 12,

	/// <summary>
	///     Has audio (audio first/silent first).
	/// </summary>
	HasAudio = 13,

	/// <summary>
	///     Modified time (oldest first/newest first).
	/// </summary>
	ModifiedTime = 14,

	/// <summary>
	///     Framerate (slowest first/fastest first).
	/// </summary>
	Framerate = 15,

	/// <summary>
	///     Number of frames (smallest first/largest first).
	/// </summary>
	NumberOfFrames = 16,

	/// <summary>
	///     Last viewed time (oldest first/newest first).
	/// </summary>
	LastViewedTime = 18,

	/// <summary>
	///     Archive timestamp (oldest first/newest first).
	/// </summary>
	ArchiveTimestamp = 19,

	/// <summary>
	///     Hash hex (lexicographic/reverse lexicographic).
	/// </summary>
	HashHex = 20,

	/// <summary>
	///     Pixel hash hex (lexicographic/reverse lexicographic).
	/// </summary>
	PixelHashHex = 21,

	/// <summary>
	///     BlurHash (lexicographic/reverse lexicographic).
	/// </summary>
	BlurHash = 22
}
