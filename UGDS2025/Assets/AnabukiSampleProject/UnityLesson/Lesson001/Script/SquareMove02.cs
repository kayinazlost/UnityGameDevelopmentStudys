using UnityEngine;

/// <summary>
/// SquareMove02：Rigidbodyのvelocityを利用してWASD移動するクラス。
/// 物理演算を使用し、トランスレートと同等のスピードで滑らかに動作する。
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class SquareMove02 : MonoBehaviour
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

    [SerializeField]
    [Header("キャラクターのRigidbody")]
    private Rigidbody m_Rigidbody;

    // ───────────────────────────────
    // 初期化処理
    // ───────────────────────────────
    private void Awake()
    {
        // Rigidbodyの取得（Inspector未設定時に自動で取得）
        if (m_Rigidbody == null)
        {
            m_Rigidbody = GetComponent<Rigidbody>();
        }
    }

    // ───────────────────────────────
    // 毎フレームの更新処理
    // ───────────────────────────────
    private void Update()
    {
        // 入力取得
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");
    }

    // ───────────────────────────────
    // 物理演算による移動処理（固定フレーム）
    // ───────────────────────────────
    private void FixedUpdate()
    {
        // 入力方向ベクトルを計算
        Vector3 velocity = new Vector3(m_Horizontal, 0, m_Vertical) * m_MoveSpeed;

        // Rigidbodyの速度に代入（X,Z方向のみ移動）
        m_Rigidbody.linearVelocity = new Vector3(velocity.x, m_Rigidbody.linearVelocity.y, velocity.z);
    }
}
