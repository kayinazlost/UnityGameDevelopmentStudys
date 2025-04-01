using UnityEngine;

/// <summary>
/// CapsuleCastHit�FCapsuleCast���g�p���A�w������ɓ����蔻����s���B
/// Z��������i�s�����Ƃ��A�}�E�XX�ړ���Y����]�B
/// ���������I�u�W�F�N�g�͐ԂɁA�����Ɣ��ɖ߂��B
/// </summary>
public class CapsuleCastHit : MonoBehaviour
{
    [Header("�J�v�Z���̔��a")]
    public float m_CapsuleRadius = 0.5f;

    [Header("�J�v�Z���̍����iY�������j")]
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
    [Header("���݃q�b�g���̃I�u�W�F�N�g")]
    private GameObject m_CurrentHitObject = null;

    [SerializeField]
    [Header("�ŏI�q�b�g�n�_")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // �}�E�XX��Y����]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // �J�v�Z���n�_�E�I�_���Z�o
        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;
        Vector3 direction = transform.forward;

        // �O��̃q�b�g�I�u�W�F�N�g�����̐F�ɖ߂�
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // �J�v�Z���L���X�g���s
        if (Physics.CapsuleCast(point1, point2, m_CapsuleRadius, direction, out RaycastHit hit, m_CastDistance, m_HitLayer))
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

    // ��������������������������������������������������������������
    // �F�ύX����
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
    // Gizmo�`��i�J�v�Z���L���X�g���j
    // ��������������������������������������������������������������
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 upOffset = Vector3.up * (m_CapsuleHeight / 2f - m_CapsuleRadius);
        Vector3 point1 = transform.position + upOffset;
        Vector3 point2 = transform.position - upOffset;

        // �J�v�Z�����C���\���i�L���X�g�����j
        Gizmos.DrawLine(point1, point1 + transform.forward * m_CastDistance);
        Gizmos.DrawLine(point2, point2 + transform.forward * m_CastDistance);

        // �q�b�g�_�\��
        Gizmos.DrawSphere(m_LastHitPoint, 0.1f);
    }
}
