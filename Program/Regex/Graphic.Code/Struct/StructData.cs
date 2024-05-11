namespace Occhitta.Example.Struct;

/// <summary>
/// 構造情報インターフェースです。
/// </summary>
#pragma warning disable IDE1006
internal interface StructData {
#pragma warning restore IDE1006
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
	/// 抽出内容を取得します。
	/// </summary>
	/// <value>抽出内容</value>
	public string ChooseText {
		get;
	}
}
