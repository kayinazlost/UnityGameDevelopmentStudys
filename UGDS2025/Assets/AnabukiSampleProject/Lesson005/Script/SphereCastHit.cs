using UnityEngine;

/// <summary>
/// SphereCastHit�FZ��������SphereCast���s���A
/// �q�b�g�����I�u�W�F�N�g�̐F��ԂɁA���ꂽ�甒�ɖ߂��B�}�E�XX��Y��]�B
/// </summary>
public class SphereCastHit : MonoBehaviour
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
    [Header("�q�b�g���̃I�u�W�F�N�g")]
    private GameObject m_CurrentHitObject = null;

    [SerializeField]
    [Header("�q�b�g�n�_")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // Y����]�i�}�E�XX�j
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        Vector3 direction = transform.forward;

        // �O��̃q�b�g�I�u�W�F�N�g�����ɖ߂�
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // SphereCast ���s
        if (Physics.SphereCast(transform.position, m_SphereRadius, direction, out RaycastHit hit, m_CastDistance, m_HitLayer))
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
