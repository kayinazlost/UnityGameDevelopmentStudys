using UnityEngine;

/// <summary>
/// SphereCastHit：Z軸方向にSphereCastを行い、
/// ヒットしたオブジェクトの色を赤に、離れたら白に戻す。マウスXでY回転。
/// </summary>
public class SphereCastHit : MonoBehaviour
{
    [Header("球の半径")]
    public float m_SphereRadius = 0.5f;

    [Header("キャスト距離")]
    public float m_CastDistance = 5f;

    [Header("回転感度（マウスX）")]
    public float m_RotationSpeed = 100f;

    [Header("ヒット時の色")]
    public Color m_HitColor = Color.red;

    [Header("非ヒット時の色")]
    public Color m_DefaultColor = Color.white;

    [Header("対象レイヤー")]
    public LayerMask m_HitLayer;

    [SerializeField]
    [Header("ヒット中のオブジェクト")]
    private GameObject m_CurrentHitObject = null;

    [SerializeField]
    [Header("ヒット地点")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // Y軸回転（マウスX）
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        Vector3 direction = transform.forward;

        // 前回のヒットオブジェクトを元に戻す
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // SphereCast 実行
        if (Physics.SphereCast(transform.position, m_SphereRadius, direction, out RaycastHit hit, m_CastDistance, m_HitLayer))
        {
            m_CurrentHitObject = hit.collider.gameObject;
            SetObjectColor(m_CurrentHitObject, m_HitColor);
            m_LastHitPoint = hit.point;
        }
        else
        {
            m_LastHitPoint = transform.position + direction * m_CastDistance;
        }
    }

    private void SetObjectColor(GameObject obj, Color color)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = color;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, m_LastHitPoint);
        Gizmos.DrawSphere(m_LastHitPoint, 0.1f);
    }
}
