using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

[assembly:ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]

namespace Occhitta.Example;

/// <summary>
/// 正規表現サンプルクラスです。
/// </summary>
internal static class MainModule {
	#region 内部メソッド定義(Except)
	/// <summary>
	/// 例外情報を処理します。
	/// </summary>
	/// <param name="sender">発信情報</param>
	/// <param name="option">引数情報</param>
	private static void Except(object sender, DispatcherUnhandledExceptionEventArgs option) {
		var output = $"予期しないエラーが発生しました。{Environment.NewLine}処理を続行しますか？{Environment.NewLine}----------------------------------------------------------------------{Environment.NewLine}{option.Exception.Message}";
		if (MessageBox.Show(output, $"[画面処理]想定外エラー", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes) {
			option.Handled = true;
		} else {
			Environment.Exit(3);
		}
	}
	/// <summary>
	/// 例外情報を処理します。
	/// </summary>
	/// <param name="sender">発信情報</param>
	/// <param name="option">引数情報</param>
	private static void Except(object? sender, UnobservedTaskExceptionEventArgs option) {
		var output = $"予期しないエラーが発生しました。{Environment.NewLine}処理を続行しますか？{Environment.NewLine}----------------------------------------------------------------------{Environment.NewLine}{option.Exception.Message}";
		if (MessageBox.Show(output, $"[並列処理]想定外エラー", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes) {
			option.SetObserved();
		} else {
			Environment.Exit(2);
		}
	}
	/// <summary>
	/// 例外情報を処理します。
	/// </summary>
	/// <param name="sender">発信情報</param>
	/// <param name="option">引数情報</param>
	private static void Except(object sender, UnhandledExceptionEventArgs option) {
		var choose = option.ExceptionObject as Exception;
		var output = $"予期しないエラーが発生しました。{Environment.NewLine}----------------------------------------------------------------------{Environment.NewLine}{choose?.Message}";
		MessageBox.Show(output, $"[異常処理]想定外エラー", MessageBoxButton.OK, MessageBoxImage.Stop);
		Environment.Exit(1);
	}
	#endregion 内部メソッド定義(Except)

	#region 内部メソッド定義(ToPath)
	/// <summary>
	/// 参照情報へ変換します。
	/// </summary>
	/// <param name="source">参照経路</param>
	/// <returns>参照情報</returns>
	private static Uri ToPath(string source) =>
		new(source, UriKind.Relative);
	#endregion 内部メソッド定義(ToPath)

	#region 内部メソッド定義(Regist)
	/// <summary>
	/// 参照情報を登録します。
	/// </summary>
	/// <param name="source">参照一覧</param>
	/// <param name="values">登録配列</param>
	private static void Regist(Collection<ResourceDictionary> source, string[] values) {
		foreach (var choose in values) {
			source.Add(new ResourceDictionary() { Source = ToPath(choose) });
		}
	}
	/// <summary>
	/// 参照情報を登録します。
	/// </summary>
	/// <param name="source">要素情報</param>
	/// <param name="values">登録配列</param>
	private static void Regist(ResourceDictionary source, params string[] values) =>
		Regist(source.MergedDictionaries, values);
	#endregion 内部メソッド定義(Regist)

	#region 実行メソッド定義(Main)
	/// <summary>
	/// 正規表現サンプルを起動します。
	/// </summary>
	/// <param name="args">コマンドライン引数</param>
	[STAThread]
	public static void Main(string[] args) {
		// 初期処理
		AppDomain.CurrentDomain.UnhandledException += Except;
		TaskScheduler.UnobservedTaskException += Except;

		// 生成処理
		var source = new Application() { StartupUri = ToPath("/Screen/WindowView.xaml") };
		source.DispatcherUnhandledException += Except;

		// 設定処理
		Regist(source.Resources,
			"/Struct/SourceData.xaml",
			"/Struct/BranchData.xaml",
			"/Struct/DivideList.xaml",
			"/Struct/DetailList.xaml",
			"/Struct/DivideData.xaml",
			"/Struct/DetailData.xaml");

		source.Run();
	}
	#endregion 実行メソッド定義(Main)
}
