using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// ���W�^�̕ϐ����Љ��T���v���X�N���v�g
/// ��ԊǗ��╡�G�ȃf�[�^�\���̎��p����܂�
/// </summary>
public class SampleHensu2 : MonoBehaviour
{
    /// <summary>
    /// �y1�zenum�i�񋓌^�j
    /// �񋓌^�́A���ԂŐݒ肳�ꂽ���̂�ID��t�^����Ă������
    /// ���L�̂��̂ł���΁AIdle��ID0�ԁARunning��ID1�ԂƂȂ�B
    /// �Q�[���̍U���T�C�g��ݒ�W�Ȃǂŕ�����ID�ԍ��Ƃ�������ɊY������B
    /// ���L�̂��̂ł���΁A�GAI�̏�ԓ��Ɏg���P�[�X���B
    /// </summary>
    public enum PlayerState
    {
        Idle,
        Running,
        Jumping,
        Dead
    }

    /// <summary>
    /// enum�����ێg���Ȃ�΁A��U�ϐ��Ƃ��Ē�`����K�v������B
    /// ���̏�ŁA��������ID�ԍ����������Ƃ��Aenum�^.ID����ID��t�^�\�B
    /// �ȊO�ƁA���̕��@�ł���΃v���O�����~�X���Ȃ����������B
    /// enum�̐ݒ��ÓI�ϐ��ɂ���΁A���̃N���X�ł��g�p�\���B
    /// </summary>
    [Header("���݂̃v���C���[���")]
    public PlayerState m_CurrentState = PlayerState.Idle;

    /// <summary>
    /// �y2�zstruct�i�\���́j
    /// �Q�[�������Ȃ�Δ����Ă͒ʂ�Ȃ����́B
    /// �ȒP�Ɍ����΁A�����̈�����ϐ��^�������ϐ�����鎖���o����B
    /// �Ⴆ�΁A�L�����N�^�[�̃p�����[�^�[�ȂǁA���O(string)��Lv(Int)��
    /// ���ꂼ��ʁX�̂��̂��ʂŊǗ���������A1�ɓZ�߂ĊǗ����������y���낤?
    /// ���̏ꍇ���ƁA�L�����N�^�[.Hp�ł��̃L�����N�^�[��Hp�𑝌��ł���悤�ɂȂ�B
    /// </summary>
    public struct Status
    {
        public int hp;
        public int mp;

        public Status(int hp, int mp)
        {
            this.hp = hp;
            this.mp = mp;
        }
    }
    /// <summary>
    /// �����������ۂ̍\���̂��g�����ϐ�
    /// �v���C���[�L�����N�^�[��Status��hp��mp�����Ȃ̂ŁA������₷���悤��
    /// �\���̓���Status�Ƃ����֐���݂��Ĉ�C�ɑ�����₷�����Ă���B
    /// ����ŁA���̃L�����N�^�[��Hp��100�AMp��50�ƂȂ�B
    /// </summary>
    private Status m_PlayerStatus = new Status(100, 50);

    /// <summary>
    /// �y3�z[System.Serializable] �N���X
    /// ��?�\���̂͂߂ǂ�??
    /// ���Ⴀ�A�N���X���g���č\���̂̑��������Ă݂悤�B
    /// ����œ��l�Ȃ��Ƃ��ł��邼?
    /// </summary>
    [System.Serializable]
    public class Weapon
    {
        public string name;
        public int power;
    }

    [Header("�������̕���")]
    public Weapon m_EquippedWeapon = new Weapon { name = "�u���[�h", power = 25 };

    /// <summary>
    /// �y4�zDictionary�i�����^�j
    /// �f�B�N�V���i���[�Ƃ����B
    /// ����́A2�̕ϐ��ŊǗ��ł���悤�ɂ�����́B
    /// ���L�̗p�ɁA�A�C�e�����Ƃ��̏��������Ǘ����鎖�ɕ֗����B
    /// </summary>
    private Dictionary<string, int> m_ItemCounts = new Dictionary<string, int>()
    {
        { "�|�[�V����", 3 },
        { "�G���N�T�[", 1 }
    };

    /// <summary>
    /// �y5�zNullable�inull���e�^�j
    /// null�͕֗������v���ӁB
    /// null�́y�����z�y���݂��Ȃ��z���Ɠ���
    /// �Ⴆ�Εϐ��������Ă��Ȃ���Ί�{null�Ɠ����B
    /// �ϐ��̏�������͂���Ă����܂��傤�B
    /// </summary>
    private int? m_LastDamageTaken = null; // �_���[�W���󂯂Ă��Ȃ��ꍇnull

    void Start()
    {
        Debug.Log("�yenum�z���݂̃v���C���[��ԁF" + m_CurrentState.ToString());

        Debug.Log("�ystruct�zHP�F" + m_PlayerStatus.hp + " / MP�F" + m_PlayerStatus.mp);

        Debug.Log("�ySerializable Class�z���햼�F" + m_EquippedWeapon.name + "�i�З́F" + m_EquippedWeapon.power + "�j");

        Debug.Log("�yDictionary�z�����A�C�e���F");
        foreach (var item in m_ItemCounts)
        {
            Debug.Log("�@�� " + item.Key + " x" + item.Value);
        }

        Debug.Log("�yNullable�z�Ō�Ɏ󂯂��_���[�W�F" + (m_LastDamageTaken.HasValue ? m_LastDamageTaken.ToString() : "�܂��󂯂Ă��Ȃ�"));
    }
}
