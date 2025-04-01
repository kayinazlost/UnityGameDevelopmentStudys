using UnityEngine;

/// <summary>
/// GizmoBox�F�w��ʒu�ɃT�C�Y�ύX�\�ȃL���[�u�̃M�Y����\������N���X�B
/// </summary>
public class GizmoBox : MonoBehaviour
{
    [Header("�L���[�u�̃T�C�Y")]
    public Vector3 m_CubeSize = new Vector3(1f, 1f, 1f);

    [Header("�M�Y���̐F")]
    public Color m_GizmoColor = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = m_GizmoColor;
        Gizmos.DrawCube(transform.position, m_CubeSize);
    }
}
