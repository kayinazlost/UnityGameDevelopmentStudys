using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// 発展型の変数を紹介するサンプルスクリプト
/// 状態管理や複雑なデータ構造の実用例を含む
/// </summary>
public class SampleHensu2 : MonoBehaviour
{
    /// <summary>
    /// 【1】enum（列挙型）
    /// 列挙型は、順番で設定されたものがIDを付与されているもの
    /// 下記のものであれば、IdleはID0番、RunningはID1番となる。
    /// ゲームの攻略サイトや設定集などで武器種のID番号とかがこれに該当する。
    /// 下記のものであれば、敵AIの状態等に使うケースだ。
    /// </summary>
    public enum PlayerState
    {
        Idle,
        Running,
        Jumping,
        Dead
    }

    /// <summary>
    /// enumを実際使うならば、一旦変数として定義する必要がある。
    /// その上で、いちいちID番号を代入せずとも、enum型.ID名でIDを付与可能。
    /// 以外と、この方法であればプログラムミスを省けたりもする。
    /// enumの設定を静的変数にすれば、他のクラスでも使用可能だ。
    /// </summary>
    [Header("現在のプレイヤー状態")]
    public PlayerState m_CurrentState = PlayerState.Idle;

    /// <summary>
    /// 【2】struct（構造体）
    /// ゲームを作るならば避けては通れないもの。
    /// 簡単に言えば、複数の違った変数型を内包した変数を作る事が出来る。
    /// 例えば、キャラクターのパラメーターなど、名前(string)やLv(Int)等
    /// それぞれ別々のものを個別で管理するよりも、1つに纏めて管理した方が楽だろう?
    /// この場合だと、キャラクター.HpでそのキャラクターのHpを増減できるようになる。
    /// </summary>
    public struct Status
    {
        public int hp;
        public int mp;

        public Status(int hp, int mp)
        {
            this.hp = hp;
            this.mp = mp;
        }
    }
    /// <summary>
    /// こっちが実際の構造体を使った変数
    /// プレイヤーキャラクターのStatusがhpとmpだけなので、代入しやすいように
    /// 構造体内にStatusという関数を設けて一気に代入しやすくしている。
    /// これで、このキャラクターのHpは100、Mpは50となる。
    /// </summary>
    private Status m_PlayerStatus = new Status(100, 50);

    /// <summary>
    /// 【3】[System.Serializable] クラス
    /// え?構造体はめどい??
    /// じゃあ、クラスを使って構造体の代わりを作ってみよう。
    /// これで同様なこともできるぞ?
    /// </summary>
    [System.Serializable]
    public class Weapon
    {
        public string name;
        public int power;
    }

    [Header("装備中の武器")]
    public Weapon m_EquippedWeapon = new Weapon { name = "ブレード", power = 25 };

    /// <summary>
    /// 【4】Dictionary（辞書型）
    /// ディクショナリーという。
    /// これは、2つの変数で管理できるようにするもの。
    /// 下記の用に、アイテム名とその所持数を管理する事に便利だ。
    /// </summary>
    private Dictionary<string, int> m_ItemCounts = new Dictionary<string, int>()
    {
        { "ポーション", 3 },
        { "エリクサー", 1 }
    };

    /// <summary>
    /// 【5】Nullable（null許容型）
    /// nullは便利だが要注意。
    /// nullは【無い】【存在しない】等と同じ
    /// 例えば変数を代入していなければ基本nullと同じ。
    /// 変数の初期代入はやっておきましょう。
    /// </summary>
    private int? m_LastDamageTaken = null; // ダメージを受けていない場合null

    void Start()
    {
        Debug.Log("【enum】現在のプレイヤー状態：" + m_CurrentState.ToString());

        Debug.Log("【struct】HP：" + m_PlayerStatus.hp + " / MP：" + m_PlayerStatus.mp);

        Debug.Log("【Serializable Class】武器名：" + m_EquippedWeapon.name + "（威力：" + m_EquippedWeapon.power + "）");

        Debug.Log("【Dictionary】所持アイテム：");
        foreach (var item in m_ItemCounts)
        {
            Debug.Log("　→ " + item.Key + " x" + item.Value);
        }

        Debug.Log("【Nullable】最後に受けたダメージ：" + (m_LastDamageTaken.HasValue ? m_LastDamageTaken.ToString() : "まだ受けていない"));
    }
}
