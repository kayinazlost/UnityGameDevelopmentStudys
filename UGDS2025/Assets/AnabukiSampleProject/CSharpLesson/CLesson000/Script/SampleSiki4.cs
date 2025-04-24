using UnityEngine;
using System;

/// <summary>
/// C#の高度な構文：delegate（デリゲート）、event（イベント）、ラムダ式の紹介
/// Unityで使う実例も交えて初心者向けに丁寧なレクチャー付きで解説
/// </summary>
public class SampleSiki4 : MonoBehaviour
{
    void Start()
    {
        //delegate（デリゲート）
        DelegateExamples();
        //event（イベント）
        EventExamples();
        //ラムダ式（無名関数）
        LambdaExamples();
    }

    // ====================================
    // 【1】delegate（デリゲート）の使い方
    // ====================================
    void DelegateExamples()
    {
        Debug.Log("=== delegate（デリゲート）の例 ===");

        // 説明：
        // delegate（デリゲート）は「関数を変数として扱えるしくみ」です。
        // つまり「どの処理を実行するかを、あとから変更できる関数ポインタ」のようなもの。
        // ボタンが押されたときに違う関数を呼びたい時など、非常に便利です。
        // いちいち、関数のかっこの中に書かなくてもいいのは楽でいい!
        // 最大の利点は、このデリゲートを利用して、他のクラスでもアクセスが可能になる。
        // C++のポインタの悪夢がこれで解消されるね!


        // 【パターン1】基本的なdelegate定義と実行
        // まずは、デリゲート型の関数定義を行い、greetを登録、以後greetが関数(兼変数)として扱う
        // greetに対して「SayHello」を代入すると、「SayHello」という関数がgreet(デリゲート型)に登録
        // greet();でgreetに登録された「SayHello」が実行される。
        // まぁ、一種のC++でいうポインタによる関数実行のようなものと考えておこう!
        MyDelegate greet = SayHello;
        //greet()で
        greet(); // ⇒ "こんにちは！"

        // 【パターン2】違う関数に切り替える
        // greetは現在「SayHello」の関数が登録されている。
        // これを「SayGoodbye」の関数に差し替える。
        // 以後、greet();を実行すると、「SayHello」ではなく、「SayGoodbye」の関数が実行される。
        greet = SayGoodbye;
        greet(); // ⇒ "さようなら！"

        // 【パターン3】引数付きのdelegate（Action<T>の代替）
        // 現在のgreetでは、変数の代入が出来ない、登録された関数のみだが…。
        // 引数を与える方法は至って簡単。「代入する関数自体に引数があるもの」を入れればok
        // 今回、別のデリゲートを用意し、greetingを作成し、「SayHelloTo」という
        // 引数付き関数を代入する。
        // この場合、greeting()の中に引数string型があるので「セツナ」を代入する事が可能。
        GreetingWithName greeting = SayHelloTo;
        greeting("セツナ");
    }

    // デリゲートの型定義
    delegate void MyDelegate();
    delegate void GreetingWithName(string name);

    /// <summary>
    /// デリゲートに代入されるただの関数
    /// 「こんにちは!」が表示される
    /// </summary>
    void SayHello()
    {
        Debug.Log("こんにちは！");
    }

    /// <summary>
    /// デリゲートに代入されるただの関数
    /// 「さようなら!」が表示される
    /// </summary>
    void SayGoodbye()
    {
        Debug.Log("さようなら！");
    }

    /// <summary>
    /// デリゲートに代入される引数付きの関数
    /// デリゲート側でstring型を代入すると、それが関数内で処理される
    /// 「こんにちは、〇〇〇〇さん」が表示される
    /// </summary>
    void SayHelloTo(string name)
    {
        Debug.Log("こんにちは、" + name + "さん！");
    }

    // ====================================
    // 【2】event（イベント）の使い方
    // ====================================
    void EventExamples()
    {
        Debug.Log("=== event（イベント）の例 ===");

        // 説明：
        // eventは「<外部から実行できないようにした>安全なdelegate」。
        // 「ある状況が起きたら通知したい」時に使われます。
        // ボタンが押された、敵を倒した、などのイベント発生時に登録された関数が呼ばれます。

        //エネミークラスを作成
        Enemy enemy = new Enemy();
        //エネミーの死亡(OnDeath)に対して、イベント登録を行う
        //この+=HandleEnemyDeath()する事で、
        //もし、エネミーが死亡した場合、OnDeath起動時
        //HandleEnemyDeath()関数が実行される。
        enemy.OnDeath += HandleEnemyDeath; // イベント登録
        //エネミーにダメージ100を与えると、TakeDamage経由で、
        //hpが100減り、0となり、そのままOnDeathがInvoke()が実行
        //これが発火点となってイベント「HandleEnemyDeath()」の関数が自動起動する
        enemy.TakeDamage(100); // HPが0になり、OnDeathが発火
    }

    /// <summary>
    /// 敵クラス（簡易）
    /// </summary>
    class Enemy
    {
        //敵クラスのHP
        public int hp = 100;

        // イベント定義（死亡時に通知）
        // これをしないと、イベントが実行できない
        public event Action OnDeath;

        /// <summary>
        /// ダメージを受ける際に実行される関数
        /// </summary>
        /// <param name="damage">ダメージ値</param>
        public void TakeDamage(int damage)
        {
            //hpに対して、damage分の値を減少
            hp -= damage;
            //damage値をコンソールに告知
            Debug.Log($"敵は {damage} のダメージを受けた（残りHP: {hp}）");
            //hpが0以下ならば
            if (hp <= 0)
            {
                //敵が倒れた事をコンソールで告知
                Debug.Log("敵は倒れた！");
                //イベントが発生(発火)但し、nullの場合起動しない
                OnDeath?.Invoke();
            }
        }
    }

    /// <summary>
    /// イベントが発生した際に実行する
    /// </summary>
    void HandleEnemyDeath()
    {
        //コンソールにメッセージを流す
        Debug.Log("→ 敵を倒した報酬を得る！");
    }

    // ====================================
    // 【3】ラムダ式（無名関数）の使い方
    // ====================================
    void LambdaExamples()
    {
        Debug.Log("=== ラムダ式（=>）の例 ===");

        // 説明：
        // ラムダ式とは「その場で書ける関数」。
        // 名前のない関数＝無名関数とも言います。
        // コードが短くなり、delegateやイベントと相性抜群！
        // いちいち関数を用意しなくても、その場で作れるのは楽でいいかもしれない?

        // 【パターン1】簡単な式形式
        // イベント(Actionの事)でgreetを作成
        // greetに対して無名関数定義で「Debug.Log("こんにちは from ラムダ！");」を
        // 内包する。これで、greetは、Debug.Log("こんにちは from ラムダ！");を表示する
        // 関数として稼働する事になる。
        Action greet = () => Debug.Log("こんにちは from ラムダ！");
        greet();

        // 【パターン2】引数あり
        // 引数ありでも同様、Actionに引数の変数を<>内に定義する事で、
        // 引数ありとして稼働する。
        Action<string> welcome = name => Debug.Log("ようこそ、" + name + "さん！");
        welcome("レイナ");

        // 【パターン3】return付き（Func）
        // 今度はreturnのような「戻り値」がある場合は、ActionではなくFuncを使用する。
        // この場合、2つのint型変数を代入し、int型として値を計算後返してくれる。
        Func<int, int, int> multiply = (a, b) => a * b;
        int result = multiply(3, 4);
        Debug.Log("3×4 = " + result);
    }
}
