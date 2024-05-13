using System;
using Occhitta.Libraries.Screen.Data;

namespace Occhitta.Example.Screen;

/// <summary>
/// 主要画面情報クラスです。
/// </summary>
internal sealed class WindowData : AbstractScreenData {
	#region メンバー変数定義
	/// <summary>
	/// 検索情報
	/// </summary>
	private SearchData? searchData;
	/// <summary>
	/// 状態内容
	/// </summary>
	private string? statusText;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 検索情報を取得します。
	/// </summary>
	/// <returns>検索情報</returns>
	public SearchData SearchData =>
		this.searchData ??= CreateSearchData();
	/// <summary>
	/// 状態内容を取得します。
	/// </summary>
	/// <value>状態内容</value>
	public string? StatusText {
		get => this.statusText;
		private set => Update(ref this.statusText, value, nameof(StatusText));
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 主要画面情報を生成します。
	/// </summary>
	public WindowData() {
		this.searchData = default;
		this.statusText = default;
	}
	#endregion 生成メソッド定義

	#region 内部メソッド定義(CreateSearchData)
	/// <summary>
	/// 検索情報を生成します。
	/// </summary>
	/// <returns></returns>
	private SearchData CreateSearchData() {
		try {
			var configData = Occhitta.Example.Config.ConfigData.SourceData;
			return new SearchData(configData);
		} catch (Exception errors) {
			StatusText = errors.Message;
			return new SearchData(null);
		}
	}
	#endregion 内部メソッド定義(CreateSearchData)
}
