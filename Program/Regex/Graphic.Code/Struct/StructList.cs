namespace Occhitta.Example.Struct;

/// <summary>
/// 構造一覧インターフェースです。
/// </summary>
#pragma warning disable IDE1006
internal interface StructList : System.Collections.IEnumerable {
#pragma warning restore IDE1006
	// 処理なし
}
/// <summary>
/// 構造一覧インターフェースです。
/// </summary>
/// <typeparam name="TValue">要素種別</typeparam>
#pragma warning disable IDE1006
internal interface StructList<TValue> : StructList, System.Collections.Generic.IReadOnlyList<TValue> where TValue : StructData {
#pragma warning restore IDE1006
	// 処理なし
}
