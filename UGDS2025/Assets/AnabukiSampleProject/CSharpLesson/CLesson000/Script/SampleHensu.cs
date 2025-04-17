using UnityEngine;

/// <summary>
/// Unityで使われる様々な変数型の紹介と、Debug.Logによる出力例
/// 初心者向けの変数学習用スクリプト
/// </summary>

public class SampleHensu : MonoBehaviour
{
    /// <summary>
    /// スコアや、キャラクターのHp等のパラメーターでよく使う
    /// </summary>
    [Header("整数型（int）")]
    public int m_PlayerScore = 100;

    /// <summary>
    /// 小数点が使える変数、必ず最後にfをつける事
    /// </summary>
    [Header("小数点型（float）")]
    public float m_PlayerSpeed = 5.5f;

    /// <summary>
    /// 真・偽の2つしか判定できない変数
    /// ゲームが終了しているかや、銃がロックされているか等にも使う
    /// </summary>
    [Header("真偽型（bool）")]
    public bool m_IsGameOver = false;

    /// <summary>
    /// 半角英文字1文字分を格納できる変数
    /// Aやb等が格納できる
    /// </summary>
    [Header("文字型（char）")]
    public char m_Grade = 'A';

    /// <summary>
    /// Char型と違い、文字列が格納できる
    /// 武器の名前やキャラクター名、メッセージ文などに多用する
    /// </summary>
    [Header("文字列型（string）")]
    public string m_PlayerName = "カイン・アズロスト";

    /// <summary>
    /// 2Dゲームに於けるX軸Y軸を一つの変数で格納できるもの。
    /// 2DゲームやUI関係の制御などに利用できたり、最小値、最大値などの2元の数値を格納する事も可能
    /// </summary>
    [Header("2次元ベクトル（Vector2）")]
    public Vector2 m_MoveDirection2D = new Vector2(1.0f, 0.0f);

    /// <summary>
    /// 3Dゲームに於けるX軸Y軸Z軸を一つの変数で格納できるもの。
    /// 3Dゲームのキャラクター座標や、キャラクターの物理的な加速量等にも使える。
    /// </summary>
    [Header("3次元ベクトル（Vector3）")]
    public Vector3 m_Position = new Vector3(0, 1, 0);

    /// <summary>
    /// 色。それ以上もそれ以下もない、色。
    /// 色の設定の数値的なもので、Unityであれば、ちゃんとパレットが用意されている。
    /// 直接色を指定したい場合は、Color.色の名前(英語)でセットできる
    /// 他のタイプでColor32も存在し、半透明設定等も可能
    /// カラーコード順は【r,g,b,a】【赤,緑,青,透明度】
    /// </summary>
    [Header("カラー（Color）")]
    public Color m_PlayerColor = Color.red;

    /// <summary>
    /// ヒエラルキーや、プロジェクトで指定できるGameObjectを格納できる変数
    /// 出現させたいプレハブ(GameObject)を指定したり、破壊したいGameObjectの指定にも使える
    /// 利用価値が最も高い
    /// </summary>
    [Header("ゲームオブジェクト参照（GameObject）")]
    public GameObject m_TargetObject;

    /// <summary>
    /// ゲームオブジェクト内のTransformのコンポーネントとリンクする事が出来る変数
    /// ここにGameObjectをドラックすると、コンポーネントだけリンクする
    /// 対象のゲームオブジェクトを操作したり、座標位置を取得するのに役に立つ
    /// ターゲットとして利用したり、また下位にある子オブジェクトを割り出すにも使える
    /// </summary>
    [Header("Transformコンポーネント")]
    public Transform m_TargetTransform;

    /// <summary>
    /// 配列の事
    /// 複数の指定した数分の同一変数を格納できる。
    /// わかり易く言えば、学生が体育祭で整列している状態を思い浮かべよう!
    /// 戦闘から順番に該当する変数が格納されていると考えればわかり易い
    /// 但し、配列は、一度列数を決めてしまうと変更が不可能という欠点がある。
    /// </summary>
    [Header("配列（Array）")]
    public int[] m_Scores = new int[] { 10, 20, 30 }; // 複数の値を格納

    /// <summary>
    /// リストの事
    /// 私が最もこよなく愛してやまない最も使い勝手のいい奴。
    /// 見た目は変数と同じだが、列の途中から割り込む事も、必要ない列を削除して詰め上げる事も可能
    /// 但し、配列と違い実体がない為、配列で出来たプログラムが出来ない事もある。
    /// 私の場合は、敵の現在出現管理や、ゲーム中に飛んでいる弾を管理、敵として出現するモンスターリスト等に使っている。
    /// 東方プロジェクトで、ボス撃破後に飛び交っている弾幕が一気に消滅するのも、これを使っているから!
    /// </summary>
    [Header("リスト（List） ※using System.Collections.Genericが必要")]
    public System.Collections.Generic.List<string> m_Inventory = new System.Collections.Generic.List<string>() { "剣", "盾" };
    void Start()
    {
        // ======================
        // Debug.Logを使って、変数の内容を出力
        // ======================

        Debug.Log("【int】スコア：" + m_PlayerScore);
        Debug.Log("【float】スピード：" + m_PlayerSpeed);
        Debug.Log("【bool】ゲームオーバーか？：" + m_IsGameOver);
        Debug.Log("【char】成績：" + m_Grade);
        Debug.Log("【string】名前：" + m_PlayerName);
        Debug.Log("【Vector2】2D移動方向：" + m_MoveDirection2D);
        Debug.Log("【Vector3】3D座標：" + m_Position);
        Debug.Log("【Color】色：" + m_PlayerColor);
        //ちなみに、下の式で作ると、「もしGameObjectが設定されていなければ【未設定】と表示」される。
        //ミス回避等に使えるので覚えておこう!
        Debug.Log("【GameObject】対象オブジェクト：" + (m_TargetObject != null ? m_TargetObject.name : "未設定"));
        Debug.Log("【Transform】対象の位置：" + (m_TargetTransform != null ? m_TargetTransform.position.ToString() : "未設定"));

        //スコア配列で使用しているのはint型なので、string.Joinを使って、int型から文字列型に変換した上で、配列の数値を,で区切って連続表示している。
        Debug.Log("【Array】スコア配列：" + string.Join(",", m_Scores));
        //リストは、リスト名.Countとつけると、そのリストで登録されている総数が出ます。
        //これで、敵残機x機という風に表示できたりもします。
        Debug.Log("【List】インベントリアイテム数：" + m_Inventory.Count);
        //foreachを使えば、配列やリスト等の要素(含まれているものの事)を全てを洗い出す(繰り返し命令)ので
        //リストであれば、全てのリスト内に格納されたものを表示できます。
        foreach (string item in m_Inventory)
        {
            Debug.Log("　→ " + item);
        }

        // うんちく：C#ではすべての変数型はSystem.Objectを継承しています！
        // つまり、どんな変数も最終的には「オブジェクト」なのです。
        // C++よりやりやすいね♪
    }

}
