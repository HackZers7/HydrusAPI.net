using System.Text.Json;

namespace HydrusAPI.Web.Converters;

/// <summary>
/// 	Кастомный конвертер.
/// </summary>
public interface IConvert
{
    /// <summary>
    /// 	Преобразует указанный объект в строку JSON.
    /// </summary>
    /// <param name="options">Настройки.</param>
    /// <returns>Преобразованный объект.</returns>
    string SerializeObject(JsonSerializerOptions options);
}
