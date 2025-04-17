using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// CapsuleCastAllHit：CapsuleCastAllでZ軸方向に貫通当たり判定を行い、
/// 接触した全てのオブジェクトを赤に、離れたら白に戻す。マウスXでY軸回転可。
/// </summary>
public class CapsuleCastAllHit : MonoBehaviour
{
    [Header("カプセルの半径")]
    public float m_CapsuleRadius = 0.5f;

    [Header("カプセルの高さ（Y軸）")]
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
    [Header("現在ヒット中のオブジェクト一覧")]
    private List<GameObject> m_CurrentHits = new List<GameObject>();

    [SerializeField]
    [Header("前回ヒットオブジェクト一覧")]
    private List<GameObject> m_PreviousHits = new List<GameObject>();

    [SerializeField]
    [Header("最遠ヒット地点")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // マウスXでY軸回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // カプセル端点計算
        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;
        Vector3 direction = transform.forward;

        // CapsuleCastAll 実行
        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, m_CapsuleRadius, direction, m_CastDistance, m_HitLayer);

        // 前回ヒットしていたが、今回ヒットしていない → 色戻す
        foreach (GameObject obj in m_PreviousHits)
        {
            if (!System.Array.Exists(hits, hit => hit.collider.gameObject == obj))
            {
                SetObjectColor(obj, m_DefaultColor);
            }
        }

        // 今回のヒットオブジェクト処理
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

    // ───────────────────────────────
    // 対象オブジェクトの色を変更
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
    // ギズモ表示（カプセルキャスト線）
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;

        Gizmos.DrawLine(point1, point1 + transform.forward * m_CastDistance);
        Gizmos.DrawLine(point2, point2 + transform.forward * m_CastDistance);
        Gizmos.DrawSphere(m_LastHitPoint, 0.1f);
    }
}
