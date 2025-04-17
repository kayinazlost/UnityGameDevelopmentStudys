using UnityEngine;

/// <summary>
/// MouseLook360�F�}�E�X�̍��E�Ə㉺�̈ړ��ɉ����āA�I�u�W�F�N�g��360�x��]�����鎋�_����N���X�B
/// �ʏ�̓L�����{�̂�Yaw�iY���j�A�J������Pitch�iX���j��S�����邪�A���̃N���X�͗����ꊇ�ŉ�]����ł���B
/// </summary>
public class MouseLook360 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���p�j ��Header�t��
    // ��������������������������������������������������������������

    [Header("��]���x�i�}�E�X���x�j")]
    public float m_MouseSensitivity = 3.0f;

    [Header("�s�b�`�̍ŏ��p�x�i����������j")]
    public float m_MinPitch = -60f;

    [Header("�s�b�`�̍ő�p�x�i�����������j")]
    public float m_MaxPitch = 60f;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�ɕ\���j ��SerializeField�t��
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("�}�E�XX���̈ړ���")]
    private float m_MouseX = 0f;

    [SerializeField]
    [Header("�}�E�XY���̈ړ���")]
    private float m_MouseY = 0f;

    [SerializeField]
    [Header("���݂�Yaw�iY����]�p�j")]
    private float m_Yaw = 0f;

    [SerializeField]
    [Header("���݂�Pitch�iX����]�p�j")]
    private float m_Pitch = 0f;

    // ��������������������������������������������������������������
    // ���t���[���̍X�V����
    // ��������������������������������������������������������������
    private void Update()
    {
        // �}�E�X�̈ړ��ʂ��擾
        m_MouseX = Input.GetAxis("Mouse X") * m_MouseSensitivity;
        m_MouseY = Input.GetAxis("Mouse Y") * m_MouseSensitivity;

        // ��]�p�x�����Z
        m_Yaw += m_MouseX;
        m_Pitch -= m_MouseY; // ������̓}�C�i�X�ɂ��邱�ƂŒ����I�ȓ�����

        // Pitch�𐧌�
        m_Pitch = Mathf.Clamp(m_Pitch, m_MinPitch, m_MaxPitch);

        // ��]��K�p�iZ���͎g��Ȃ��j
        transform.localEulerAngles = new Vector3(m_Pitch, m_Yaw, 0f);
    }
}
