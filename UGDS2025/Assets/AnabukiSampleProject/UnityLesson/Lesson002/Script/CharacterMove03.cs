using UnityEngine;

/// <summary>
/// CharacterMove03：AddForceによってキャラクターを移動・ジャンプさせる完全物理制御クラス。
/// ジャンプ中は移動・重力を無効化。最大速度を超えないよう制限。CharacterControllerは使用不可。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove03 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示）
    // ───────────────────────────────

    [Header("移動力（AddForceに使う力）")]
    public float m_MoveForce = 30f;

    [Header("最大移動速度（ユニット/秒）")]
    public float m_MaxMoveSpeed = 5f;

    [Header("ジャンプ力（方向付きジャンプに使う力）")]
    public float m_JumpForce = 8f;

    [Header("最大ジャンプ速度（初速度の上限）")]
    public float m_MaxJumpSpeed = 6f;

    [Header("接地判定距離")]
    public float m_GroundCheckDistance = 1.1f;

    [Header("地面レイヤー")]
    public LayerMask m_GroundLayer;

    // ───────────────────────────────
    // プライベート変数（インスペクター表示）
    // ───────────────────────────────

    [SerializeField]
    [Header("現在の移動入力（X,Z）")]
    private Vector3 m_InputDir = Vector3.zero;

    [SerializeField]
    [Header("現在接地しているか")]
    private bool m_IsGrounded = false;

    [SerializeField]
    [Header("ジャンプ中かどうか")]
    private bool m_IsJumping = false;

    [SerializeField]
    [Header("Rigidbody参照")]
    private Rigidbody m_Rigidbody;

    // ───────────────────────────────
    // 初期化
    // ───────────────────────────────
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = true;
    }

    // ───────────────────────────────
    // 毎フレーム：入力とジャンプ処理
    // ───────────────────────────────
    private void Update()
    {
        // 入力取得
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        m_InputDir = new Vector3(h, 0f, v).normalized;

        // 接地判定
        m_IsGrounded = Physics.Raycast(transform.position, Vector3.down, m_GroundCheckDistance, m_GroundLayer);

        // ジャンプ入力判定（地面上 & 非ジャンプ中）
        if (m_IsGrounded && !m_IsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            // ジャンプ中フラグ
            m_IsJumping = true;

            // 重力一時無効化（AddForceジャンプのみに従う）
            m_Rigidbody.useGravity = false;

            // ジャンプ方向：入力＋上方向
            Vector3 jumpDir = (m_InputDir + Vector3.up).normalized;

            // 現在の速度をクリアしてジャンプ
            m_Rigidbody.linearVelocity = Vector3.zero;
            m_Rigidbody.AddForce(jumpDir * m_JumpForce, ForceMode.Impulse);
        }
    }

    // ───────────────────────────────
    // FixedUpdate：物理移動とジャンプ管理
    // ───────────────────────────────
    private void FixedUpdate()
    {
        // ジャンプ中でないときだけ移動可能
        if (!m_IsJumping && m_IsGrounded)
        {
            // 最大速度制限
            Vector3 horizontalVel = new Vector3(m_Rigidbody.linearVelocity.x, 0f, m_Rigidbody.linearVelocity.z);

            if (horizontalVel.magnitude < m_MaxMoveSpeed)
            {
                m_Rigidbody.AddForce(m_InputDir * m_MoveForce, ForceMode.Force);
            }
        }

        // ジャンプ中速度制限（ジャンプ初速制限）
        if (m_IsJumping)
        {
            if (m_Rigidbody.linearVelocity.magnitude > m_MaxJumpSpeed)
            {
                m_Rigidbody.linearVelocity = m_Rigidbody.linearVelocity.normalized * m_MaxJumpSpeed;
            }
        }

        // 着地判定：接地時にジャンプ解除
        if (m_IsJumping && m_IsGrounded)
        {
            m_IsJumping = false;
            m_Rigidbody.useGravity = true; // 重力を再び有効化
        }
    }

    // ───────────────────────────────
    // デバッグ用：接地線表示
    // ───────────────────────────────
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * m_GroundCheckDistance);
    }
}
