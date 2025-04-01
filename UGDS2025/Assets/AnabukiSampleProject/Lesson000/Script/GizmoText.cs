// このスクリプトを任意のGameObjectにアタッチすれば、Sceneビュー上に名前が表示されます
using UnityEngine;
using UnityEditor; // Handlesを使うにはEditor名前空間が必要

[ExecuteInEditMode] // エディタ上でもスクリプトが実行されるようにする
public class GizmoText : MonoBehaviour
{
    [Header("ギズモに表示させる文字")]
    public string m_ObjectMessage;
    [Header("ギズモに表示させる文字の色")]
    public Color32 m_TextColor;
    // Sceneビューでギズモ描画
    private void OnDrawGizmos()
    {
        // テキストの表示位置（オブジェクトのちょっと上）
        Vector3 LabelPosition = transform.position + Vector3.up * 0.15f;

        // ラベルのスタイル（フォントサイズなどを設定できる）
        GUIStyle style = new GUIStyle();
        style.normal.textColor = m_TextColor;
        style.fontSize = 14;
        style.fontStyle = FontStyle.Bold;

        // Handles.LabelでSceneビューに文字を描く（エディタ専用）
        Handles.Label(LabelPosition, $"🪧 {m_ObjectMessage}", style);
    }
}
