using UnityEngine;

/// <summary>
/// MouseLook360：マウスの左右と上下の移動に応じて、オブジェクトを360度回転させる視点制御クラス。
/// 通常はキャラ本体がYaw（Y軸）、カメラがPitch（X軸）を担当するが、このクラスは両方一括で回転制御できる。
/// </summary>
public class MouseLook360 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示用） ※Header付き
    // ───────────────────────────────

    [Header("回転感度（マウス感度）")]
    public float m_MouseSensitivity = 3.0f;

    [Header("ピッチの最小角度（上向き制限）")]
    public float m_MinPitch = -60f;

    [Header("ピッチの最大角度（下向き制限）")]
    public float m_MaxPitch = 60f;

    // ───────────────────────────────
    // プライベート変数（インスペクターに表示） ※SerializeField付き
    // ───────────────────────────────

    [SerializeField]
    [Header("マウスX軸の移動量")]
    private float m_MouseX = 0f;

    [SerializeField]
    [Header("マウスY軸の移動量")]
    private float m_MouseY = 0f;

    [SerializeField]
    [Header("現在のYaw（Y軸回転角）")]
    private float m_Yaw = 0f;

    [SerializeField]
    [Header("現在のPitch（X軸回転角）")]
    private float m_Pitch = 0f;

    // ───────────────────────────────
    // 毎フレームの更新処理
    // ───────────────────────────────
    private void Update()
    {
        // マウスの移動量を取得
        m_MouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity;
        m_MouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity;

        // 回転角度を加算
        m_Yaw += m_MouseX;
        m_Pitch -= m_MouseY; // 上方向はマイナスにすることで直感的な動きに

        // Pitchを制限
        m_Pitch = Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);

        // 回転を適用（Z軸は使わない）
        transform.localEulerAngles = new Vector3(m_Pitch, m_Yaw, 0f);
    }
}
