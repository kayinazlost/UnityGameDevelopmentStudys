using UnityEngine;

/// <summary>
/// Unity�Ŏg����l�X�ȕϐ��^�̏Љ�ƁADebug.Log�ɂ��o�͗�
/// ���S�Ҍ����̕ϐ��w�K�p�X�N���v�g
/// </summary>

public class SampleHensu : MonoBehaviour
{
    /// <summary>
    /// �X�R�A��A�L�����N�^�[��Hp���̃p�����[�^�[�ł悭�g��
    /// </summary>
    [Header("�����^�iint�j")]
    public int m_PlayerScore = 100;

    /// <summary>
    /// �����_���g����ϐ��A�K���Ō��f�����鎖
    /// </summary>
    [Header("�����_�^�ifloat�j")]
    public float m_PlayerSpeed = 5.5f;

    /// <summary>
    /// �^�E�U��2��������ł��Ȃ��ϐ�
    /// �Q�[�����I�����Ă��邩��A�e�����b�N����Ă��邩���ɂ��g��
    /// </summary>
    [Header("�^�U�^�ibool�j")]
    public bool m_IsGameOver = false;

    /// <summary>
    /// ���p�p����1���������i�[�ł���ϐ�
    /// A��b�����i�[�ł���
    /// </summary>
    [Header("�����^�ichar�j")]
    public char m_Grade = 'A';

    /// <summary>
    /// Char�^�ƈႢ�A�����񂪊i�[�ł���
    /// ����̖��O��L�����N�^�[���A���b�Z�[�W���Ȃǂɑ��p����
    /// </summary>
    [Header("������^�istring�j")]
    public string m_PlayerName = "�J�C���E�A�Y���X�g";

    /// <summary>
    /// 2D�Q�[���ɉ�����X��Y������̕ϐ��Ŋi�[�ł�����́B
    /// 2D�Q�[����UI�֌W�̐���Ȃǂɗ��p�ł�����A�ŏ��l�A�ő�l�Ȃǂ�2���̐��l���i�[���鎖���\
    /// </summary>
    [Header("2�����x�N�g���iVector2�j")]
    public Vector2 m_MoveDirection2D = new Vector2(1.0f, 0.0f);

    /// <summary>
    /// 3D�Q�[���ɉ�����X��Y��Z������̕ϐ��Ŋi�[�ł�����́B
    /// 3D�Q�[���̃L�����N�^�[���W��A�L�����N�^�[�̕����I�ȉ����ʓ��ɂ��g����B
    /// </summary>
    [Header("3�����x�N�g���iVector3�j")]
    public Vector3 m_Position = new Vector3(0, 1, 0);

    /// <summary>
    /// �F�B����ȏ������ȉ����Ȃ��A�F�B
    /// �F�̐ݒ�̐��l�I�Ȃ��̂ŁAUnity�ł���΁A�����ƃp���b�g���p�ӂ���Ă���B
    /// ���ڐF���w�肵�����ꍇ�́AColor.�F�̖��O(�p��)�ŃZ�b�g�ł���
    /// ���̃^�C�v��Color32�����݂��A�������ݒ蓙���\
    /// �J���[�R�[�h���́yr,g,b,a�z�y��,��,��,�����x�z
    /// </summary>
    [Header("�J���[�iColor�j")]
    public Color m_PlayerColor = Color.red;

    /// <summary>
    /// �q�G�����L�[��A�v���W�F�N�g�Ŏw��ł���GameObject���i�[�ł���ϐ�
    /// �o�����������v���n�u(GameObject)���w�肵����A�j�󂵂���GameObject�̎w��ɂ��g����
    /// ���p���l���ł�����
    /// </summary>
    [Header("�Q�[���I�u�W�F�N�g�Q�ƁiGameObject�j")]
    public GameObject m_TargetObject;

    /// <summary>
    /// �Q�[���I�u�W�F�N�g����Transform�̃R���|�[�l���g�ƃ����N���鎖���o����ϐ�
    /// ������GameObject���h���b�N����ƁA�R���|�[�l���g���������N����
    /// �Ώۂ̃Q�[���I�u�W�F�N�g�𑀍삵����A���W�ʒu���擾����̂ɖ��ɗ���
    /// �^�[�Q�b�g�Ƃ��ė��p������A�܂����ʂɂ���q�I�u�W�F�N�g������o���ɂ��g����
    /// </summary>
    [Header("Transform�R���|�[�l���g")]
    public Transform m_TargetTransform;

    /// <summary>
    /// �z��̎�
    /// �����̎w�肵�������̓���ϐ����i�[�ł���B
    /// �킩��Ղ������΁A�w�����̈�ՂŐ��񂵂Ă����Ԃ��v�������ׂ悤!
    /// �퓬���珇�ԂɊY������ϐ����i�[����Ă���ƍl����΂킩��Ղ�
    /// �A���A�z��́A��x�񐔂����߂Ă��܂��ƕύX���s�\�Ƃ������_������B
    /// </summary>
    [Header("�z��iArray�j")]
    public int[] m_Scores = new int[] { 10, 20, 30 }; // �����̒l���i�[

    /// <summary>
    /// ���X�g�̎�
    /// �����ł�����Ȃ������Ă�܂Ȃ��ł��g������̂����z�B
    /// �����ڂ͕ϐ��Ɠ��������A��̓r�����犄�荞�ގ����A�K�v�Ȃ�����폜���ċl�ߏグ�鎖���\
    /// �A���A�z��ƈႢ���̂��Ȃ��ׁA�z��ŏo�����v���O�������o���Ȃ���������B
    /// ���̏ꍇ�́A�G�̌��ݏo���Ǘ���A�Q�[�����ɔ��ł���e���Ǘ��A�G�Ƃ��ďo�����郂���X�^�[���X�g���Ɏg���Ă���B
    /// �����v���W�F�N�g�ŁA�{�X���j��ɔ�ь����Ă���e������C�ɏ��ł���̂��A������g���Ă��邩��!
    /// </summary>
    [Header("���X�g�iList�j ��using System.Collections.Generic���K�v")]
    public System.Collections.Generic.List<string> m_Inventory = new System.Collections.Generic.List<string>() { "��", "��" };
    void Start()
    {
        // ======================
        // Debug.Log���g���āA�ϐ��̓��e���o��
        // ======================

        Debug.Log("�yint�z�X�R�A�F" + m_PlayerScore);
        Debug.Log("�yfloat�z�X�s�[�h�F" + m_PlayerSpeed);
        Debug.Log("�ybool�z�Q�[���I�[�o�[���H�F" + m_IsGameOver);
        Debug.Log("�ychar�z���сF" + m_Grade);
        Debug.Log("�ystring�z���O�F" + m_PlayerName);
        Debug.Log("�yVector2�z2D�ړ������F" + m_MoveDirection2D);
        Debug.Log("�yVector3�z3D���W�F" + m_Position);
        Debug.Log("�yColor�z�F�F" + m_PlayerColor);
        //���Ȃ݂ɁA���̎��ō��ƁA�u����GameObject���ݒ肳��Ă��Ȃ���΁y���ݒ�z�ƕ\���v�����B
        //�~�X��𓙂Ɏg����̂Ŋo���Ă�����!
        Debug.Log("�yGameObject�z�ΏۃI�u�W�F�N�g�F" + (m_TargetObject != null ? m_TargetObject.name : "���ݒ�"));
        Debug.Log("�yTransform�z�Ώۂ̈ʒu�F" + (m_TargetTransform != null ? m_TargetTransform.position.ToString() : "���ݒ�"));

        //�X�R�A�z��Ŏg�p���Ă���̂�int�^�Ȃ̂ŁAstring.Join���g���āAint�^���當����^�ɕϊ�������ŁA�z��̐��l��,�ŋ�؂��ĘA���\�����Ă���B
        Debug.Log("�yArray�z�X�R�A�z��F" + string.Join(",", m_Scores));
        //���X�g�́A���X�g��.Count�Ƃ���ƁA���̃��X�g�œo�^����Ă��鑍�����o�܂��B
        //����ŁA�G�c�@x�@�Ƃ������ɕ\���ł���������܂��B
        Debug.Log("�yList�z�C���x���g���A�C�e�����F" + m_Inventory.Count);
        //foreach���g���΁A�z��⃊�X�g���̗v�f(�܂܂�Ă�����̂̎�)��S�Ă�􂢏o��(�J��Ԃ�����)�̂�
        //���X�g�ł���΁A�S�Ẵ��X�g���Ɋi�[���ꂽ���̂�\���ł��܂��B
        foreach (string item in m_Inventory)
        {
            Debug.Log("�@�� " + item);
        }

        // ���񂿂��FC#�ł͂��ׂĂ̕ϐ��^��System.Object���p�����Ă��܂��I
        // �܂�A�ǂ�ȕϐ����ŏI�I�ɂ́u�I�u�W�F�N�g�v�Ȃ̂ł��B
        // C++�����₷���ˁ�
    }

}
