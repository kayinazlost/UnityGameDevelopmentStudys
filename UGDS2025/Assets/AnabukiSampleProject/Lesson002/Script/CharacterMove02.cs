using UnityEngine;

/// <summary>
/// VelocityJumpMove01：Rigidbodyのvelocityを用いたキャラクター移動と、
/// AddForceによる方向付きジャンプを制御するクラス。ジャンプ中は移動・重力を無効化。
/// 地面接地時のみジャンプ可能。キャラクターコントローラー非使用。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class VelocityJumpMove01 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示）
    // ───────────────────────────────

    [Header("移動速度（ユニット/秒）")]
    public float m_MoveSpeed = 5.0f;

    [Header("ジャンプ力（加える力の大きさ）")]
    public float m_JumpForce = 7.5f;

    [Header("接地判定距離")]
    public float m_GroundCheckDistance = 1.1f;

    [Header("地面レイヤー")]
    public LayerMask m_GroundLayer;

    // ───────────────────────────────
    // プライベート変数（インスペクター表示）
    // ───────────────────────────────

    [SerializeField]
    [Header("横方向入力値")]
    private float m_Horizontal = 0f;

    [SerializeField]
    [Header("縦方向入力値")]
    private float m_Vertical = 0f;

    [SerializeField]
    [Header("接地状態")]
    private bool m_IsGrounded = false;

    [SerializeField]
    [Header("ジャンプ中か")]
    private bool m_IsJumping = false;

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
    // 毎フレーム更新処理（入力＋ジャンプ）
    // ───────────────────────────────
    private void Update()
    {
        // 入力取得
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");

        // 地面に接地しているか確認
        m_IsGrounded = Physics.Raycast(transform.position, Vector3.down, m_GroundCheckDistance, m_GroundLayer);

        // 地上にいてジャンプキーが押された場合
        if (m_IsGrounded && !m_IsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            // 移動入力＋上方向でジャンプ方向を決定
            Vector3 jumpDir = new Vector3(m_Horizontal, 1f, m_Vertical).normalized;

            // Rigidbodyの速度をリセットしてジャンプ（方向付き）
            m_Rigidbody.linearVelocity = Vector3.zero;
            m_Rigidbody.AddForce(jumpDir * m_JumpForce, ForceMode.Impulse);

            // ジャンプ中フラグを立てる
            m_IsJumping = true;
        }
    }

    // ───────────────────────────────
    // FixedUpdate：物理演算に基づく移動とジャンプ管理
    // ───────────────────────────────
    private void FixedUpdate()
    {
        if (m_IsJumping)
        {
            // ジャンプ中は移動・重力を無効化（velocity固定）
            m_Rigidbody.linearVelocity = Vector3.zero;
        }
        else if (m_IsGrounded)
        {
            // 通常移動（地面にいる場合のみ）
            Vector3 moveDir = new Vector3(m_Horizontal, 0f, m_Vertical).normalized;
            Vector3 velocity = moveDir * m_MoveSpeed;
            velocity.y = m_Rigidbody.linearVelocity.y; // 縦の速度は保持
            m_Rigidbody.linearVelocity = velocity;
        }

        // 着地したらジャンプフラグを戻す
        if (m_IsJumping && m_IsGrounded)
        {
            m_IsJumping = false;
        }
    }

    // ───────────────────────────────
    // ギズモ（接地線）描画
    // ───────────────────────────────
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * m_GroundCheckDistance);
    }
}
