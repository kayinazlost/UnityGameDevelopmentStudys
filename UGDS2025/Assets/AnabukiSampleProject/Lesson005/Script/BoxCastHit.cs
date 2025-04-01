using UnityEngine;

/// <summary>
/// BoxCastHit：BoxCastを使って前方に当たり判定を飛ばし、
/// 接触したオブジェクトの色を赤に、離れたら白に戻す。
/// マウスXでY軸回転、Boxの向きはZ軸。
/// </summary>
public class BoxCastHit : MonoBehaviour
{
    [Header("Boxサイズ（中心からの半分）")]
    public Vector3 m_BoxHalfExtents = new Vector3(0.5f, 0.5f, 0.5f);

    [Header("キャスト距離")]
    public float m_CastDistance = 5.0f;

    [Header("回転感度（マウスX）")]
    public float m_RotationSpeed = 100f;

    [Header("ヒット時の色")]
    public Color m_HitColor = Color.red;

    [Header("非ヒット時の色")]
    public Color m_DefaultColor = Color.white;

    [Header("対象レイヤー")]
    public LayerMask m_HitLayer;

    [SerializeField]
    [Header("現在ヒット中のオブジェクト")]
    private GameObject m_CurrentHitObject = null;

    [SerializeField]
    [Header("最終ヒット位置")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // マウスXで回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // BoxCast開始点と向き
        Vector3 direction = transform.forward;
        Quaternion rotation = transform.rotation;

        // 色リセット
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // キャスト実行
        if (Physics.BoxCast(transform.position, m_BoxHalfExtents, direction, out RaycastHit hit, rotation, m_CastDistance, m_HitLayer))
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
