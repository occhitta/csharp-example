using System.Collections.Generic;
using System.Xml;
using Occhitta.Libraries.Common;

namespace Occhitta.Example.Config;

/// <summary>
/// 検索設定一覧クラスです。
/// /// </summary>
internal sealed class SearchList : IReadOnlyList<SearchData> {
	#region メンバー変数定義
	/// <summary>
	/// 要素配列
	/// </summary>
	private readonly SearchData[] source;
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
	public SearchData this[int index] => this.source[index];
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 検索設定一覧を生成します。
	/// </summary>
	/// <param name="source">要素配列</param>
	private SearchList(SearchData[]? source) {
		this.source = source ?? [];
	}
	/// <summary>
	/// 検索設定一覧を生成します。
	/// </summary>
	/// <param name="source">設定情報</param>
	/// <returns>検索設定一覧</returns>
	public static SearchList Create(XmlNode? source) =>
		new(source?.GetList("search", SearchData.Create));
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
	IEnumerator<SearchData> IEnumerable<SearchData>.GetEnumerator() {
		foreach (var choose in this.source) {
			yield return choose;
		}
	}
	#endregion 実装メソッド定義
}
