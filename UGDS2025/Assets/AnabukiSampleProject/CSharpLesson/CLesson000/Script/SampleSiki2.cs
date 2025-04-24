using System.Collections;
using UnityEngine;

/// <summary>
/// C#の制御構文（発展編）
/// try-catch、コルーチン、break、continue、return、論理演算子などを
/// 初心者向けに丁寧な説明を付けて紹介するスクリプト
/// </summary>
public class SampleSiki2 : MonoBehaviour
{
    void Start()
    {
        //try-catch文（例外処理）
        TryCatchExamples();
        //コルーチンと yield return
        StartCoroutine(CoroutineExamples());
        //break / continue
        BreakContinueExamples();
        //return文の使い方
        ReturnExamples();
        //論理演算子（&&, ||, !）
        LogicOperatorExamples();
    }

    // ====================================
    // 【1】try-catch文（例外処理）の使い方
    // ====================================
    void TryCatchExamples()
    {
        Debug.Log("=== try-catch文の例 ===");

        // 説明：
        // 「try-catch」は、プログラム中で「エラーが発生しそうな場所」を
        // あらかじめ囲い、もしエラーが起きた時でもプログラムが止まらず
        // 代わりの処理を行うための構文です。
        // 「ゲームが強制終了しないように守る盾」と考えると分かりやすいです！

        // 【パターン1】ゼロ除算による例外
        try
        {
            //処理される内容
            int x = 10;
            int y = 0;
            int result = x / y;
            Debug.Log("計算結果：" + result);
        }
        catch (System.DivideByZeroException e)
        {
            //エラー時にこちらが処理されるが、止まらない。
            Debug.Log("エラー発生！0で割ることはできません！ → " + e.Message);
        }

        // 【パターン2】配列の範囲外アクセス
        try
        {
            //処理される内容
            int[] array = { 1, 2, 3 };
            int val = array[5]; // 存在しないインデックス
            Debug.Log("取得した値：" + val);
        }
        catch (System.IndexOutOfRangeException e)
        {
            //エラー時にこちらが処理されるが、止まらない。
            Debug.Log("配列の範囲外にアクセスしました → " + e.Message);
        }

        // 【パターン3】catch文を省略し、finallyで終了処理
        try
        {
            //処理される内容
            Debug.Log("処理開始");
            string s = null;
            Debug.Log(s.ToUpper()); // nullのまま使用
        }
        catch
        {
            //エラー時にこちらが処理されるが、止まらない。
            Debug.Log("何らかのエラーが発生しました");
        }
        finally
        {
            //catch処理無視して終了
            Debug.Log("この処理はエラーの有無にかかわらず実行されます");
        }
    }

    // ====================================
    // 【2】コルーチンと yield return の使い方
    // ====================================
    IEnumerator CoroutineExamples()
    {
        Debug.Log("=== コルーチンの例 ===");

        // 説明：
        // Unityでは「一定時間待つ」「数秒ごとに処理を繰り返す」といった
        // 時間に関わる処理は、コルーチン（Coroutine）で書きます。
        // 「yield return WaitForSeconds(秒数)」と書くと、その分だけ待ってから
        // 次の処理が行われます。

        // 【パターン1】1秒待ってからメッセージ
        Debug.Log("1秒待ちます...");
        yield return new WaitForSeconds(1f);
        Debug.Log("1秒経過しました");

        // 【パターン2】3回繰り返して1秒待つ
        for (int i = 1; i <= 3; i++)
        {
            Debug.Log(i + "回目の処理中...");
            yield return new WaitForSeconds(1f);
        }

        // 【パターン3】特定の条件が成立するまで繰り返す
        int counter = 0;
        while (counter < 5)
        {
            Debug.Log("待機中... counter=" + counter);
            yield return new WaitForSeconds(0.5f);
            counter++;
        }

        Debug.Log("コルーチン終了！");
    }

    // ====================================
    // 【3】break / continue の使い方
    // ====================================
    void BreakContinueExamples()
    {
        Debug.Log("=== break / continue の例 ===");

        // 説明：
        // break：ループを途中で終了させる。
        // continue：ループ内で特定の条件の時だけ処理を飛ばす。
        // ゲームで「条件付きスキップ」や「離脱処理」などに使います。

        // 【パターン1】breakの使用
        for (int i = 0; i < 10; i++)
        {
            if (i == 3)
            {
                Debug.Log("iが3なのでループ終了");
                break;
            }
            Debug.Log("i = " + i);
        }

        // 【パターン2】continueの使用
        for (int i = 0; i < 5; i++)
        {
            if (i == 2)
            {
                Debug.Log("iが2なので処理スキップ");
                continue;
            }
            Debug.Log("i = " + i);
        }

        // 【パターン3】breakとcontinueの組み合わせ
        for (int i = 1; i <= 5; i++)
        {
            if (i == 2)
            {
                continue; // 2のときスキップ
            }
            if (i == 4)
            {
                break; // 4で終了
            }
            Debug.Log("処理：" + i);
        }
    }

    // ====================================
    // 【4】return文の使い方（値を返す / 処理を終了）
    // ====================================
    void ReturnExamples()
    {
        Debug.Log("=== return文の例 ===");

        // 説明：
        // returnは「値を返す」か「その時点で処理を終える」ために使います。
        // メソッド内で「ここで処理を止めたい！」という場面に役立ちます。

        // 【パターン1】値を返す関数の使用
        int sum = Add(3, 4);
        Debug.Log("3 + 4 = " + sum);

        // 【パターン2】途中で終了するvoid関数
        PrintIfPositive(-5);

        // 【パターン3】条件によりreturnする関数
        Debug.Log("偶数判定：" + IsEven(8));
    }

    int Add(int a, int b)
    {
        return a + b;
    }

    void PrintIfPositive(int num)
    {
        if (num < 0)
        {
            Debug.Log("0未満のため中断");
            return; // ここで処理終了
        }
        Debug.Log("正の数：" + num);
    }

    bool IsEven(int n)
    {
        return n % 2 == 0;
    }

    // ====================================
    // 【5】論理演算子（&&, ||, !）の使い方
    // ====================================
    void LogicOperatorExamples()
    {
        Debug.Log("=== 論理演算子の例 ===");

        // 説明：
        // &&（AND）：両方trueの時にtrue
        // ||（OR）：どちらかがtrueならtrue
        // !（NOT）：trueをfalseに、falseをtrueにする
        // 様々な条件で利用できる演算子です。
        // if文以外にも様々な面で役に立ちます

        bool hasKey = true;
        bool doorIsClosed = false;

        // 【パターン1】AND（&&）
        if (hasKey && doorIsClosed)
        {
            Debug.Log("鍵があり、扉が閉じている → 開ける！");
        }
        else
        {
            Debug.Log("鍵がないか、扉が開いている");
        }

        // 【パターン2】OR（||）
        bool isAdmin = false;
        bool isPlayer = true;
        if (isAdmin || isPlayer)
        {
            Debug.Log("何らかの権限を持っているユーザーです");
        }

        // 【パターン3】NOT（!）
        bool isDead = false;
        if (!isDead)
        {
            Debug.Log("キャラクターは生きている！");
        }
    }
}
