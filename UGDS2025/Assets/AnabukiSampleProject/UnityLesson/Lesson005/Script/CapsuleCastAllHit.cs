using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// CapsuleCastAllHit�FCapsuleCastAll��Z�������Ɋђʓ����蔻����s���A
/// �ڐG�����S�ẴI�u�W�F�N�g��ԂɁA���ꂽ�甒�ɖ߂��B�}�E�XX��Y����]�B
/// </summary>
public class CapsuleCastAllHit : MonoBehaviour
{
    [Header("�J�v�Z���̔��a")]
    public float m_CapsuleRadius = 0.5f;

    [Header("�J�v�Z���̍����iY���j")]
    public float m_CapsuleHeight = 2.0f;

    [Header("�L���X�g����")]
    public float m_CastDistance = 5.0f;

    [Header("��]���x�i�}�E�XX�j")]
    public float m_RotationSpeed = 100f;

    [Header("�q�b�g���̐F")]
    public Color m_HitColor = Color.red;

    [Header("��q�b�g���̐F")]
    public Color m_DefaultColor = Color.white;

    [Header("�Ώۃ��C���[")]
    public LayerMask m_HitLayer;

    [SerializeField]
    [Header("���݃q�b�g���̃I�u�W�F�N�g�ꗗ")]
    private List<GameObject> m_CurrentHits = new List<GameObject>();

    [SerializeField]
    [Header("�O��q�b�g�I�u�W�F�N�g�ꗗ")]
    private List<GameObject> m_PreviousHits = new List<GameObject>();

    [SerializeField]
    [Header("�ŉ��q�b�g�n�_")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // �}�E�XX��Y����]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // �J�v�Z���[�_�v�Z
        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;
        Vector3 direction = transform.forward;

        // CapsuleCastAll ���s
        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, m_CapsuleRadius, direction, m_CastDistance, m_HitLayer);

        // �O��q�b�g���Ă������A����q�b�g���Ă��Ȃ� �� �F�߂�
        foreach (GameObject obj in m_PreviousHits)
        {
            if (!System.Array.Exists(hits, hit => hit.collider.gameObject == obj))
            {
                SetObjectColor(obj, m_DefaultColor);
            }
        }

        // ����̃q�b�g�I�u�W�F�N�g����
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

    // ��������������������������������������������������������������
    // �ΏۃI�u�W�F�N�g�̐F��ύX
    // ��������������������������������������������������������������
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

    // ��������������������������������������������������������������
    // �M�Y���\���i�J�v�Z���L���X�g���j
    // ��������������������������������������������������������������
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
