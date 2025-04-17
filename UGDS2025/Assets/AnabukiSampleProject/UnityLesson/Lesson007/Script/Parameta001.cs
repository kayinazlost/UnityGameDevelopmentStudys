using UnityEditor;
using UnityEngine;

public class Parameta001 : MonoBehaviour
{
    [Header("耐久力")]
    public int m_Hp;
    [Header("最大耐久力")]
    public int m_MaxHp;
    [Header("このフレームで受けたダメージ")]
    public int m_DamagePoint;

    [Header("ギズモに表示させる文字")]
    public string m_ObjectMessage;
    [Header("ギズモに表示させる文字の色")]
    public Color32 m_TextColor;
    void Start()
    {
        m_Hp = m_MaxHp;
        m_DamagePoint = 0;
        m_ObjectMessage = "Hp:" + m_Hp.ToString();
    }

    void LateUpdate()
    {
        if (m_Hp > 0 && m_DamagePoint > 0)
        {
            m_Hp -= m_DamagePoint;
            if (m_Hp <= 0)
            {
                m_Hp = 0;
                m_ObjectMessage = "死亡";
            }
            else
                m_ObjectMessage = "Hp:" + m_Hp.ToString();
            m_DamagePoint = 0;
        }
    }
    public void AddDamage(int DamagePoint)
    {
        if (m_Hp > 0)
        {
            m_DamagePoint += DamagePoint;
        }
    }

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
