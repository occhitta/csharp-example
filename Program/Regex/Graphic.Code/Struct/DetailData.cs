using System.Text.RegularExpressions;

namespace Occhitta.Example.Struct;

/// <summary>
/// 詳細情報クラスです。
/// </summary>
internal sealed class DetailData : StructData {
	#region メンバー変数定義
	/// <summary>
	/// 要素情報
	/// </summary>
	private readonly Capture source;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 開始位置を取得します。
	/// </summary>
	/// <value>開始位置</value>
	public int StartIndex {
		get => this.source.Index;
	}
	/// <summary>
	/// 抽出個数を取得します。
	/// </summary>
	/// <value>抽出個数</value>
	public int ChooseSize {
		get => this.source.Length;
	}
	/// <summary>
	/// 抽出内容を取得します。
	/// </summary>
	/// <value>抽出内容</value>
	public string ChooseText {
		get => this.source.Value;
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 詳細情報を生成します。
	/// </summary>
	/// <param name="source">要素情報</param>
	private DetailData(Capture source) {
		this.source = source;
	}
	/// <summary>
	/// 詳細情報を生成します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <returns>詳細情報</returns>
	public static DetailData Create(Capture source) =>
		new(source);
	#endregion 生成メソッド定義
}
