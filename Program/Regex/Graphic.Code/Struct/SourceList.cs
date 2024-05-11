using System.Text.RegularExpressions;

namespace Occhitta.Example.Struct;

/// <summary>
/// 基本一覧クラスです。
/// </summary>
internal sealed class SourceList : StructList<SourceData> {
	#region メンバー変数定義
	/// <summary>
	/// 要素配列
	/// </summary>
	private readonly SourceData[] source;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 要素個数を取得します。
	/// </summary>
	/// <value>要素個数</value>
	public int Count => this.source.Length;
	/// <summary>
	/// 要素情報を取得します。
	/// </summary>
	/// <param name="index">要素番号</param>
	/// <value>要素情報</value>
	public SourceData this[int index] => this.source[index];
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 基本一覧を生成します。
	/// </summary>
	/// <param name="source">要素配列</param>
	private SourceList(SourceData[] source) {
		this.source = source;
	}
	/// <summary>
	/// 基本一覧を生成します。
	/// </summary>
	/// <param name="source">要素一覧</param>
	/// <returns>詳細一覧</returns>
	private static SourceList Create(MatchCollection source) {
		var result = new SourceData[source.Count];
		for (var index = 0; index < result.Length; index ++) {
			result[index] = SourceData.Create(source[index]);
		}
		return new(result);
	}
	/// <summary>
	/// 基本一覧を生成します。
	/// </summary>
	/// <param name="source">解析内容</param>
	/// <param name="format">解析書式</param>
	/// <param name="option">解析種別</param>
	/// <returns>基本一覧</returns>
	public static SourceList Create(string source, string format, RegexOptions option) =>
		Create(Regex.Matches(source, format, option));
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
	System.Collections.Generic.IEnumerator<SourceData> System.Collections.Generic.IEnumerable<SourceData>.GetEnumerator() {
		foreach (var choose in this.source) {
			yield return choose;
		}
	}
	#endregion 実装メソッド定義
}
