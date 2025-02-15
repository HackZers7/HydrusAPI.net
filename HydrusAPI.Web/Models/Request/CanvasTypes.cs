namespace HydrusAPI.Web;

/// <summary>
///     Тип вьювера.
/// </summary>
public enum CanvasTypes
{
	/// <summary>
	///     Media Viewer (the normal viewer in hydrus that is its own window)
	/// </summary>
	Media = 0,

	/// <summary>
	///     Preview Viewer (the box in the bottom-left corner of the Main GUI window)
	/// </summary>
	Preview = 1,

	/// <summary>
	///     Client API Viewer (something to represent your own access, if you wish)
	/// </summary>
	ClientApi = 4
}
