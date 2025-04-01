using UnityEngine;

/// <summary>
/// MouseRotatePitch01�F�}�E�X�̑O��iY���j�ړ���X����]�i�s�b�`�j���s���N���X�B
/// ��ʓI�ɂ̓J������㔼�g�̏㉺�����𐧌䂷��p�r�Ɏg�p�����B
/// </summary>
public class MouseRotatePitch01 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���p�j ��Header�t��
    // ��������������������������������������������������������������

    [Header("��]���x�i�傫���قǑ����㉺�Ɍ����j")]
    public float m_MouseSensitivity = 3.0f;

    [Header("�㉺��]�̍ŏ��p�x�i������������j")]
    public float m_MinPitch = -60f;

    [Header("�㉺��]�̍ő�p�x�i�������������j")]
    public float m_MaxPitch = 60f;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�ɕ\���j ��SerializeField�t��
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("�}�E�XY���̈ړ���")]
    private float m_MouseY = 0f;

    [SerializeField]
    [Header("���݂�X����]�p�i�s�b�`�j")]
    private float m_CurrentXRotation = 0f;

    // ��������������������������������������������������������������
    // ���t���[���̍X�V����
    // ��������������������������������������������������������������
    private void Update()
    {
        // �}�E�XY���̈ړ��ʂ��擾�i���㉺���]�̂��� - ��t����̂���ʓI�j
        m_MouseY = Input.GetAxis("Mouse Y");

        // ���͂ɉ�����X����]�����Z�i�O�ɓ|���Ɖ��������j
        m_CurrentXRotation -= m_MouseY * m_MouseSensitivity;

        // �㉺��]�p�𐧌��i�N�����v�j
        m_CurrentXRotation = Mathf.Clamp(m_CurrentXRotation, m_MinPitch, m_MaxPitch);

        // ��]��K�p�iX���̂݉�]�j
        transform.localEulerAngles = new Vector3(m_CurrentXRotation, 0f, 0f);
    }
}
