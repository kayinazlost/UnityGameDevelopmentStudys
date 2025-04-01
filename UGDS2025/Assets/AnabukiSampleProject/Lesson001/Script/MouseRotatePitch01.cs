using UnityEngine;

/// <summary>
/// MouseRotatePitch01：マウスの前後（Y軸）移動でX軸回転（ピッチ）を行うクラス。
/// 一般的にはカメラや上半身の上下向きを制御する用途に使用される。
/// </summary>
public class MouseRotatePitch01 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示用） ※Header付き
    // ───────────────────────────────

    [Header("回転感度（大きいほど速く上下に向く）")]
    public float m_MouseSensitivity = 3.0f;

    [Header("上下回転の最小角度（上を向く制限）")]
    public float m_MinPitch = -60f;

    [Header("上下回転の最大角度（下を向く制限）")]
    public float m_MaxPitch = 60f;

    // ───────────────────────────────
    // プライベート変数（インスペクターに表示） ※SerializeField付き
    // ───────────────────────────────

    [SerializeField]
    [Header("マウスY軸の移動量")]
    private float m_MouseY = 0f;

    [SerializeField]
    [Header("現在のX軸回転角（ピッチ）")]
    private float m_CurrentXRotation = 0f;

    // ───────────────────────────────
    // 毎フレームの更新処理
    // ───────────────────────────────
    private void Update()
    {
        // マウスY軸の移動量を取得（※上下反転のため - を付けるのが一般的）
        m_MouseY = Input.GetAxis("Mouse Y");

        // 入力に応じてX軸回転を加算（前に倒すと下を向く）
        m_CurrentXRotation -= m_MouseY * m_MouseSensitivity;

        // 上下回転角を制限（クランプ）
        m_CurrentXRotation = Mathf.Clamp(m_CurrentXRotation, m_MinPitch, m_MaxPitch);

        // 回転を適用（X軸のみ回転）
        transform.localEulerAngles = new Vector3(m_CurrentXRotation, 0f, 0f);
    }
}
