using UnityEngine;
using System.Threading.Tasks;

/// <summary>
/// C#の非同期処理（async/await）をUnityで活用する方法を解説
/// Unityにおける使いどころ、待機処理、重い処理の対策に使える
/// ゲームを作成する上で処理落ちは特に大問題であるし、
/// 他にも、メインの処理中に他の処理を行う際にも利用する。
/// 例えば、NowLoading等の、画面や音楽を流しながら、裏でデータを
/// 読み込むなどの技術は必須技術のひとつ。
/// ぜひ覚えておこう!
/// </summary>

public class SampleSiki5 : MonoBehaviour
{
    void Start()
    {
        Debug.Log("=== async/await の例 ===");

        // 非同期関数を呼び出す（戻り値なし）
        RunAsyncTask();

        // 非同期関数を呼び出す（戻り値あり）
        UseAsyncResult();
    }

    // ====================================
    // 【1】非同期メソッド（戻り値なし）
    // ====================================
    async void RunAsyncTask()
    {
        Debug.Log("処理1：開始");

        // 説明：
        // Task.Delayは「指定時間だけ待つ」非同期のタイマーです。
        // UnityのWaitForSecondsとは違い、スレッドを止めません。
        // スレッドを止めない為ラグも発生しません。

        // 2秒待機（非ブロッキング）
        await Task.Delay(2000);
        // 2秒立ったので、コンソールに告知
        Debug.Log("処理1：2秒後に完了");
    }

    // ====================================
    // 【2】非同期メソッド（戻り値あり）
    // ====================================
    async void UseAsyncResult()
    {
        Debug.Log("処理2：計算開始");

        //戻り値ありの処理例
        //HeavyCalculationAsync(5, 3)のように2つの変数を代入し
        //結果である2つの変数を掛けた値を返してくる。
        //この際も非同期処理がされ、実質上1秒後に結果が出ます。
        //1秒の理由は、HeavyCalculationAsyncの非同期関数を見てみよう!
        int result = await HeavyCalculationAsync(5, 3);
        //コンソールに告知
        Debug.Log("処理2：計算結果 = " + result);
    }

    /// <summary>
    /// 非同期関数（重い処理を模倣）
    /// </summary>
    /// <param name="a">int型代入値</param>
    /// <param name="b">int型代入値</param>
    /// <returns></returns>
    async Task<int> HeavyCalculationAsync(int a, int b)
    {
        //コンソールに告知
        Debug.Log("HeavyCalculationAsync 処理中...");
        // 1秒待機（CPU処理の代わり）
        await Task.Delay(1000);
        // 計算して返す
        return a * b;
    }
}
