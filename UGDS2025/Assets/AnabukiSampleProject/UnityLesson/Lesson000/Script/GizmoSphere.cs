using UnityEngine;

/// <summary>
/// GizmoSphere�F�w��ʒu�ɃT�C�Y�ύX�\�ȋ��̂̃M�Y����\������N���X�B
/// </summary>
public class GizmoSphere : MonoBehaviour
{
    [Header("���̂̔��a")]
    public float m_SphereRadius = 1.0f;

    [Header("�M�Y���̐F")]
    public Color m_GizmoColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = m_GizmoColor;
        Gizmos.DrawSphere(transform.position, m_SphereRadius);
    }
}
