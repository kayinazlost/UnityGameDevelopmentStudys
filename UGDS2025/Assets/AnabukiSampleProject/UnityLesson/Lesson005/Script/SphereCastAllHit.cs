using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// SphereCastAllHit�FZ��������SphereCastAll���s���A
/// �q�b�g�����S�ẴI�u�W�F�N�g��ԂɁA���ꂽ�甒�ɖ߂��B�}�E�XX��Y��]�B
/// </summary>
public class SphereCastAllHit : MonoBehaviour
{
    [Header("���̔��a")]
    public float m_SphereRadius = 0.5f;

    [Header("�L���X�g����")]
    public float m_CastDistance = 5f;

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
    [Header("�ŉ��q�b�g�_")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // Y����]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        Vector3 direction = transform.forward;
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, m_SphereRadius, direction, m_CastDistance, m_HitLayer);

        // �O��q�b�g���Ă������A����q�b�g���Ă��Ȃ� �� �F��߂�
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
