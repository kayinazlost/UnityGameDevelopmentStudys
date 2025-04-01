using UnityEngine;

/// <summary>
/// RaycastColorChanger：Z軸方向にレイキャストを発射し、
/// ヒットしたオブジェクトの色を赤に、それ以外を白に変更。
/// レイはマウスX移動でY軸回転可能。ギズモで可視化。
/// </summary>
public class RaycastColorChanger : MonoBehaviour
{
    [Header("レイの長さ")]
    public float m_RayLength = 10f;

    [Header("回転感度（マウス感度）")]
    public float m_RotationSpeed = 100f;

    [Header("接触時の色")]
    public Color m_HitColor = Color.red;

    [Header("非接触時の色")]
    public Color m_DefaultColor = Color.white;

    [Header("レイヤーマスク（ヒット対象）")]
    public LayerMask m_HitLayer;

    [SerializeField]
    [Header("現在のヒットオブジェクト")]
    private GameObject m_CurrentHitObject = null;

    private void Update()
    {
        // マウスXでY軸回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // レイキャスト発射
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // 現在のヒットオブジェクトがあれば色を元に戻す
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // 接触したら色変更
        if (Physics.Raycast(ray, out hit, m_RayLength, m_HitLayer))
        {
            m_CurrentHitObject = hit.collider.gameObject;
            SetObjectColor(m_CurrentHitObject, m_HitColor);
        }
    }

    // ───────────────────────────────
    // 指定オブジェクトのマテリアル色変更
    // ───────────────────────────────
    private void SetObjectColor(GameObject obj, Color color)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
        {
            // マテリアルインスタンス化で他と共有しないようにする
            if (Application.isPlaying)
                rend.material.color = color;
            else
                rend.sharedMaterial.color = color;
        }
    }

    // ───────────────────────────────
    // ギズモによるレイ可視化
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_RayLength, m_HitLayer))
        {
            // ヒット位置まで描画
            Gizmos.DrawLine(transform.position, hit.point);
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
        else
        {
            // 最大距離まで描画
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * m_RayLength);
        }
    }
}
