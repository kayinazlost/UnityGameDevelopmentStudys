using UnityEngine;

/// <summary>
/// CapsuleCastHit：CapsuleCastを使用し、指定方向に当たり判定を行う。
/// Z軸方向を進行方向とし、マウスX移動でY軸回転。
/// 当たったオブジェクトは赤に、離れると白に戻す。
/// </summary>
public class CapsuleCastHit : MonoBehaviour
{
    [Header("カプセルの半径")]
    public float m_CapsuleRadius = 0.5f;

    [Header("カプセルの高さ（Y軸方向）")]
    public float m_CapsuleHeight = 2.0f;

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
    [Header("最終ヒット地点")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // マウスXでY軸回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // カプセル始点・終点を算出
        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;
        Vector3 direction = transform.forward;

        // 前回のヒットオブジェクトを元の色に戻す
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // カプセルキャスト実行
        if (Physics.CapsuleCast(point1, point2, m_CapsuleRadius, direction, out RaycastHit hit, m_CastDistance, m_HitLayer))
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

    // ───────────────────────────────
    // 色変更処理
    // ───────────────────────────────
    private void SetObjectColor(GameObject obj, Color color)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
        {
            if (Application.isPlaying)
                rend.material.color = color;
            else
                rend.sharedMaterial.color = color;
        }
    }

    // ───────────────────────────────
    // Gizmo描画（カプセルキャスト線）
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;

        // カプセルライン表示（キャスト方向）
        Gizmos.DrawLine(point1, point1 + transform.forward * m_CastDistance);
        Gizmos.DrawLine(point2, point2 + transform.forward * m_CastDistance);

        // ヒット点表示
        Gizmos.DrawSphere(m_LastHitPoint, 0.1f);
    }
}
