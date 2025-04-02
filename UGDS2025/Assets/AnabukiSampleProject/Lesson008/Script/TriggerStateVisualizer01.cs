using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// TriggerStateVisualizer01�F�g���K�[�ڐG�̏�Ԃ����m���A
/// �u�ڐG�J�n�v�u�ڐG���v�u�ڐG�I���v��Y+1�̈ʒu�ɃM�Y���\������N���X�B
/// </summary>
public class TriggerStateVisualizer01 : MonoBehaviour
{
    /// <summary>
    /// ��Ԃ�\���񋓌^
    /// �񋓌^�́A�w�肻�ꂽ���O��ID(�ԍ�)���A������悤�Ȃ��́B
    /// �܂��A�o�Ȕԍ��ƁA���O(���x��)���A�����Ă�����̂��ƍl����΂悢�B
    /// ���ʂ̂��̂ł���΁A
    /// None = 0�AEnter = 1�AStay = 2�AExit = 3�ƂȂ�B
    /// ����͌�XAI�ŃX�e�[�gAI���w�ԍۂɂ悭���p�����̂Ŋo���Ă�����!
    /// </summary>
    private enum TriggerState
    {
        None,       //������
        Enter,      //�ڐG����
        Stay,       //�ڐG��
        Exit        //�ڐG���痣�ꂽ
    }

    [SerializeField]
    [Header("���݂̃g���K�[���")]
    private TriggerState m_TriggerState = TriggerState.None;

    // ��������������������������������������������������������������
    // �g���K�[�C�x���g�Q
    // ��������������������������������������������������������������
    /// <summary>
    /// �ڐG����
    /// </summary>
    /// <param name="other">�ڐG�Ώ�</param>
    private void OnTriggerEnter(Collider other)
    {
        //�ڐG�����̂ŁAEnter��������
        m_TriggerState = TriggerState.Enter;
    }
    /// <summary>
    /// �ڐG��
    /// </summary>
    /// <param name="other">�ڐG�Ώ�</param>
    private void OnTriggerStay(Collider other)
    {
        //�ڐG���Ȃ̂ŁAStay��������
        m_TriggerState = TriggerState.Stay;
    }
    /// <summary>
    /// �ڐG���痣�ꂽ
    /// </summary>
    /// <param name="other">�ڐG�Ώ�</param>
    private void OnTriggerExit(Collider other)
    {
        //�ڐG���痣�ꂽ�̂ŁAExit��������
        m_TriggerState = TriggerState.Exit;
    }

#if UNITY_EDITOR
    // ��������������������������������������������������������������
    // �M�Y���ŏ�Ԃ�Y+1�̈ʒu�ɕ\��
    // ��������������������������������������������������������������
    private void OnDrawGizmos()
    {
        Vector3 labelPos = transform.position + Vector3.up * 1.0f;

        string label = "";

        //switch �` case�́A��������
        //�^����ꂽ�l�ɑ΂��āAcase �ԍ��֕��򂷂�B
        //�킩��Ղ������΁u�I�����v�Ɠ��`�B
        //���̏ꍇ�Am_TriggerState����r�l�ŁA
        //�Ⴆ�΁Am_TriggerState�̒l���A1(�܂�m_TriggerState��Enter(ID��1)�Ȃ�)
        //case 1:(���̏ꍇ�Acase TriggerState.Enter:)���I�΂��B
        //m_TriggerState�͗񋓌^�Ȃ̂ŁAm_TriggerState.Enter��ID�Ƃ���1�ɊY������
        //���ׁ̈A�v���O���}�Ƃ��āAID�ԍ��Y��Ă��A.��łĂ�ID������Ƃ���
        //�e�ؐ݌v�ł��B
        switch (m_TriggerState)
        {
            case TriggerState.Enter:
                label = "�ڐG�J�n (Trigger)";
                break;
            case TriggerState.Stay:
                label = "�ڐG�� (Trigger)";
                break;
            case TriggerState.Exit:
                label = "�ڐG�I�� (Trigger)";
                break;
            default:
                return;
        }

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.red;
        style.fontStyle = FontStyle.Bold;

        Handles.Label(labelPos, label, style);
    }
#endif
}
