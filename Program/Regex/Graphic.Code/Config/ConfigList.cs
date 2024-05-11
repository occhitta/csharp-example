using System.Collections.Generic;
using System.Xml;
using Occhitta.Libraries.Common;

namespace Occhitta.Example.Config;

/// <summary>
/// 設定一覧クラスです。
/// /// </summary>
internal sealed class ConfigList : IReadOnlyList<ConfigData> {
	#region メンバー変数定義
	/// <summary>
	/// 要素配列
	/// </summary>
	private readonly ConfigData[] source;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 要素個数を取得します。
	/// </summary>
	/// <value>要素個数</value>
	public int Count => this.source.Length;
	/// <summary>
	/// 要素情報を取得します。
	/// </summar>
	/// <param name="index">要素番号</param>
	/// <value>要素情報</value>
	public ConfigData this[int index] => this.source[index];
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 設定一覧を生成します。
	/// </summary>
	/// <param name="source">要素配列</param>
	private ConfigList(ConfigData[] source) {
		this.source = source;
	}
	/// <summary>
	/// 設定一覧を生成します。
	/// </summary>
	/// <param name="source">設定情報</param>
	/// <returns>設定一覧</returns>
	private static ConfigList Create(XmlNode source) =>
		new(source.GetList("template", ConfigData.Create));
	/// <summary>
	/// 設定一覧を生成します。
	/// </summary>
	/// <param name="source">設定位置</param>
	/// <returns>設定情報</returns>
	public static ConfigList Create(string source) {
		var parser = new XmlDocument();
		parser.Load(source);
		#pragma warning disable CS8604
		return Create(parser.DocumentElement);
		#pragma warning restore CS8604
	}
	#endregion 生成メソッド定義

	#region 実装メソッド定義
	/// <summary>
	/// 反復処理を取得します。
	/// </summary>
	/// <returns>反復処理</returns>
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
		foreach (var choose in this.source) {
			yield return choose;
		}
	}
	/// <summary>
	/// 反復処理を取得します。
	/// </summary>
	/// <returns>反復処理</returns>
	IEnumerator<ConfigData> IEnumerable<ConfigData>.GetEnumerator() {
		foreach (var choose in this.source) {
			yield return choose;
		}
	}
	#endregion 実装メソッド定義
}
