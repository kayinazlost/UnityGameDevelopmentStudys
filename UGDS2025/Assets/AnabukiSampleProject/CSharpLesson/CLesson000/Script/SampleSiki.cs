using UnityEngine;

/// <summary>
/// C#の基本的な制御構文（if、switch、for、while、foreach）を学ぶスクリプト
/// 各構文に3例ずつ用意し、Debug.Logで分かりやすく表示
/// </summary>
public class SampleSiki : MonoBehaviour
{
    void Start()
    {
        //if文例
        ShowIfExamples();
        //Switch～Case文例
        ShowSwitchExamples();
        //for文例
        ShowForExamples();
        //While文例
        ShowWhileExamples();
        //Foreach文例
        ShowForeachExamples();
    }

    // ========================
    // if文の例
    // ========================
    void ShowIfExamples()
    {
        Debug.Log("==== if文の例 ====");

        int score = 80;

        ///基本的なif命令
        ///if(比較条件)で、条件が満たされている場合次の{ }内の処理が実行されます。
        ///{ }の処理が終了したら、そのままif命令処理は終了し、次の行のプログラムが実行されます。
        if (score >= 70)
        {
            Debug.Log("合格です！");
        }

        ///if～else
        ///if命令で比較条件がもし満たさない場合は、else{ }内の処理が実行されます。
        ///ある意味、選択肢のようなものと考えればいいでしょう
        if (score < 50)
        {
            Debug.Log("赤点です");
        }
        else
        {
            Debug.Log("大丈夫だ、問題ない。");
        }

        ///if ～ else if ～ else
        ///ちょっと特殊ですが、比較条件が満たされなかった際、次の新しい比較条件をチェックする事が可能
        ///この場合、スコアが、90以上か、それ以外か?で、もしそれ以外の場合、新しい条件として
        ///スコアが70以上か、それ以外かの分岐になります。
        ///勿論、同様にelse ifで繋げる事もできますが、条件文が長くなり見づらくなるのでお勧めしません。
        if (score >= 90)
        {
            Debug.Log("優秀！");
        }
        else if (score >= 70)
        {
            Debug.Log("良い成績！");
        }
        else
        {
            Debug.Log("一番いい成績で頼む。");
        }
    }

    // ========================
    // switch文の例
    // ========================
    void ShowSwitchExamples()
    {
        Debug.Log("==== switch文の例 ====");

        string rank = "B";

        ///switch文
        ///Switch文は、ifとは違い、比較する変数に対して該当するものを複数用意し分岐する方法
        ///下記の場合、ランクがAかBかCかそれ以外かでcaseで分岐しその結果を実行する。
        ///break;は処理を終了を意味し、ここでSwitch文の次のプログラムが実行される。
        switch (rank)
        {
            case "A":
                Debug.Log("最高ランク！");
                break;
            case "B":
                Debug.Log("いいランク！");
                break;
            case "C":
                Debug.Log("普通のランク");
                break;
            default:
                Debug.Log("ランク不明");
                break;
        }

        // Switch文は、文字だけではなくint型もfloat型も利用できる
        int day = 2;
        switch (day)
        {
            case 1:
                Debug.Log("月曜日");
                break;
            case 2:
                Debug.Log("火曜日");
                break;
            default:
                Debug.Log("その他の曜日");
                break;
        }

        ///複数caseをまとめる事もできる。
        ///この場合Keyが13、もしくは32の場合、同じ処理が実行される
        ///例えばKeyを武器種IDと考えれば違う武器種でも同じ処理を行うのと同様になる
        int key = 13;
        switch (key)
        {
            case 13:
            case 32:
                Debug.Log("Enterキーかスペースキーが押されました");
                break;
            default:
                Debug.Log("他のキーです");
                break;
        }
    }

    // ========================
    // for文の例
    // ========================
    void ShowForExamples()
    {
        Debug.Log("==== for文の例 ====");

        // パターン1：0から4までのループ
        ///繰り返し命令の定番であるfor命令
        ///特定の条件で繰り返す処理で、例えば、敵をx回出現させる等の事が出来る
        ///下記だと、5回{ }内の処理を繰り返す事になる。
        ///内訳は
        ///[int i=0]初期値設定で、iという変数に0を代入
        ///[i<5]比較チェック、iが5以下の場合繰り返し実行する事になり、満たしていなければforを終了させる
        ///[i++]繰り返し1巡毎にiの変数に1を加算する事になる
        ///
        for (int i = 0; i < 5; i++)
        {
            Debug.Log("i = " + i);
        }

        ///この場合は、1巡ごとに2が加算される。
        ///結果として5回繰り返すが、0、2、4、6、8となるので偶数を出す事になります。
        for (int i = 0; i <= 10; i += 2)
        {
            Debug.Log("偶数： " + i);
        }

        ///繰り返しは正順だけではなく逆順も可能。
        ///加算ではなく減算にすれば逆順になります、が!
        ///比較チェックも逆になる事を忘れずに!!
        ///忘れると【無限ループ地獄】という最悪のバグが発生します!!
        for (int i = 5; i > 0; i--)
        {
            Debug.Log("カウントダウン：" + i);
        }
    }

    // ========================
    // while文の例
    // ========================
    void ShowWhileExamples()
    {
        Debug.Log("==== while文の例 ====");

        int count = 0;

        ///While文はfor命令とは違い【条件が満たされている限り無限に繰り返す】命令です
        ///ネイティブでのゲーム開発では、このWhile文でプログラムをループさせる事でゲーム自体が終了処理しない限り
        ///終わらないようにしなければなりません、が!
        ///Unityは【んな、めどくせぇ事、なんでせにゃならん?!】というぐらい、ゲームループ処理無くてもループしてくれます、便利♪
        ///While文自体は、例えば建物を自動配置やアイテムは配置等の特定の条件が満たされるまで配置し続けるなどに向いていますが、
        ///実はとても危険な命令で【条件が沙汰されなくなることが無ければ永遠にループし続ける】ので無限ループ地獄が発生する事があります。
        ///要注意!
        while (count < 3)
        {
            Debug.Log("count = " + count);
            count++;
        }

        //While文は別にint型だけの条件では無ければならないわけではなく、bool等の正偽でも判断する事もできます。
        int value = 10;
        while (value < 5)
        {
            Debug.Log("表示されないはず");
        }

        ///While文の無限ループでも、breakにはかないません。
        ///breakがかかれば強制的にWhileループは中断できます。
        int total = 0;
        while (true)
        {
            total++;
            if (total == 3)
            {
                Debug.Log("3で終了");
                break;
            }
        }
    }

    // ========================
    // foreach文の例
    // ========================
    void ShowForeachExamples()
    {
        Debug.Log("==== foreach文の例 ====");

        string[] names = { "双月刹那", "双月遥", "双月永遠" };

        ///繰り返しで最も安全なおすすめ処理がForeach文
        ///for文のように途中からや、数値を飛ばしてや、逆順等は出来ない代わりに、無限ループせず格納されたリストや配列の要素数分必ず繰り返して処理できます。
        ///これで、ゲーム中に出現した敵リストの走査等もエラーなく楽々処理できます。
        foreach (string name in names)
        {
            Debug.Log("名前：" + name);
        }

        ///Foreach文の特徴の一つは「文字列」を「1文字ずつ」分解出来ます。
        ///よくゲームで、メッセージが一文字ずつ表示される演出があるけど、それで可能なんですね?
        string word = "Unity";
        foreach (char c in word)
        {
            Debug.Log("文字：" + c);
        }

        ///最後はリストによるループ解析
        ///リストに格納された要素分を全て洗い出せます
        var weapons = new System.Collections.Generic.List<string>() { "剣", "弓", "斧" };
        foreach (string weapon in weapons)
        {
            Debug.Log("武器：" + weapon);
        }
    }
}
