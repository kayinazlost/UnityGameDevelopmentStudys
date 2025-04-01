using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// BoxCastAllHit�FBoxCastAll���g���đO���ɓ����蔻����΂��A
/// �ڐG�������ׂẴI�u�W�F�N�g�̐F��ԂɁA���ꂽ�甒�ɖ߂��B
/// �}�E�XX��Y����]�ABox�̌�����Z���B
/// </summary>
public class BoxCastAllHit : MonoBehaviour
{
    [Header("Box�T�C�Y�i���S����̔����j")]
    public Vector3 m_BoxHalfExtents = new Vector3(0.5f, 0.5f, 0.5f);

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
    [Header("�ŉ��q�b�g�_")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // �}�E�XX��Y����]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // BoxCastAll ���s
        Vector3 direction = transform.forward;
        Quaternion rotation = transform.rotation;
        RaycastHit[] hits = Physics.BoxCastAll(transform.position, m_BoxHalfExtents, direction, rotation, m_CastDistance, m_HitLayer);

        // �O��q�b�g������q�b�g���Ă��Ȃ� �� ���ɖ߂�
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
