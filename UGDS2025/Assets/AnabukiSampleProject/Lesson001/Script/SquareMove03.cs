using UnityEngine;

/// <summary>
/// SquareMove03：Transform.positionの増減によって移動するクラス。
/// Rigidbody等を使用せず、スクリプト単独でシンプルに座標を変更して動かす。
/// </summary>
public class SquareMove03 : MonoBehaviour
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
    // 毎フレーム更新処理
    // ───────────────────────────────
    private void Update()
    {
        // 入力取得
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");

        // 移動方向を計算
        Vector3 moveDirection = new Vector3(m_Horizontal, 0f, m_Vertical).normalized;

        // 現在の位置に加算
        transform.position += moveDirection * m_MoveSpeed * Time.deltaTime;
    }
}
