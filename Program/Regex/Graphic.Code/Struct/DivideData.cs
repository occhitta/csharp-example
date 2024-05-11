using System.Text.RegularExpressions;

namespace Occhitta.Example.Struct;

/// <summary>
/// 分類情報クラスです。
/// </summary>
internal sealed class DivideData : StructData {
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
	/// 詳細一覧を取得します。
	/// </summary>
	/// <value>詳細一覧</value>
	public DetailList DetailList {
		get;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 分類情報を生成します。
	/// </summary>
	/// <param name="sourceData">要素情報</param>
	private DivideData(Group sourceData) {
		ResultFlag = sourceData.Success;
		StartIndex = sourceData.Index;
		ChooseSize = sourceData.Length;
		ChooseName = sourceData.Name;
		ChooseText = sourceData.Value;
		DetailList = DetailList.Create(sourceData.Captures);
	}
	/// <summary>
	/// 分類情報を生成します。
	/// </summary>
	/// <param name="sourceData">要素情報</param>
	/// <returns>分類情報</returns>
	public static DivideData Create(Group sourceData) =>
		new(sourceData);
	#endregion 生成メソッド定義
}
