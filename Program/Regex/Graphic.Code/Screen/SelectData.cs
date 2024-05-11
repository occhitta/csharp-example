using Occhitta.Libraries.Screen.Data;

namespace Occhitta.Example.Screen;

/// <summary>
/// 選択画面情報クラスです。
/// </summary>
/// <param name="data">選択情報</param>
/// <param name="name">選択名称</param>
/// <param name="flag">選択状態</param>
internal sealed class SelectData<TValue>(TValue data, string name, bool flag = false) : AbstractScreenData {
	#region メンバー変数定義
	/// <summary>
	/// 選択情報
	/// </summary>
	private readonly TValue data = data;
	/// <summary>
	/// 選択名称
	/// </summary>
	private readonly string name = name;
	/// <summary>
	/// 選択状態
	/// </summary>
	private bool flag = flag;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 選択情報を取得します。
	/// </summary>
	/// <value>選択情報</value>
	public TValue Data {
		get => this.data;
	}
	/// <summary>
	/// 選択名称を取得します。
	/// </summary>
	/// <value>選択名称</value>
	public string Name {
		get => this.name;
	}
	/// <summary>
	/// 選択状態を取得または設定します。
	/// </summary>
	/// <value>選択状態</value>
	public bool Flag {
		get => this.flag;
		set => Update(ref this.flag, value, nameof(Flag));
	}
	#endregion プロパティー定義
}
