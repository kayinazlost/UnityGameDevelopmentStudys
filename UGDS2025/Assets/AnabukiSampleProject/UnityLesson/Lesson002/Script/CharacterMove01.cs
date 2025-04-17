using UnityEngine;

/// <summary>
/// CharacterMove01 �FTranslate�ł̈ړ��ƁARigidbody��AddForce���g�����W�����v����N���X�B
/// �W�����v���͈ړ��s�B�W�����v�͒n�ʂɐڒn���Ă��鎞�̂ݗL���B�������͂ƕ��p�ŕ����t���W�����v�B
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove01 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���p�j
    // ��������������������������������������������������������������

    [Header("�ړ����x�i���j�b�g/�b�j")]
    public float m_MoveSpeed = 5.0f;

    [Header("�W�����v�́i�����������̗́j")]
    public float m_JumpForce = 5.0f;

    [Header("�ڒn����̋���")]
    public float m_GroundCheckDistance = 1.1f;

    [Header("�ڒn����Ɏg�����C���[")]
    public LayerMask m_GroundLayer;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�ɕ\���j
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("����������")]
    private float m_Horizontal = 0f;

    [SerializeField]
    [Header("�c��������")]
    private float m_Vertical = 0f;

    [SerializeField]
    [Header("�ڒn���Ă��邩")]
    private bool m_IsGrounded = false;

    [SerializeField]
    [Header("Rigidbody�Q��")]
    private Rigidbody m_Rigidbody;

    // ��������������������������������������������������������������
    // ����������
    // ��������������������������������������������������������������
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    // ��������������������������������������������������������������
    // ���t���[���X�V�����i���͎擾���ړ��j
    // ��������������������������������������������������������������
    private void Update()
    {
        // �n�ʃ`�F�b�N
        m_IsGrounded = Physics.Raycast(transform.position, Vector3.down, m_GroundCheckDistance, m_GroundLayer);

        // ���͎擾
        m_Horizontal = Input.GetAxis("Horizontal");
        m_Vertical = Input.GetAxis("Vertical");

        // �ړ��i�n�ʂɐڂ��Ă���Ƃ��݈̂ړ��\�j
        if (m_IsGrounded)
        {
            Vector3 moveDir = new Vector3(m_Horizontal, 0f, m_Vertical).normalized;
            transform.Translate(moveDir * m_MoveSpeed * Time.deltaTime, Space.World);
        }

        // �W�����v���́i�n�㎞�̂݁j
        if (m_IsGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 jumpDir = new Vector3(m_Horizontal, 1f, m_Vertical).normalized;
            m_Rigidbody.AddForce(jumpDir * m_JumpForce, ForceMode.Impulse);
        }
    }

    // ��������������������������������������������������������������
    // �f�o�b�O�p�M�Y���`��i�n�ʃ`�F�b�N���j
    // ��������������������������������������������������������������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * m_GroundCheckDistance);
    }
}
