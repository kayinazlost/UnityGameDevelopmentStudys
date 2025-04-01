using UnityEngine;

/// <summary>
/// SquareMove01�F�v���C���[�L�����N�^�[�Ȃǂ̃I�u�W�F�N�g��WASD�L�[�ňړ�������N���X�B
/// �g�����X���[�g�iTranslate�j���g�p���AInput�̃A�N�V�Y�Ŋ��炩�Ȉړ��������B
/// </summary>
public class SquareMove01 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���p�j ��Header�t��
    // ��������������������������������������������������������������

    [Header("�ړ����x�i���j�b�g/�b�j")]
    public float m_MoveSpeed = 5.0f;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�ɕ\���j ��SerializeField�t��
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("�������̓��͒l")]
    private float m_Horizontal = 0f;

    [SerializeField]
    [Header("�c�����̓��͒l")]
    private float m_Vertical = 0f;

    // ��������������������������������������������������������������
    // MonoBehaviour�֐�
    // ��������������������������������������������������������������

    /// <summary>
    /// ���t���[���ړ��������s��
    /// </summary>
    void Update()
    {
        // ���͎擾
        m_Horizontal = Input.GetAxis("Horizontal");  // A/D�܂��́���
        m_Vertical = Input.GetAxis("Vertical");      // W/S�܂��́���

        // �ړ������x�N�g�����쐬
        Vector3 moveDirection = new Vector3(m_Horizontal, 0f, m_Vertical);

        // ���K�����ĕ������ێ����Ȃ��瑬�x�����ɂ���
        if (moveDirection.magnitude > 1f)
        {
            moveDirection.Normalize();
        }

        // �g�����X���[�g�ɂ��ړ������i���[�J�����W�n�j
        transform.Translate(moveDirection * m_MoveSpeed * Time.deltaTime, Space.Self);
    }
}
