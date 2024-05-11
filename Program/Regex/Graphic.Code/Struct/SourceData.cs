using System.Text.RegularExpressions;

namespace Occhitta.Example.Struct;

/// <summary>
/// 基本情報クラスです。
/// </summary>
internal sealed class SourceData : StructData {
	#region プロパティー定義
	/// <summary>
	/// 結果状態を取得します。
	/// </summary>
	/// <value>結果状態</value>
	public bool ResultFlag {
		get;
	}
	/// <summary>
	/// 開始位置を取得します。
	/// </summary>
	/// <value>開始位置</value>
	public int StartIndex {
		get;
	}
	/// <summary>
	/// 抽出個数を取得します。
	/// </summary>
	/// <value>抽出個数</value>
	public int ChooseSize {
		get;
	}
	/// <summary>
	/// 抽出名称を取得します。
	/// </summary>
	/// <value>抽出名称</value>
	public string ChooseName {
		get;
	}
	/// <summary>
	/// 抽出内容を取得します。
	/// </summary>
	/// <value>抽出内容</value>
	public string ChooseText {
		get;
	}
	/// <summary>
	/// 分岐一覧を取得します。
	/// </summary>
	/// <value>分岐一覧</value>
	public BranchList BranchList {
		get;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 基本情報を生成します。
	/// </summary>
	/// <param name="sourceData">要素情報</param>
	private SourceData(Match sourceData) {
		ResultFlag = sourceData.Success;
		StartIndex = sourceData.Index;
		ChooseSize = sourceData.Length;
		ChooseName = sourceData.Name;
		ChooseText = sourceData.Value;
		BranchList = BranchList.Create(
			BranchData.Create("Groups",   DivideList.Create(sourceData.Groups)),
			BranchData.Create("Captures", DetailList.Create(sourceData.Captures))
		);
	}
	/// <summary>
	/// 基本情報を生成します。
	/// </summary>
	/// <param name="sourceData">要素情報</param>
	/// <returns>基本情報</returns>
	public static SourceData Create(Match sourceData) =>
		new(sourceData);
	#endregion 生成メソッド定義
}
