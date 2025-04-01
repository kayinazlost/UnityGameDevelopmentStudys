using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// RaycastAllColorChanger�FZ��������RaycastAll�𔭎˂��A
/// �ڐG�������ׂẴI�u�W�F�N�g��ԂɁA��ڐG���͔��ɖ߂��B
/// �M�Y���ōŉ��q�b�g�ʒu�܂Ő���\���BX���}�E�X�ړ���Y����]�B
/// </summary>
public class RaycastAllColorChanger : MonoBehaviour
{
    [Header("���C�̒���")]
    public float m_RayLength = 10f;

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
    [Header("�O�t���[���̃q�b�g�I�u�W�F�N�g�ꗗ")]
    private List<GameObject> m_PreviousHits = new List<GameObject>();

    [SerializeField]
    [Header("���C���͂����ŉ��q�b�g�n�_")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // �I�u�W�F�N�g���}�E�XX��Y��]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // RaycastAll ����
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit[] hits = Physics.RaycastAll(ray, m_RayLength, m_HitLayer);

        // �O��q�b�g���Ă������A����q�b�g���Ă��Ȃ��I�u�W�F�N�g�𔒂ɖ߂�
        foreach (GameObject obj in m_PreviousHits)
        {
            if (!System.Array.Exists(hits, hit => hit.collider.gameObject == obj))
            {
                SetObjectColor(obj, m_DefaultColor);
            }
        }

        // ����̃q�b�g�I�u�W�F�N�g��Ԃɂ��A���X�g�X�V
        m_CurrentHits.Clear();

        float maxDistance = 0f;
        m_LastHitPoint = transform.position + transform.forward * m_RayLength; // �����F�ŉ��_

        foreach (RaycastHit hit in hits)
        {
            GameObject obj = hit.collider.gameObject;
            m_CurrentHits.Add(obj);
            SetObjectColor(obj, m_HitColor);

            // �ł������q�b�g�|�C���g���L�^
            if (hit.distance > maxDistance)
            {
                maxDistance = hit.distance;
                m_LastHitPoint = hit.point;
            }
        }

        // �q�b�g���X�g���X�V
        m_PreviousHits = new List<GameObject>(m_CurrentHits);
    }

    // ��������������������������������������������������������������
    // �F�ύX�iRenderer�t���̃I�u�W�F�N�g�j
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
    // �M�Y���\���i���C���F�ŉ��q�b�g�n�_�܂Łj
    // ��������������������������������������������������������������
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, m_LastHitPoint);
        Gizmos.DrawSphere(m_LastHitPoint, 0.1f);
    }
}
