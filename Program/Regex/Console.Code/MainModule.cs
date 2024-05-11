using System;
using System.Text;
using System.Text.RegularExpressions;
using static System.Environment;

namespace Occhitta.Example;

/// <summary>
/// 正規表現サンプルクラスです。
/// </summary>
internal static class MainModule {
	#region メンバー定数定義
	/// <summary>書式設定</summary>
	private const string FormatText = "[A-B](C|D)";
	/// <summary>内容設定</summary>
	private const string SourceText = "ABCDEF,ABDCEF";
	/// <summary>階層情報</summary>
	private const string IndentText = "  ";
	#endregion メンバー定数定義

	#region 内部メソッド定義(ToString)
	/// <summary>
	/// 引数情報を表現文字列へ変換します。
	/// </summary>
	/// <param name="source">引数情報</param>
	/// <returns>表現文字列</returns>
	private static string ToString(string source) {
		var result = source;
		result = result.Replace("\r", "\\r");
		result = result.Replace("\n", "\\n");
		result = result.Replace("\t", "\\t");
		result = result.Replace("\"", "\\\"");
		return $"\"{result}\"";
	}
	/// <summary>
	/// 引数情報を表現文字列へ変換します。
	/// </summary>
	/// <param name="source">引数情報</param>
	/// <returns>表現文字列</returns>
	private static string ToString(int source) =>
		source.ToString();
	/// <summary>
	/// 引数情報を表現文字列へ変換します。
	/// </summary>
	/// <param name="source">引数情報</param>
	/// <returns>表現文字列</returns>
	private static string ToString(bool source) =>
		source? "OK": "NG";
	#endregion 内部メソッド定義(ToString)

	#region 内部メソッド定義(CreateText)
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">出力情報</param>
	/// <param name="indent">階層情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(Capture source, string indent) {
		var result = new StringBuilder();
		result.AppendLine($"{indent}Index   = {ToString(source.Index)}");
		result.AppendLine($"{indent}Length  = {ToString(source.Length)}");
		result.AppendLine($"{indent}Value   = {ToString(source.Value)}");
		return result.ToString();
	}
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">出力情報</param>
	/// <param name="indent">階層情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(CaptureCollection source, string indent) {
		var result = new StringBuilder();
		if (source.Count <= 0) {
			result.AppendLine($"{indent}Capture = Empty");
		} else {
			for (var index = 0; index < source.Count; index ++) {
				result.AppendLine($"{indent}Capture[{index:00}]");
				result.Append(CreateText(source[index], indent + IndentText));
			}
		}
		return result.ToString();
	}
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">出力情報</param>
	/// <param name="indent">階層情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(Group source, string indent) {
		var result = new StringBuilder();
		result.AppendLine($"{indent}Success = {ToString(source.Success)}");
		result.AppendLine($"{indent}Index   = {ToString(source.Index)}");
		result.AppendLine($"{indent}Length  = {ToString(source.Length)}");
		result.AppendLine($"{indent}Name    = {ToString(source.Name)}");
		result.AppendLine($"{indent}Value   = {ToString(source.Value)}");
		result.Append(CreateText(source.Captures, indent));
		return result.ToString();
	}
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">出力情報</param>
	/// <param name="indent">階層情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(GroupCollection source, string indent) {
		var result = new StringBuilder();
		if (source.Count <= 0) {
			result.AppendLine($"{indent}Group   = Empty");
		} else {
			for (var index = 0; index < source.Count; index ++) {
				result.AppendLine($"{indent}Group[{index:00}]");
				result.Append(CreateText(source[index], indent + IndentText));
			}
		}
		return result.ToString();
	}
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">出力情報</param>
	/// <param name="indent">階層情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(Match source, string indent) {
		var result = new StringBuilder();
		result.Append($"{indent}Success = {ToString(source.Success)}{NewLine}");
		result.Append($"{indent}Index   = {ToString(source.Index)}{NewLine}");
		result.Append($"{indent}Length  = {ToString(source.Length)}{NewLine}");
		result.Append($"{indent}Name    = {ToString(source.Name)}{NewLine}");
		result.Append($"{indent}Value   = {ToString(source.Value)}{NewLine}");
		result.Append(CreateText(source.Groups, indent));
		result.Append(CreateText(source.Captures, indent));
		return result.ToString();
	}
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">出力情報</param>
	/// <param name="indent">階層情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(MatchCollection source, string indent) {
		var result = new StringBuilder();
		for (var index = 0; index < source.Count; index ++) {
			result.Append($"{indent}Match[{index:00}]{NewLine}{CreateText(source[index], indent + IndentText)}");
		}
		return result.ToString();
	}
	/// <summary>
	/// 出力情報を生成します。
	/// </summary>
	/// <param name="source">内容情報</param>
	/// <param name="format">書式情報</param>
	/// <returns>出力情報</returns>
	private static string CreateText(string source, string format) =>
		$"FormatText : {ToString(format)}{NewLine}SourceText : {ToString(source)}{NewLine}ResultData :{NewLine}{CreateText(Regex.Matches(source, format), IndentText)}";
	#endregion 内部メソッド定義(CreateText)

	#region 実行メソッド定義
	/// <summary>
	/// 正規表現サンプルを実行します。
	/// </summary>
	/// <param name="commands">コマンドライン引数</param>
	public static void Main(string[] commands) {
		Console.WriteLine(CreateText(SourceText, FormatText));
	}
	#endregion 実行メソッド定義
}
