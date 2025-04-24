using UnityEngine;

/// <summary>
/// より高度なC#の式や演算子を学ぶスクリプト（初心者向け）
/// ・三項演算子
/// ・null合体演算子（??）
/// ・null条件演算子（?.）
/// ・switch式（C#7以降）
/// 文ではなく、演算子単体で出来る事も含めて便利です。
/// </summary>
public class SampleSiki3 : MonoBehaviour
{
    void Start()
    {
        //三項演算子（条件 ? A : B）
        TernaryOperatorExamples();
        //null合体演算子（??）
        NullCoalescingExamples();
        //null条件演算子（?.）
        NullConditionalExamples();
        //switch式（C# 7.0以降）
        SwitchExpressionExamples();
    }

    // ====================================
    // 【1】三項演算子（条件 ? A : B）
    // ====================================
    void TernaryOperatorExamples()
    {
        Debug.Log("=== 三項演算子の例 ===");

        // 説明：
        // 三項演算子は、if-elseを1行で書ける便利な式です。
        // 形式は「条件 ? 真のときの値 : 偽のときの値」
        // 表示や値の代入がシンプルになります！
        // いちいち、if文で分岐しなくても、これを使えば結果を出す事が可能です。

        int score = 85;

        // 【パターン1】合否の判定
        string result = score >= 60 ? "合格" : "不合格";
        Debug.Log("スコア：" + score + " → 判定：" + result);

        // 【パターン2】UIの文字色を変更（例）
        bool isWarning = true;
        string textColor = isWarning ? "赤" : "白";
        Debug.Log("表示色：" + textColor);

        // 【パターン3】nullの簡易チェックに応用
        string name = null;
        string displayName = name != null ? name : "名前未設定";
        Debug.Log("表示名：" + displayName);
    }

    // ====================================
    // 【2】null合体演算子（??）
    // ====================================
    void NullCoalescingExamples()
    {
        Debug.Log("=== null合体演算子（??）の例 ===");

        // 説明：
        // 「??」は「もし左がnullなら右を使う」という簡単な書き方です。
        // 変数が未設定だった場合の「予備値」を設定するのに便利です。
        // いちいち、if文で分岐しなくても、これを使えば結果を出す事が可能です。

        string username = null;

        // 【パターン1】名前が未設定の時は「ゲスト」と表示
        string showName = username ?? "ゲスト";
        Debug.Log("ユーザー名：" + showName);

        // 【パターン2】int?（null許容型）で使用
        int? level = null;
        int actualLevel = level ?? 1;
        Debug.Log("プレイヤーレベル：" + actualLevel);

        // 【パターン3】オブジェクト参照がnullのとき
        GameObject obj = null;
        string objName = (obj ?? new GameObject("Default")).name;
        Debug.Log("オブジェクト名：" + objName);
    }

    // ====================================
    // 【3】null条件演算子（?.）
    // ====================================
    void NullConditionalExamples()
    {
        Debug.Log("=== null条件演算子（?.）の例 ===");

        // 🔰 説明：
        // null参照例外（NullReferenceException）を防ぐための演算子です。
        // 「?.」を使うと、オブジェクトがnullでない時だけメソッドやプロパティが実行されます。
        // いちいち、if文で分岐しなくても、これを使えば結果を出す事が可能です。

        GameObject target = null;

        // 【パターン1】nullチェックせず安全にアクセス
        string targetName = target?.name ?? "未設定";
        Debug.Log("ターゲット名：" + targetName);

        // 【パターン2】コンポーネントの取得に使う（UIなどで便利）
        var text = target?.GetComponent<UnityEngine.UI.Text>();
        Debug.Log("Textコンポーネント取得：" + (text != null ? "成功" : "失敗"));

        // 【パターン3】関数呼び出しも安全に
        DummyObject dummy = null;
        dummy?.Show(); // nullでもエラーにならない
    }

    class DummyObject
    {
        public void Show()
        {
            Debug.Log("DummyObjectのShowが呼ばれました！");
        }
    }

    // ====================================
    // 【4】switch式（C# 7.0以降）※Unity2020以降推奨
    // ====================================
    void SwitchExpressionExamples()
    {
        Debug.Log("=== switch式の例（C#7以降） ===");

        // 説明：
        // 通常のswitch文よりも短く、値をそのまま返せる便利な新構文です。
        // 条件分岐しつつ、即座に値を渡すときに使います。
        // switchより手軽に、すぱっと結果を出す事が可能です。

        string rarity = "SSR";

        // 【パターン1】レアリティに応じた色名を返す
        string rarityColor = rarity switch
        {
            "N" => "白",
            "R" => "緑",
            "SR" => "青",
            "SSR" => "金",
            _ => "不明"
        };
        Debug.Log($"レアリティ：{rarity} → 色：{rarityColor}");

        // 【パターン2】曜日に応じたイベント
        string day = "日曜";
        string eventType = day switch
        {
            "月曜" => "訓練",
            "土曜" or "日曜" => "ボーナスバトル",
            _ => "通常任務"
        };
        Debug.Log($"今日は：{day} → イベント：{eventType}");

        // 【パターン3】数値に応じたランク判定
        int score = 92;
        string rank = score switch
        {
            >= 90 => "S",
            >= 75 => "A",
            >= 60 => "B",
            _ => "C"
        };
        Debug.Log($"スコア：{score} → ランク：{rank}");
    }
}
