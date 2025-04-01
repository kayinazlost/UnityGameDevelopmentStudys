using UnityEngine;

/// <summary>
/// MouseRotate01�F�}�E�X�̈ړ��ɂ���ăL�����N�^�[�����E�ɉ�]������N���X�B
/// �J�����ł͂Ȃ��A�v���C���[�{�́i�L�������f���Ȃǁj��Yaw�����̉�]�𐧌�B
/// </summary>
public class MouseRotate01 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���p�j ��Header�t��
    // ��������������������������������������������������������������

    [Header("��]���x�i�傫���قǑ�����]�j")]
    public float m_MouseSensitivity = 3.0f;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�ɕ\���j ��SerializeField�t��
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("�}�E�XX���̈ړ���")]
    private float m_MouseX = 0f;

    [SerializeField]
    [Header("���݂̉�]�p�x�iY���j")]
    private float m_CurrentYRotation = 0f;

    // ��������������������������������������������������������������
    // ���t���[���̍X�V����
    // ��������������������������������������������������������������
    private void Update()
    {
        // �}�E�XX���̈ړ��ʂ��擾
        m_MouseX = Input.GetAxis("Mouse X");

        // ��]�p�x�ɕϊ�
        m_CurrentYRotation += m_MouseX * m_MouseSensitivity;

        // ��]��K�p�iY�������ω��j
        transform.eulerAngles = new Vector3(0f, m_CurrentYRotation, 0f);
    }
}
