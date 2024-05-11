namespace Occhitta.Example.Struct;

/// <summary>
/// 分類一覧クラスです。
/// </summary>
internal sealed class DivideList : StructList<DivideData> {
	#region メンバー変数定義
	/// <summary>
	/// 要素配列
	/// </summary>
	private readonly DivideData[] source;
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
	public DivideData this[int index] => this.source[index];
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 分類一覧を生成します。
	/// </summary>
	/// <param name="source">要素配列</param>
	private DivideList(DivideData[] source) {
		this.source = source;
	}
	/// <summary>
	/// 分類一覧を生成します。
	/// </summary>
	/// <param name="source">要素一覧</param>
	/// <returns>分類一覧</returns>
	public static DivideList Create(System.Text.RegularExpressions.GroupCollection source) {
		var result = new DivideData[source.Count];
		for (var index = 0; index < result.Length; index ++) {
			result[index] = DivideData.Create(source[index]);
		}
		return new(result);
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
	System.Collections.Generic.IEnumerator<DivideData> System.Collections.Generic.IEnumerable<DivideData>.GetEnumerator() {
		foreach (var choose in this.source) {
			yield return choose;
		}
	}
	#endregion 実装メソッド定義
}
