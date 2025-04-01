using UnityEngine;

/// <summary>
/// SquareMove01：プレイヤーキャラクターなどのオブジェクトをWASDキーで移動させるクラス。
/// トランスレート（Translate）を使用し、Inputのアクシズで滑らかな移動を実現。
/// </summary>
public class SquareMove01 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示用） ※Header付き
    // ───────────────────────────────

    [Header("移動速度（ユニット/秒）")]
    public float m_MoveSpeed = 5.0f;

    // ───────────────────────────────
    // プライベート変数（インスペクターに表示） ※SerializeField付き
    // ───────────────────────────────

    [SerializeField]
    [Header("横方向の入力値")]
    private float m_Horizontal = 0f;

    [SerializeField]
    [Header("縦方向の入力値")]
    private float m_Vertical = 0f;

    // ───────────────────────────────
    // MonoBehaviour関数
    // ───────────────────────────────

    /// <summary>
    /// 毎フレーム移動処理を行う
    /// </summary>
    void Update()
    {
        // 入力取得
        m_Horizontal = Input.GetAxis("Horizontal");  // A/Dまたは←→
        m_Vertical = Input.GetAxis("Vertical");      // W/Sまたは↑↓

        // 移動方向ベクトルを作成
        Vector3 moveDirection = new Vector3(m_Horizontal, 0f, m_Vertical);

        // 正規化して方向を維持しながら速度を一定にする
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // トランスレートによる移動処理（ローカル座標系）
        transform.Translate(moveDirection * m_MoveSpeed * Time.deltaTime, Space.Self);
    }
}
