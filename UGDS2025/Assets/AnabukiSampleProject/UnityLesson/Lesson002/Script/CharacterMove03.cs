using UnityEngine;

/// <summary>
/// CharacterMove03�FAddForce�ɂ���ăL�����N�^�[���ړ��E�W�����v�����銮�S��������N���X�B
/// �W�����v���͈ړ��E�d�͂𖳌����B�ő呬�x�𒴂��Ȃ��悤�����BCharacterController�͎g�p�s�B
/// </summary>
[RequireComponent(typeof(Rigidbody))]
public class CharacterMove03 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���j
    // ��������������������������������������������������������������

    [Header("�ړ��́iAddForce�Ɏg���́j")]
    public float m_MoveForce = 30f;

    [Header("�ő�ړ����x�i���j�b�g/�b�j")]
    public float m_MaxMoveSpeed = 5f;

    [Header("�W�����v�́i�����t���W�����v�Ɏg���́j")]
    public float m_JumpForce = 8f;

    [Header("�ő�W�����v���x�i�����x�̏���j")]
    public float m_MaxJumpSpeed = 6f;

    [Header("�ڒn���苗��")]
    public float m_GroundCheckDistance = 1.1f;

    [Header("�n�ʃ��C���[")]
    public LayerMask m_GroundLayer;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�\���j
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("���݂̈ړ����́iX,Z�j")]
    private Vector3 m_InputDir = Vector3.zero;

    [SerializeField]
    [Header("���ݐڒn���Ă��邩")]
    private bool m_IsGrounded = false;

    [SerializeField]
    [Header("�W�����v�����ǂ���")]
    private bool m_IsJumping = false;

    [SerializeField]
    [Header("Rigidbody�Q��")]
    private Rigidbody m_Rigidbody;

    // ��������������������������������������������������������������
    // ������
    // ��������������������������������������������������������������
    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.useGravity = true;
    }

    // ��������������������������������������������������������������
    // ���t���[���F���͂ƃW�����v����
    // ��������������������������������������������������������������
    private void Update()
    {
        // ���͎擾
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        m_InputDir = new Vector3(h, 0f, v).normalized;

        // �ڒn����
        m_IsGrounded = Physics.Raycast(transform.position, Vector3.down, m_GroundCheckDistance, m_GroundLayer);

        // �W�����v���͔���i�n�ʏ� & ��W�����v���j
        if (m_IsGrounded && !m_IsJumping && Input.GetKeyDown(KeyCode.Space))
        {
            // �W�����v���t���O
            m_IsJumping = true;

            // �d�͈ꎞ�������iAddForce�W�����v�݂̂ɏ]���j
            m_Rigidbody.useGravity = false;

            // �W�����v�����F���́{�����
            Vector3 jumpDir = (m_InputDir + Vector3.up).normalized;

            // ���݂̑��x���N���A���ăW�����v
            m_Rigidbody.linearVelocity = Vector3.zero;
            m_Rigidbody.AddForce(jumpDir * m_JumpForce, ForceMode.Impulse);
        }
    }

    // ��������������������������������������������������������������
    // FixedUpdate�F�����ړ��ƃW�����v�Ǘ�
    // ��������������������������������������������������������������
    private void FixedUpdate()
    {
        // �W�����v���łȂ��Ƃ������ړ��\
        if (!m_IsJumping && m_IsGrounded)
        {
            // �ő呬�x����
            Vector3 horizontalVel = new Vector3(m_Rigidbody.linearVelocity.x, 0f, m_Rigidbody.linearVelocity.z);

            if (horizontalVel.magnitude < m_MaxMoveSpeed)
            {
                m_Rigidbody.AddForce(m_InputDir * m_MoveForce, ForceMode.Force);
            }
        }

        // �W�����v�����x�����i�W�����v���������j
        if (m_IsJumping)
        {
            if (m_Rigidbody.linearVelocity.magnitude > m_MaxJumpSpeed)
            {
                m_Rigidbody.linearVelocity = m_Rigidbody.linearVelocity.normalized * m_MaxJumpSpeed;
            }
        }

        // ���n����F�ڒn���ɃW�����v����
        if (m_IsJumping && m_IsGrounded)
        {
            m_IsJumping = false;
            m_Rigidbody.useGravity = true; // �d�͂��ĂїL����
        }
    }

    // ��������������������������������������������������������������
    // �f�o�b�O�p�F�ڒn���\��
    // ��������������������������������������������������������������
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * m_GroundCheckDistance);
    }
}
