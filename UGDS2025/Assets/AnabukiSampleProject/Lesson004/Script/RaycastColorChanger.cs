using UnityEngine;

/// <summary>
/// RaycastColorChanger�FZ�������Ƀ��C�L���X�g�𔭎˂��A
/// �q�b�g�����I�u�W�F�N�g�̐F��ԂɁA����ȊO�𔒂ɕύX�B
/// ���C�̓}�E�XX�ړ���Y����]�\�B�M�Y���ŉ����B
/// </summary>
public class RaycastColorChanger : MonoBehaviour
{
    [Header("���C�̒���")]
    public float m_RayLength = 10f;

    [Header("��]���x�i�}�E�X���x�j")]
    public float m_RotationSpeed = 100f;

    [Header("�ڐG���̐F")]
    public Color m_HitColor = Color.red;

    [Header("��ڐG���̐F")]
    public Color m_DefaultColor = Color.white;

    [Header("���C���[�}�X�N�i�q�b�g�Ώہj")]
    public LayerMask m_HitLayer;

    [SerializeField]
    [Header("���݂̃q�b�g�I�u�W�F�N�g")]
    private GameObject m_CurrentHitObject = null;

    private void Update()
    {
        // �}�E�XX��Y����]
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0f, mouseX * m_RotationSpeed * Time.deltaTime, 0f);

        // ���C�L���X�g����
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // ���݂̃q�b�g�I�u�W�F�N�g������ΐF�����ɖ߂�
        if (m_CurrentHitObject != null)
        {
            SetObjectColor(m_CurrentHitObject, m_DefaultColor);
            m_CurrentHitObject = null;
        }

        // �ڐG������F�ύX
        if (Physics.Raycast(ray, out hit, m_RayLength, m_HitLayer))
        {
            m_CurrentHitObject = hit.collider.gameObject;
            SetObjectColor(m_CurrentHitObject, m_HitColor);
        }
    }

    // ��������������������������������������������������������������
    // �w��I�u�W�F�N�g�̃}�e���A���F�ύX
    // ��������������������������������������������������������������
    private void SetObjectColor(GameObject obj, Color color)
    {
        Renderer rend = obj.GetComponent<Renderer>();
        if (rend != null)
        {
            // �}�e���A���C���X�^���X���ő��Ƌ��L���Ȃ��悤�ɂ���
            if (Application.isPlaying)
                rend.material.color = color;
            else
                rend.sharedMaterial.color = color;
        }
    }

    // ��������������������������������������������������������������
    // �M�Y���ɂ�郌�C����
    // ��������������������������������������������������������������
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, m_RayLength, m_HitLayer))
        {
            // �q�b�g�ʒu�܂ŕ`��
            Gizmos.DrawLine(transform.position, hit.point);
            Gizmos.DrawSphere(hit.point, 0.1f);
        }
        else
        {
            // �ő勗���܂ŕ`��
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * m_RayLength);
        }
    }
}
