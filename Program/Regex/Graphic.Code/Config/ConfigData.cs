using System.Xml;
using Occhitta.Libraries.Common;

namespace Occhitta.Example.Config;

/// <summary>
/// 基本設定情報クラスです。
/// </summary>
internal sealed class ConfigData {
	#region メンバー変数定義
	/// <summary>
	/// 読込位置
	/// </summary>
	private static string sourceFile = "Template.xml";
	/// <summary>
	/// 設定情報
	/// </summary>
	private static ConfigData? sourceData = null;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 読込位置を取得または設定します。
	/// </summary>
	/// <value>読込位置</value>
	public static string SourceFile {
		get => sourceFile;
		set => sourceFile = value;
	}
	/// <summary>
	/// 設定情報を取得します。
	/// </summary>
	/// <returns>設定情報</returns>
	public static ConfigData SourceData => sourceData ??= Create(SourceFile);
	/// <summary>
	/// 検索設定一覧を取得します。
	/// </summary>
	/// <value>検索設定一覧</value>
	public SearchList SearchList {
		get;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 基本設定情報を生成します。
	/// </summary>
	/// <param name="searchList">検索設定一覧</param>
	private ConfigData(SearchList searchList) {
		SearchList = searchList;
	}
	/// <summary>
	/// 基本設定情報を生成します。
	/// </summary>
	/// <param name="source">設定情報</param>
	/// <returns>基本設定情報</returns>
	private static ConfigData Create(XmlNode source) {
		var searchList = SearchList.Create(source.GetData("searches", null));
		return new(searchList);
	}
	/// <summary>
	/// 基本設定情報を生成します。
	/// </summary>
	/// <param name="source">設定位置</param>
	/// <returns>基本設定情報</returns>
	private static ConfigData Create(string source) {
		var parser = new XmlDocument();
		parser.Load(source);
		#pragma warning disable CS8604
		return Create(parser.DocumentElement);
		#pragma warning restore CS8604
	}
	#endregion 生成メソッド定義
}
