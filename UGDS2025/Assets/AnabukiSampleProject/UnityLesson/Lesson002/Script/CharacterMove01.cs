using UnityEngine;

/// <summary>
/// CharacterMove01 ：Translateでの移動と、RigidbodyのAddForceを使ったジャンプ制御クラス。
/// ジャンプ中は移動不可。ジャンプは地面に接地している時のみ有効。方向入力と併用で方向付きジャンプ可。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove01 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示用）
    // ───────────────────────────────

    [Header("移動速度（ユニット/秒）")]
    public float m_MoveSpeed = 5.0f;

    [Header("ジャンプ力（加える上方向の力）")]
    public float m_JumpForce = 5.0f;

    [Header("接地判定の距離")]
    public float m_GroundCheckDistance = 1.1f;

    [Header("接地判定に使うレイヤー")]
    public LayerMask m_GroundLayer;

    // ───────────────────────────────
    // プライベート変数（インスペクターに表示）
    // ───────────────────────────────

    [SerializeField]
    [Header("横方向入力")]
    private float m_Horizontal = 0f;

    [SerializeField]
    [Header("縦方向入力")]
    private float m_Vertical = 0f;

    [SerializeField]
    [Header("接地しているか")]
    private bool m_IsGrounded = false;

    [SerializeField]
    [Header("Rigidbody参照")]
    private Rigidbody m_Rigidbody;

    // ───────────────────────────────
    // 初期化処理
    // ───────────────────────────────
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // ───────────────────────────────
    // 毎フレーム更新処理（入力取得＆移動）
    // ───────────────────────────────
    private void Update()
    {
        // 地面チェック
        m_IsGrounded = Physics.Raycast(transform.position, Vector3.down, m_GroundCheckDistance, m_GroundLayer);

        // 入力取得
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");

        // 移動（地面に接しているときのみ移動可能）
        if (m_IsGrounded)
        {
            Vector3 moveDir = new Vector3(m_Horizontal, 0f, m_Vertical).normalized;
            transform.Translate(moveDir * m_MoveSpeed * Time.deltaTime, Space.World);
        }

        // ジャンプ入力（地上時のみ）
        if (m_IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpDir = new Vector3(m_Horizontal, 1f, m_Vertical).normalized;
            m_Rigidbody.AddForce(jumpDir * m_JumpForce, ForceMode.Impulse);
        }
    }

    // ───────────────────────────────
    // デバッグ用ギズモ描画（地面チェック線）
    // ───────────────────────────────
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * m_GroundCheckDistance);
    }
}
