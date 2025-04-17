using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// BoxCastAllHit：BoxCastAllを使って前方に当たり判定を飛ばし、
/// 接触したすべてのオブジェクトの色を赤に、離れたら白に戻す。
/// マウスXでY軸回転、Boxの向きはZ軸。
/// </summary>
public class BoxCastAllHit : MonoBehaviour
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
    [Header("現在ヒット中のオブジェクト一覧")]
    private List<GameObject> m_CurrentHits = new List<GameObject>();

    [SerializeField]
    [Header("前回ヒットオブジェクト一覧")]
    private List<GameObject> m_PreviousHits = new List<GameObject>();

    [SerializeField]
    [Header("最遠ヒット点")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // マウスXでY軸回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // BoxCastAll 実行
        Vector3 direction = transform.forward;
        Quaternion rotation = transform.rotation;
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, m_BoxHalfExtents, direction, rotation, m_CastDistance, m_HitLayer);

        // 前回ヒット→今回ヒットしていない → 白に戻す
        foreach (GameObject obj in m_PreviousHits)
        {
            if (!System.Array.Exists(hits, h => h.collider.gameObject == obj))
            {
                SetObjectColor(obj, m_DefaultColor);
            }
        }

        m_CurrentHits.Clear();
        float maxDistance = 0f;
        m_LastHitPoint = transform.position + direction * m_CastDistance;

        foreach (RaycastHit hit in hits)
        {
            GameObject obj = hit.collider.gameObject;
            m_CurrentHits.Add(obj);
            SetObjectColor(obj, m_HitColor);

            if (hit.distance > maxDistance)
            {
                maxDistance = hit.distance;
                m_LastHitPoint = hit.point;
            }
        }

        m_PreviousHits = new List<GameObject>(m_CurrentHits);
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
