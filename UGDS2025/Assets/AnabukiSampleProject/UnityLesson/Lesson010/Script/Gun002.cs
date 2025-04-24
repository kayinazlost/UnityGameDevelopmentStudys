using UnityEngine;
/// <summary>
/// Gun002：マウス左クリックで弾を発射するクラス。
/// 火薬量に応じたAddForceで飛距離が変化。生成した弾は5秒後に自動破棄される。
/// Rigidbodyがなければ自動で追加。
/// +
/// アイテムドロップ中にプレイヤーが触れる事で獲得
/// 獲得時に、プレイヤーのMount001クラス内に設定されているMountPointの向き、
/// 位置にこの銃が親子関係で結びつき、発砲可能状態になる。
/// また、以前に装備されている武器は、Mount001クラス側で廃棄されドロップする
/// アイテムドロップ中は、この武器は発砲する事は出来ない。
/// また、発砲にはキャラクター側にあるFireControlSystem001クラスから、
/// Mount001を通しての発砲指示が必要となる。
/// </summary>
public class Gun002 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
