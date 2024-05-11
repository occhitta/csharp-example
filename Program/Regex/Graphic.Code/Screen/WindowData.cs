using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using Occhitta.Example.Config;
using Occhitta.Example.Struct;
using Occhitta.Libraries.Screen.Data;
using Occhitta.Libraries.Screen.Hook;

namespace Occhitta.Example.Screen;

/// <summary>
/// 主要画面情報クラスです。
/// </summary>
internal sealed class WindowData : AbstractScreenData {
	#region メンバー変数定義
	/// <summary>
	/// 設定一覧
	/// </summary>
	private readonly ConfigList? configList;
	/// <summary>
	/// 設定情報
	/// </summary>
	private ConfigData? configData;
	/// <summary>
	/// 書式内容
	/// </summary>
	private string? formatText;
	/// <summary>
	/// 種別一覧
	/// </summary>
	private ReadOnlyCollection<SelectData<RegexOptions>>? optionList;
	/// <summary>
	/// 判定内容
	/// </summary>
	private string? sourceText;
	/// <summary>
	/// 実行操作
	/// </summary>
	private DelegateScreenLightHook? invokeMenu;
	/// <summary>
	/// 状態内容
	/// </summary>
	private string? statusText;
	/// <summary>
	/// 結果情報
	/// </summary>
	private SourceList? resultData;
	#endregion メンバー変数定義

	#region プロパティー定義
	/// <summary>
	/// 設定一覧を取得します。
	/// </summary>
	/// <value>設定一覧</value>
	public ConfigList? ConfigList {
		get => this.configList;
	}
	/// <summary>
	/// 設定情報を取得または設定します。
	/// </summary>
	/// <value>設定情報</value>
	public ConfigData? ConfigData {
		get => this.configData;
		set => Update(ref this.configData, value, nameof(ConfigData), ActionConfigData);
	}
	/// <summary>
	/// 書式内容を取得または設定します。
	/// </summary>
	/// <value>書式内容</value>
	public string? FormatText {
		get => this.formatText;
		set => Update(ref this.formatText, value, nameof(FormatText));
	}
	/// <summary>
	/// 種別一覧を取得します。
	/// </summary>
	/// <returns>種別一覧</returns>
	public ReadOnlyCollection<SelectData<RegexOptions>> OptionList =>
		this.optionList ??= CreateOptionList();
	/// <summary>
	/// 判定内容を取得または設定します。
	/// </summary>
	/// <value>判定内容</value>
	public string? SourceText {
		get => this.sourceText;
		set => Update(ref this.sourceText, value, nameof(SourceText));
	}
	/// <summary>
	/// 実行操作を取得します。
	/// </summary>
	/// <returns>実行操作</returns>
	public AbstractScreenLightHook InvokeMenu =>
		this.invokeMenu ??= new DelegateScreenLightHook(ActionInvokeMenu);
	/// <summary>
	/// 状態内容を取得します。
	/// </summary>
	/// <value>状態内容</value>
	public string? StatusText {
		get => this.statusText;
		private set => Update(ref this.statusText, value, nameof(StatusText));
	}
	/// <summary>
	/// 結果情報を取得します。
	/// </summary>
	/// <value>結果情報</value>
	public SourceList? ResultData {
		get => this.resultData;
		private set => Update(ref this.resultData, value, nameof(ResultData));
	}
	#endregion プロパティー定義

	#region 生成メソッド定義
	/// <summary>
	/// 主要画面情報を生成します。
	/// </summary>
	public WindowData() {
		this.configList = CreateConfigList();
		this.configData = default;
		this.formatText = default;
		this.optionList = default;
		this.sourceText = default;
		this.invokeMenu = default;
		this.statusText = default;
		this.resultData = default;
	}
	#endregion 生成メソッド定義

	#region 内部メソッド定義(CreateConfigList)
	/// <summary>
	/// 設定一覧を生成します。
	/// </summary>
	/// <returns>設定一覧</returns>
	private static ConfigList? CreateConfigList() {
		try {
			return ConfigList.Create(@"Template.xml");
		} catch {
			return null;
		}
	}
	#endregion 内部メソッド定義(CreateConfigList)

	#region 内部メソッド定義(CreateOptionList)
	/// <summary>
	/// 種別一覧を生成します。
	/// </summary>
	/// <returns>種別一覧</returns>
	private static ReadOnlyCollection<SelectData<RegexOptions>> CreateOptionList() {
		var result = new List<SelectData<RegexOptions>>();
		foreach (var choose in Enum.GetValues<RegexOptions>()) {
			result.Add(new(choose, choose.ToString(), false));
		}
		return new(result);
	}
	#endregion 内部メソッド定義(CreateOptionList)

	#region 内部メソッド定義(ActionConfigData)
	/// <summary>
	/// 設定変更を処理します。
	/// </summary>
	private void ActionConfigData() {
		var configData = this.configData;
		if (configData != null) {
			FormatText = configData.FormatText;
			SourceText = configData.SourceText;
			foreach (var optionData in OptionList) {
				optionData.Flag = (optionData.Data & configData.OptionData) != 0;
			}
		}
	}
	#endregion 内部メソッド定義(ActionConfigData)

	#region 内部メソッド定義(ChooseOptionData)
	/// <summary>
	/// 解析種別を取得します。
	/// </summary>
	/// <returns>解析種別</returns>
	private RegexOptions ChooseOptionData() {
		if (this.optionList == null || this.optionList.Count <= 0) {
			return RegexOptions.None;
		} else {
			var result = RegexOptions.None;
			foreach (var choose in this.optionList) {
				if (choose.Flag) {
					result |= choose.Data;
				}
			}
			return result;
		}
	}
	#endregion 内部メソッド定義(ChooseOptionData)

	#region 内部メソッド定義(ActionInvokeMenu)
	/// <summary>
	/// 実行操作を実行します。
	/// </summary>
	private void ActionInvokeMenu() {
		ResultData = null;
		if (String.IsNullOrEmpty(this.formatText)) {
			StatusText = "書式を入力してください";
		} else {
			StatusText = null;
			try {
				ResultData = SourceList.Create(this.sourceText ?? String.Empty, this.formatText, ChooseOptionData());
			} catch (Exception errors) {
				StatusText = $"書式が正しくありません({errors.Message})";
			}
		}
	}
	#endregion 内部メソッド定義(ActionInvokeMenu)
}
