using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// CollisionStateVisualizer01�F���̂Ƃ̐ڐG��Ԃ����m���A
/// �M�Y����Ɂu�ڐG�J�n�v�u�ڐG���v�u���E�v��Y+1�ʒu�ɕ\������N���X�B
/// </summary>
public class CollisionStateVisualizer01 : MonoBehaviour
{
    /// <summary>
    /// ��Ԃ�\���񋓌^
    /// �񋓌^�́A�w�肻�ꂽ���O��ID(�ԍ�)���A������悤�Ȃ��́B
    /// �܂��A�o�Ȕԍ��ƁA���O(���x��)���A�����Ă�����̂��ƍl����΂悢�B
    /// ���ʂ̂��̂ł���΁A
    /// None = 0�AEnter = 1�AStay = 2�AExit = 3�ƂȂ�B
    /// ����͌�XAI�ŃX�e�[�gAI���w�ԍۂɂ悭���p�����̂Ŋo���Ă�����!
    /// </summary>
    private enum CollisionState
    {
        None,       //������
        Enter,      //�ڐG����
        Stay,       //�ڐG��
        Exit        //�ڐG���痣�ꂽ
    }

    [SerializeField]
    [Header("���݂̃R���W�������")]
    private CollisionState m_CollisionState = CollisionState.None;

    // ��������������������������������������������������������������
    // �Փ˃C�x���g�Q
    // ��������������������������������������������������������������
    /// <summary>
    /// �ڐG�����u��
    /// </summary>
    /// <param name="collision">�ڐG�Ώ�</param>
    private void OnCollisionEnter(Collision collision)
    {
        //�ڐG�����̂ŁAEnter��������
        m_CollisionState = CollisionState.Enter;
    }
    /// <summary>
    /// �ڐG��
    /// </summary>
    /// <param name="collision">�ڐG�Ώ�</param>
    private void OnCollisionStay(Collision collision)
    {
        //�ڐG���Ȃ̂ŁAStay��������
        m_CollisionState = CollisionState.Stay;
    }
    /// <summary>
    /// �ڐG���痣�ꂽ
    /// </summary>
    /// <param name="collision">�ڐG�Ώ�</param>
    private void OnCollisionExit(Collision collision)
    {
        //�ڐG���痣�ꂽ�̂ŁAExit��������
        m_CollisionState = CollisionState.Exit;
    }

#if UNITY_EDITOR
    // ��������������������������������������������������������������
    // �M�Y���ŏ�Ԃ�Y+1�̈ʒu�ɕ����\��
    // ��������������������������������������������������������������
    private void OnDrawGizmos()
    {
        Vector3 labelPos = transform.position + Vector3.up * 1.0f;

        string label = "";

        //switch �` case�́A��������
        //�^����ꂽ�l�ɑ΂��āAcase �ԍ��֕��򂷂�B
        //�킩��Ղ������΁u�I�����v�Ɠ��`�B
        //���̏ꍇ�Am_CollisionState����r�l�ŁA
        //�Ⴆ�΁Am_CollisionState�̒l���A1(�܂�m_CollisionState��Enter(ID��1)�Ȃ�)
        //case 1:(���̏ꍇ�Acase m_CollisionState.Enter:)���I�΂��B
        //m_CollisionState�͗񋓌^�Ȃ̂ŁAm_CollisionState.Enter��ID�Ƃ���1�ɊY������
        //���ׁ̈A�v���O���}�Ƃ��āAID�ԍ��Y��Ă��A.��łĂ�ID������Ƃ���
        //�e�ؐ݌v�ł��B
        switch (m_CollisionState)
        {
            case CollisionState.Enter:
                label = "�ڐG�J�n (Collision)";
                break;
            case CollisionState.Stay:
                label = "�ڐG�� (Collision)";
                break;
            case CollisionState.Exit:
                label = "�ڐG�I�� (Collision)";
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
