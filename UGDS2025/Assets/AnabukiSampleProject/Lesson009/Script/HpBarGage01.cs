using UnityEngine;
using UnityEngine.UI;

public class HpBarGage01 : MonoBehaviour
{
    [Header("HP�o�[�Q�[�W�pImage")]
    public Image m_HpGage;
    [Header("HP���l")]
    public Text m_HitPintText;
    [Header("HP���l������Ώ�")]
    public Parameta001 m_Parameta;
    void Start()
    {
        //HP�o�[�Q�[�W���ݒ肳��Ă��Ȃ��ꍇ�A���g��HP�o�[�Q�[�W��Image�ł���Ȃ炻��ƃ����N����
        if (!m_HpGage)
        {
            //Image����荞��
            m_HpGage = GetComponent<Image>();
            //������HP�o�[�Q�[�W��0�Ƃ���B
            m_HpGage.fillAmount = 0.0f;
        }
        //HP�e�L�X�g���Ȃ��ꍇ�A����́yGameObject�̖��O�z���烊���N���Z�b�g����
        if (!m_HitPintText)
        {
            //�q�G�����L�[����GameObject�ŁuHP�e�L�X�g�v�Ƃ������O��GameObject��T���ADummy�ɑ��
            GameObject Dummy = GameObject.Find("HP�e�L�X�g");
            //Dummy���̃R���|�[�l���g(�v���O����)�ɁuText�v������ꍇ�́Am_HitPointText�Ƀ����N����A������0��
            if (Dummy.GetComponent<Text>())
            {
                m_HitPintText = Dummy.GetComponent<Text>();
                m_HitPintText.text = "0";
            }
        }
    }

    void Update()
    {
        //HP�o�[�Q�[�W���Z�b�g���Ă��Ȃ�
        if (!m_HpGage || !m_HitPintText)
        {
            Debug.LogError("HP�o�[�Q�[�W�AHP�e�L�X�g���Z�b�g����Ă��܂���!!");
            return;
        }
        //�����AHP�o�[�Q�[�W�ƃp�����[�^�[���ݒ肳��Ă���ꍇ�̂݋N��
        if (m_Parameta)
        {
            //���݂�HP��0�ȏ�ł���
            if (m_Parameta.m_Hp > 0)
            {
                //HP�e�L�X�g�ɐ��l����(�����Afloat�^�������ꍇ��int�l�ɂ���̂��x�X�g)
                int Dummy = m_Parameta.m_Hp;
                m_HitPintText.text = Dummy.ToString();
                //HP���ő�HP�𒴂��Ă���ꍇ�A�o�[�Q�[�W�͍ő�l�A����ȊO�Ȃ�A�������o���đ��
                if (m_Parameta.m_Hp <= m_Parameta.m_MaxHp)
                    m_HpGage.fillAmount = (1.0f / m_Parameta.m_MaxHp) * m_Parameta.m_Hp;
                else
                    m_HpGage.fillAmount = 1.0f;
            }
            else
            {
                m_HpGage.fillAmount = 0.0f; //����ȊO�́AHP0�Ȃ̂ŁA�o�[�Q�[�W��0
                m_HitPintText.text = "0";
            }
        }
        else
        {
            m_HpGage.fillAmount = 0.0f; //�Ώۂ����Ȃ��̂ŁA�o�[�Q�[�W��0
            m_HitPintText.text = "0";
        }
    }
}
