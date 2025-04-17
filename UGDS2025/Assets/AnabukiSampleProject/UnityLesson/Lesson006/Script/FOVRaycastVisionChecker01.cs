using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// VisionConeRaycaster01�F���ςɂ�鎋��p����{���C�L���X�g�ɂ��A
/// �����Ă���I�u�W�F�N�g�̂ݐԁA�����Ȃ��I�u�W�F�N�g�͔��ɖ߂��B
/// Z����B�}�E�XX��Y����]�B�M�Y����X/Y����p���`��B
/// </summary>
public class VisionConeRaycaster01 : MonoBehaviour
{
    [Header("����p�i�����j")]
    public float m_HorizontalFOV = 90f;

    [Header("����p�i�����j")]
    public float m_VerticalFOV = 60f;

    [Header("���F����")]
    public float m_ViewDistance = 10f;

    [Header("�Ώۃ��C���[")]
    public LayerMask m_TargetLayer;

    [Header("��]���x�i�}�E�XX�j")]
    public float m_RotationSpeed = 100f;

    [Header("�q�b�g���̐F")]
    public Color m_VisibleColor = Color.red;

    [Header("��q�b�g���̐F")]
    public Color m_InvisibleColor = Color.white;

    [SerializeField]
    [Header("����Ώ�")]
    private List<GameObject> m_Targets = new List<GameObject>();

    [SerializeField]
    [Header("���F�����I�u�W�F�N�g")]
    private List<GameObject> m_VisibleTargets = new List<GameObject>();

    [SerializeField]
    [Header("���F�����I�u�W�F�N�g")]
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
        // �}�E�XX��Y����]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // ���F���ʃ��Z�b�g
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
            float dotY = Vector3.Dot(transform.forward, dir); // ����
            float dotX = Vector3.Dot(transform.up, dir);      // ����

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

    // ��������������������������������������������������������������
    // �O������^�[�Q�b�g�o�^
    // ��������������������������������������������������������������
    public void RegisterTarget(GameObject obj)
    {
        if (!m_Targets.Contains(obj)) m_Targets.Add(obj);
    }

    public void UnregisterTarget(GameObject obj)
    {
        if (m_Targets.Contains(obj)) m_Targets.Remove(obj);
    }

    // ��������������������������������������������������������������
    // �M�Y���F����p�\���iX/Y�������j
    // ��������������������������������������������������������������
    private void OnDrawGizmos()
    {
        Gizmos.color = m_EyeColor;
        Vector3 origin = transform.position;

        // X���������`
        int segments = 30;
        for (int i = -segments; i <= segments; i++)
        {
            float yaw = (m_HorizontalFOV / segments) * i * 0.5f;
            float pitch = 0f;
            Vector3 dir = Quaternion.Euler(pitch, yaw, 0f) * transform.forward;
            Gizmos.DrawLine(origin, origin + dir.normalized * m_ViewDistance);
        }

        // Y���������`
        for (int i = -segments; i <= segments; i++)
        {
            float yaw = 0f;
            float pitch = (m_VerticalFOV / segments) * i * 0.5f;
            Vector3 dir = Quaternion.Euler(pitch, yaw, 0f) * transform.forward;
            Gizmos.DrawLine(origin, origin + dir.normalized * m_ViewDistance);
        }
    }
}
