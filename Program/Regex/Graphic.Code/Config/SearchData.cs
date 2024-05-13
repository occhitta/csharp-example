using System;
using System.Text.RegularExpressions;
using Occhitta.Libraries.Common;

namespace Occhitta.Example.Config;

/// <summary>
/// 検索設定情報クラスです。
/// </summary>
internal sealed class SearchData {
	#region プロパティー定義
	/// <summary>
	/// 選択名称を取得します。
	/// </summary>
	/// <value>選択名称</value>
	public string SelectName {
		get;
	}
	/// <summary>
	/// 解析書式を取得します。
	/// </summary>
	/// <value>解析書式</value>
	public string FormatText {
		get;
	}
	/// <summary>
	/// 解析種別を取得します。
	/// </summary>
	/// <value>解析種別</value>
	public RegexOptions OptionData {
		get;
	}
	/// <summary>
	/// 解析内容を取得します。
	/// </summary>
	/// <value>解析内容</value>
	public string? SourceText {
		get;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 検索設定情報を生成します。
	/// </summary>
	/// <param name="selectName">選択名称</param>
	/// <param name="formatText">解析書式</param>
	/// <param name="optionData">解析種別</param>
	/// <param name="sourceText">解析内容</param>
	private SearchData(string selectName, string formatText, RegexOptions optionData, string? sourceText) {
		SelectName = selectName;
		FormatText = formatText;
		OptionData = optionData;
		SourceText = sourceText;
	}
	/// <summary>
	/// 検索設定情報を生成します。
	/// </summary>
	/// <param name="source">設定情報</param>
	/// <returns>検索設定情報</returns>
	public static SearchData Create(System.Xml.XmlNode source) {
		var selectName = source.GetText("name");
		var formatText = source.GetText("code");
		var optionData = source.GetText("mode", null);
		var sourceText = source.GetText();
		return new(selectName, formatText, ToOptionData(optionData), sourceText);
	}
	#endregion 生成メソッド定義

	#region 内部メソッド定義
	/// <summary>
	/// 解析種別へ変換します。
	/// </summary>
	/// <param name="source">設定情報</param>
	private static RegexOptions ToOptionData(string? source) {
		if (String.IsNullOrEmpty(source)) {
			return default;
		} else if (Enum.TryParse<RegexOptions>(source, out var result)) {
			return result;
		} else {
			return default;
		}
	}
	#endregion 内部メソッド定義
}
