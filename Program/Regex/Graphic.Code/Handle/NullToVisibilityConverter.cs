using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Occhitta.Example.Handle;

/// <summary>
/// NULL表示変換クラスです。
/// </summary>
internal sealed class NullToVisibilityConverter : IValueConverter {
	#region 内部メソッド定義(IsReverse)
	/// <summary>
	/// 反転するか判定します。
	/// </summary>
	/// <param name="optionData">判定情報</param>
	/// <returns>反転する場合、<c>True</c>を返却</returns>
	private static bool IsReverse(string? optionData) => optionData == "1"
		|| String.Equals(optionData, "True", StringComparison.OrdinalIgnoreCase)
		|| String.Equals(optionData, "Yes",  StringComparison.OrdinalIgnoreCase)
		|| String.Equals(optionData, "On",   StringComparison.OrdinalIgnoreCase);
	/// <summary>
	/// 反転するか判定します。
	/// </summary>
	/// <param name="optionData">判定情報</param>
	/// <returns>反転する場合、<c>True</c>を返却</returns>
	private static bool IsReverse(object? optionData) =>
		IsReverse(optionData?.ToString());
	#endregion 内部メソッド定義(IsReverse)

	#region 実装メソッド定義
	/// <summary>
	/// 正変換を行います。
	/// </summary>
	/// <param name="sourceData">判定情報</param>
	/// <param name="outputCode">出力種別</param>
	/// <param name="optionData">引数情報</param>
	/// <param name="localeData">地域情報</param>
	/// <returns>変換情報</returns>
	public object Convert(object? sourceData, Type outputCode, object? optionData, CultureInfo localeData) {
		if (IsReverse(optionData)) {
			return sourceData == null? Visibility.Visible: Visibility.Collapsed;
		} else {
			return sourceData == null? Visibility.Collapsed: Visibility.Visible;
		}
	}
	/// <summary>
	/// 逆変換を行います。
	/// </summary>
	/// <param name="sourceData">判定情報</param>
	/// <param name="outputCode">出力種別</param>
	/// <param name="optionData">引数情報</param>
	/// <param name="localeData">地域情報</param>
	/// <returns>変換情報</returns>
	public object ConvertBack(object sourceData, Type outputCode, object optionData, CultureInfo localeData) =>
		throw new InvalidOperationException();
	#endregion 実装メソッド定義
}
