using UnityEngine;
//#if UNITY_EDITOR�`#endif�́AUnity�G�f�B�^�[�ł݂̂��̈͂��Ă���͈͂����s���Aexe���̃G�f�B�^�[�ł͖�����΁A���̏����𖳎�����
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// GizmoCapsule�F�G�f�B�^��ŃT�C�Y�ύX�\�ȃJ�v�Z���̃M�Y����`�悷��N���X�B
/// ��Handles���g������Editor��ł̂ݕ`�悳���B
/// </summary>
public class GizmoCapsule : MonoBehaviour
{
    [Header("�J�v�Z���̔��a")]
    public float m_Radius = 0.5f;

    [Header("�J�v�Z���̍���")]
    public float m_Height = 2f;

    [Header("�M�Y���̐F")]
    public Color m_GizmoColor = Color.cyan;
//#if UNITY_EDITOR�`#endif�́AUnity�G�f�B�^�[�ł݂̂��̈͂��Ă���͈͂����s���Aexe���̃G�f�B�^�[�ł͖�����΁A���̏����𖳎�����
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = m_GizmoColor;
        // Handles.DrawWireDisc�́A�~��`�����߁A���W(���_),����,���a�ŉ~��`���܂�
        Handles.DrawWireDisc(transform.position + Vector3.up * (m_Height / 2f - m_Radius), transform.forward, m_Radius);
        Handles.DrawWireDisc(transform.position - Vector3.up * (m_Height / 2f - m_Radius), transform.forward, m_Radius);
        // Handles.DrawLine�́A����`�����߁A�X�^�[�g���W(���_),�G���h���W(���_)�ŁA����`���܂�
        Handles.DrawLine(transform.position + Vector3.up * (m_Height / 2f - m_Radius) + Vector3.right * m_Radius,
                         transform.position - Vector3.up * (m_Height / 2f - m_Radius) + Vector3.right * m_Radius);
        Handles.DrawLine(transform.position + Vector3.up * (m_Height / 2f - m_Radius) - Vector3.right * m_Radius,
                         transform.position - Vector3.up * (m_Height / 2f - m_Radius) - Vector3.right * m_Radius);
        Handles.DrawLine(transform.position + Vector3.up * (m_Height / 2f - m_Radius) + Vector3.forward * m_Radius,
                         transform.position - Vector3.up * (m_Height / 2f - m_Radius) + Vector3.forward * m_Radius);
        Handles.DrawLine(transform.position + Vector3.up * (m_Height / 2f - m_Radius) - Vector3.forward * m_Radius,
                         transform.position - Vector3.up * (m_Height / 2f - m_Radius) - Vector3.forward * m_Radius);
    }
#endif
}
