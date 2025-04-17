using UnityEngine;

/// <summary>
/// MouseRotate01：マウスの移動によってキャラクターを左右に回転させるクラス。
/// カメラではなく、プレイヤー本体（キャラモデルなど）のYaw方向の回転を制御。
/// </summary>
public class MouseRotate01 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示用） ※Header付き
    // ───────────────────────────────

    [Header("回転感度（大きいほど速く回転）")]
    public float m_MouseSensitivity = 3.0f;

    // ───────────────────────────────
    // プライベート変数（インスペクターに表示） ※SerializeField付き
    // ───────────────────────────────

    [SerializeField]
    [Header("マウスX軸の移動量")]
    private float m_MouseX = 0f;

    [SerializeField]
    [Header("現在の回転角度（Y軸）")]
    private float m_CurrentYRotation = 0f;

    // ───────────────────────────────
    // 毎フレームの更新処理
    // ───────────────────────────────
    private void Update()
    {
        // マウスX軸の移動量を取得
        m_MouseX = Input.GetAxis("Mouse X");

        // 回転角度に変換
        m_CurrentYRotation += m_MouseX * m_MouseSensitivity;

        // 回転を適用（Y軸だけ変化）
        transform.eulerAngles = new Vector3(0f, m_CurrentYRotation, 0f);
    }
}
