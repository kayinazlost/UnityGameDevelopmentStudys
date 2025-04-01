using UnityEngine;

/// <summary>
/// BoxCastHit�FBoxCast���g���đO���ɓ����蔻����΂��A
/// �ڐG�����I�u�W�F�N�g�̐F��ԂɁA���ꂽ�甒�ɖ߂��B
/// �}�E�XX��Y����]�ABox�̌�����Z���B
/// </summary>
public class BoxCastHit : MonoBehaviour
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
    [Header("���݃q�b�g���̃I�u�W�F�N�g")]
    private GameObject m_CurrentHitObject = null;

    [SerializeField]
    [Header("�ŏI�q�b�g�ʒu")]
    private Vector3 m_LastHitPoint;

    private void Update()
    {
        // �}�E�XX�ŉ�]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // BoxCast�J�n�_�ƌ���
        Vector3 direction = transform.forward;
        Quaternion rotation = transform.rotation;

        // �F���Z�b�g
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // �L���X�g���s
        if (Physics.BoxCast(transform.position, m_BoxHalfExtents, direction, out RaycastHit hit, rotation, m_CastDistance, m_HitLayer))
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
