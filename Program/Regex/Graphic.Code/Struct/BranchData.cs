namespace Occhitta.Example.Struct;

/// <summary>
/// 分岐情報クラスです。
/// </summary>
internal sealed class BranchData {
	#region プロパティー定義
	/// <summary>
	/// 要素名称を取得します。
	/// </summary>
	/// <value>要素名称</value>
	public string Name {
		get;
	}
	/// <summary>
	/// 要素一覧を取得します。
	/// </summary>
	/// <value>要素一覧</value>
	public StructList List {
		get;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 分岐情報を取得します。
	/// </summary>
	/// <param name="name">要素名称</param>
	/// <param name="list">要素一覧</param>
	private BranchData(string name, StructList list) {
		Name = name;
		List = list;
	}
	/// <summary>
	/// 分岐情報を取得します。
	/// </summary>
	/// <param name="name">要素名称</param>
	/// <param name="list">要素一覧</param>
	/// <returns>分岐情報</returns>
	public static BranchData Create(string name, StructList list) =>
		new(name, list);
	#endregion 生成メソッド定義
}
