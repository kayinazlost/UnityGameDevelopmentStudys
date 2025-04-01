using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// VisionConeRaycaster01：内積による視野角判定＋レイキャストにより、
/// 見えているオブジェクトのみ赤、見えないオブジェクトは白に戻す。
/// Z軸基準。マウスXでY軸回転可。ギズモでX/Y視野角も描画。
/// </summary>
public class VisionConeRaycaster01 : MonoBehaviour
{
    [Header("視野角（水平）")]
    public float m_HorizontalFOV = 90f;

    [Header("視野角（垂直）")]
    public float m_VerticalFOV = 60f;

    [Header("視認距離")]
    public float m_ViewDistance = 10f;

    [Header("対象レイヤー")]
    public LayerMask m_TargetLayer;

    [Header("回転感度（マウスX）")]
    public float m_RotationSpeed = 100f;

    [Header("ヒット時の色")]
    public Color m_VisibleColor = Color.red;

    [Header("非ヒット時の色")]
    public Color m_InvisibleColor = Color.white;

    [SerializeField]
    [Header("判定対象")]
    private List<GameObject> m_Targets = new List<GameObject>();

    [SerializeField]
    [Header("視認成功オブジェクト")]
    private List<GameObject> m_VisibleTargets = new List<GameObject>();

    [SerializeField]
    [Header("視認成功オブジェクト")]
    private Color32 m_EyeColor;

    private void Start()
    {
        GameObject[] GO = GameObject.FindObjectsOfType<GameObject>();
        foreach (GameObject go in GO)
        {
            RegisterTarget(go);
        }
    }

    private void Update()
    {
        // マウスXでY軸回転
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // 視認結果リセット
        m_VisibleTargets.Clear();

        foreach (GameObject target in m_Targets)
        {
            if (target == null) continue;

            Vector3 toTarget = target.transform.position - transform.position;
            float distance = toTarget.magnitude;
            if (distance > m_ViewDistance)
            {
                SetObjectColor(target, m_InvisibleColor);
                continue;
            }

            Vector3 dir = toTarget.normalized;
            float dotY = Vector3.Dot(transform.forward, dir); // 水平
            float dotX = Vector3.Dot(transform.up, dir);      // 垂直

            float angleY = Mathf.Acos(dotY) * Mathf.Rad2Deg;
            float angleX = Mathf.Asin(dotX) * Mathf.Rad2Deg;

            if (angleY <= m_HorizontalFOV * 0.5f && Mathf.Abs(angleX) <= m_VerticalFOV * 0.5f)
            {
                if (Physics.Raycast(transform.position, dir, out RaycastHit hit, m_ViewDistance, m_TargetLayer))
                {
                    if (hit.collider.gameObject == target)
                    {
                        SetObjectColor(target, m_VisibleColor);
                        m_VisibleTargets.Add(target);
                        continue;
                    }
                }
            }

            SetObjectColor(target, m_InvisibleColor);
        }
    }

    private void SetObjectColor(GameObject obj, Color color)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
            rend.material.color = color;
    }

    // ───────────────────────────────
    // 外部からターゲット登録
    // ───────────────────────────────
    public void RegisterTarget(GameObject obj)
    {
        if (!m_Targets.Contains(obj)) m_Targets.Add(obj);
    }

    public void UnregisterTarget(GameObject obj)
    {
        if (m_Targets.Contains(obj)) m_Targets.Remove(obj);
    }

    // ───────────────────────────────
    // ギズモ：視野角表示（X/Y軸方向）
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Gizmos.color = m_EyeColor;
        Vector3 origin = transform.position;

        // X方向視野扇形
        int segments = 30;
        for (int i = -segments; i <= segments; i++)
        {
            float yaw = (m_HorizontalFOV / segments) * i * 0.5f;
            float pitch = 0f;
            Vector3 dir = Quaternion.Euler(pitch, yaw, 0f) * transform.forward;
            Gizmos.DrawLine(origin, origin + dir.normalized * m_ViewDistance);
        }

        // Y方向視野扇形
        for (int i = -segments; i <= segments; i++)
        {
            float yaw = 0f;
            float pitch = (m_VerticalFOV / segments) * i * 0.5f;
            Vector3 dir = Quaternion.Euler(pitch, yaw, 0f) * transform.forward;
            Gizmos.DrawLine(origin, origin + dir.normalized * m_ViewDistance);
        }
    }
}
