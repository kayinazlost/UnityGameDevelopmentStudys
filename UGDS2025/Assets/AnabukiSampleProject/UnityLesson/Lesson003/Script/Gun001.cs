using UnityEngine;

/// <summary>
/// Gun001�F�}�E�X���N���b�N�Œe�𔭎˂���N���X�B
/// �Ζ�ʂɉ�����AddForce�Ŕ򋗗����ω��B���������e��5�b��Ɏ����j�������B
/// Rigidbody���Ȃ���Ύ����Œǉ��B
/// </summary>
public class Gun001 : MonoBehaviour
{
    // ��������������������������������������������������������������
    // �p�u���b�N�ϐ��i�C���X�y�N�^�[�\���j
    // ��������������������������������������������������������������

    [Header("�e�v���n�u")]
    public GameObject m_ProjectilePrefab;

    [Header("�e�̔��ˈʒu")]
    public Transform m_FirePoint;

    [Header("�Ζ�ʁiAddForce�Ɏg���́j")]
    public float m_ExplosiveForce = 500f;

    [Header("�e�̎����i�b�j")]
    public float m_ProjectileLifetime = 5f;

    // ��������������������������������������������������������������
    // �v���C�x�[�g�ϐ��i�C���X�y�N�^�[�\���j
    // ��������������������������������������������������������������

    [SerializeField]
    [Header("�e���˕���")]
    private Vector3 m_FireDirection = Vector3.forward;

    // ��������������������������������������������������������������
    // ���t���[���̓��͏���
    // ��������������������������������������������������������������
    private void Update()
    {
        // ���N���b�N�Ŕ���
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    // ��������������������������������������������������������������
    // �e�̐���������
    // ��������������������������������������������������������������
    private void FireProjectile()
    {
        if (m_ProjectilePrefab == null || m_FirePoint == null)
        {
            Debug.LogWarning("ProjectilePrefab��FirePoint�����ݒ�ł��I");
            return;
        }

        // �e�𐶐�
        GameObject projectile = Instantiate(m_ProjectilePrefab, m_FirePoint.position, m_FirePoint.rotation);

        // Rigidbody���擾�܂��͒ǉ�
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = projectile.AddComponent<Rigidbody>();
        }

        // ���˕����ɗ͂�������iforward�����j
        m_FireDirection = m_FirePoint.forward;
        rb.AddForce(m_FireDirection * m_ExplosiveForce);

        // ��莞�ԂŔj��
        Destroy(projectile, m_ProjectileLifetime);
    }
}
