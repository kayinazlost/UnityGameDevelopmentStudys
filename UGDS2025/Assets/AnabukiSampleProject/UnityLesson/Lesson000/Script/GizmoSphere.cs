using UnityEngine;

/// <summary>
/// GizmoSphere：指定位置にサイズ変更可能な球体のギズモを表示するクラス。
/// </summary>
public class GizmoSphere : MonoBehaviour
{
    [Header("球体の半径")]
    public float m_SphereRadius = 1.0f;

    [Header("ギズモの色")]
    public Color m_GizmoColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = m_GizmoColor;
        Gizmos.DrawSphere(transform.position, m_SphereRadius);
    }
}
