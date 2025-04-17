using UnityEngine;

/// <summary>
/// GizmoBox：指定位置にサイズ変更可能なキューブのギズモを表示するクラス。
/// </summary>
public class GizmoBox : MonoBehaviour
{
    [Header("キューブのサイズ")]
    public Vector3 m_CubeSize = new Vector3(1f, 1f, 1f);

    [Header("ギズモの色")]
    public Color m_GizmoColor = Color.green;

    private void OnDrawGizmos()
    {
        Gizmos.color = m_GizmoColor;
        Gizmos.DrawCube(transform.position, m_CubeSize);
    }
}
