using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// TriggerStateVisualizer01：トリガー接触の状態を検知し、
/// 「接触開始」「接触中」「接触終了」をY+1の位置にギズモ表示するクラス。
/// </summary>
public class TriggerStateVisualizer01 : MonoBehaviour
{
    /// <summary>
    /// 状態を表す列挙型
    /// 列挙型は、指定それた名前とID(番号)が連動するようなもの。
    /// まぁ、出席番号と、名前(ラベル)が連動しているものだと考えればよい。
    /// 下位のものであれば、
    /// None = 0、Enter = 1、Stay = 2、Exit = 3となる。
    /// これは後々AIでステートAIを学ぶ際によく利用されるので覚えておこう!
    /// </summary>
    private enum TriggerState
    {
        None,       //未反応
        Enter,      //接触した
        Stay,       //接触中
        Exit        //接触から離れた
    }

    [SerializeField]
    [Header("現在のトリガー状態")]
    private TriggerState m_TriggerState = TriggerState.None;

    // ───────────────────────────────
    // トリガーイベント群
    // ───────────────────────────────
    /// <summary>
    /// 接触した
    /// </summary>
    /// <param name="other">接触対象</param>
    private void OnTriggerEnter(Collider other)
    {
        //接触したので、Enterを代入する
        m_TriggerState = TriggerState.Enter;
    }
    /// <summary>
    /// 接触中
    /// </summary>
    /// <param name="other">接触対象</param>
    private void OnTriggerStay(Collider other)
    {
        //接触中なので、Stayを代入する
        m_TriggerState = TriggerState.Stay;
    }
    /// <summary>
    /// 接触から離れた
    /// </summary>
    /// <param name="other">接触対象</param>
    private void OnTriggerExit(Collider other)
    {
        //接触から離れたので、Exitを代入する
        m_TriggerState = TriggerState.Exit;
    }

#if UNITY_EDITOR
    // ───────────────────────────────
    // ギズモで状態をY+1の位置に表示
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Vector3 labelPos = transform.position + Vector3.up * 1.0f;

        string label = "";

        //switch ～ caseは、条件分岐
        //与えられた値に対して、case 番号へ分岐する。
        //わかり易く言えば「選択肢」と同義。
        //この場合、m_TriggerStateが比較値で、
        //例えば、m_TriggerStateの値が、1(つまりm_TriggerStateがEnter(IDは1)なら)
        //case 1:(この場合、case TriggerState.Enter:)が選ばれる。
        //m_TriggerStateは列挙型なので、m_TriggerState.EnterはIDとして1に該当する
        //その為、プログラマとして、ID番号忘れても、.を打てばIDが判るという
        //親切設計です。
        switch (m_TriggerState)
        {
            case TriggerState.Enter:
                label = "接触開始 (Trigger)";
                break;
            case TriggerState.Stay:
                label = "接触中 (Trigger)";
                break;
            case TriggerState.Exit:
                label = "接触終了 (Trigger)";
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
