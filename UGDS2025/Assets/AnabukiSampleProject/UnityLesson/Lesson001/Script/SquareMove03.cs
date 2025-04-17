using UnityEngine;

/// <summary>
/// SquareMove03�FTransform.position�̑����ɂ���Ĉړ�����N���X�B
/// Rigidbody�����g�p�����A�X�N���v�g�P�ƂŃV���v���ɍ��W��ύX���ē������B
/// </summary>
public class SquareMove03 : MonoBehaviour
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
    // ���t���[���X�V����
    // ��������������������������������������������������������������
    private void Update()
    {
        // ���͎擾
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");

        // �ړ��������v�Z
        Vector3 moveDirection = new Vector3(m_Horizontal, 0f, m_Vertical).normalized;

        // ���݂̈ʒu�ɉ��Z
        transform.position += moveDirection * m_MoveSpeed * Time.deltaTime;
    }
}
