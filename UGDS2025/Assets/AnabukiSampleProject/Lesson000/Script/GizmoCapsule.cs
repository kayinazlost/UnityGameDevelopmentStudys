using UnityEngine;
//#if UNITY_EDITOR～#endifは、Unityエディターでのみこの囲っている範囲を実行し、exe等のエディターでは無ければ、この処理を無視する
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// GizmoCapsule：エディタ上でサイズ変更可能なカプセルのギズモを描画するクラス。
/// ※Handlesを使うためEditor上でのみ描画される。
/// </summary>
public class GizmoCapsule : MonoBehaviour
{
    [Header("カプセルの半径")]
    public float m_Radius = 0.5f;

    [Header("カプセルの高さ")]
    public float m_Height = 2f;

    [Header("ギズモの色")]
    public Color m_GizmoColor = Color.cyan;
//#if UNITY_EDITOR～#endifは、Unityエディターでのみこの囲っている範囲を実行し、exe等のエディターでは無ければ、この処理を無視する
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = m_GizmoColor;
        // Handles.DrawWireDiscは、円を描く命令、座標(原点),向き,半径で円を描きます
        Handles.DrawWireDisc(transform.position + Vector3.up * (m_Height / 2f - m_Radius), transform.forward, m_Radius);
        Handles.DrawWireDisc(transform.position - Vector3.up * (m_Height / 2f - m_Radius), transform.forward, m_Radius);
        // Handles.DrawLineは、線を描く命令、スタート座標(原点),エンド座標(原点)で、線を描きます
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
