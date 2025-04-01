using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// RaycastAllColorChanger：Z軸方向にRaycastAllを発射し、
/// 接触したすべてのオブジェクトを赤に、非接触時は白に戻す。
/// ギズモで最遠ヒット位置まで線を表示。X軸マウス移動でY軸回転。
/// </summary>
public class RaycastAllColorChanger : MonoBehaviour
{
    [Header("レイの長さ")]
    public float m_RayLength = 10f;

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
    [Header("前フレームのヒットオブジェクト一覧")]
    private List<GameObject> m_PreviousHits = new List<GameObject>();

    [SerializeField]
    [Header("レイが届いた最遠ヒット地点")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // オブジェクトをマウスXでY回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // RaycastAll 発射
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, m_RayLength, m_HitLayer);

        // 前回ヒットしていたが、今回ヒットしていないオブジェクトを白に戻す
        foreach (GameObject obj in m_PreviousHits)
        {
            if (!System.Array.Exists(hits, hit => hit.collider.gameObject == obj))
            {
                SetObjectColor(obj, m_DefaultColor);
            }
        }

        // 今回のヒットオブジェクトを赤にし、リスト更新
        m_CurrentHits.Clear();

        float maxDistance = 0f;
        m_LastHitPoint = transform.position + transform.forward * m_RayLength; // 初期：最遠点

        foreach (RaycastHit hit in hits)
        {
            GameObject obj = hit.collider.gameObject;
            m_CurrentHits.Add(obj);
            SetObjectColor(obj, m_HitColor);

            // 最も遠いヒットポイントを記録
            if (hit.distance > maxDistance)
            {
                maxDistance = hit.distance;
                m_LastHitPoint = hit.point;
            }
        }

        // ヒットリストを更新
        m_PreviousHits = new List<GameObject>(m_CurrentHits);
    }

    // ───────────────────────────────
    // 色変更（Renderer付きのオブジェクト）
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
    // ギズモ表示（レイ線：最遠ヒット地点まで）
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, m_LastHitPoint);
        Gizmos.DrawSphere(m_LastHitPoint, 0.1f);
    }
}
