using UnityEngine;

public class FireControlSystem001 : MonoBehaviour
{
    [Header("Mount�N���X�Ƀ����N����")]
    public Mount001 m_Mount;
    void Start()
    {
        ///Mount�N���X�����݂��Ȃ��ꍇ�A�Q�[���I�u�W�F�N�g��Mount�N���X�������
        ///����Mount�N���X�ƃ����N����
        ///�����ꍇ�̓G���[�Ƃ��ăR���\�[���ɍ��m
        if (!m_Mount)
            if (GetComponent<Mount001>())
                m_Mount = GetComponent<Mount001>();
            else
                Debug.LogError(gameObject + "�ɁAMount�N���X�����݂��܂���");
    }

    void Update()
    {
        
    }
    /// <summary>
    /// Object�������I�ɐڐG�����ꍇ
    /// </summary>
    /// <param name="collision">���������Ώ�</param>
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
