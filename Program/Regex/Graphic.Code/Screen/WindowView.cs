using System.Windows;
using System.Windows.Input;

namespace Occhitta.Example.Screen;

/// <summary>
/// 主要画面制御クラスです。
/// </summary>
internal partial class WindowView : Window {
	/// <summary>
	/// 主要画面制御を生成します。
	/// </summary>
	public WindowView() {
		InitializeComponent();
	}

	/// <summary>
	/// 終了可否を判定します。
	/// </summary>
	/// <param name="sender">発信情報</param>
	/// <param name="option">引数情報</param>
	private void AcceptFinishMenu(object sender, CanExecuteRoutedEventArgs option) {
		option.CanExecute = true;
	}
	/// <summary>
	/// 終了処理を実行します。
	/// </summary>
	/// <param name="sender">発信情報</param>
	/// <param name="option">引数情報</param>
	private void InvokeFinishMenu(object sender, ExecutedRoutedEventArgs option) {
		Close();
	}
}
