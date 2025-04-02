using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/// <summary>
/// CollisionStateVisualizer01：物体との接触状態を検知し、
/// ギズモ上に「接触開始」「接触中」「離脱」をY+1位置に表示するクラス。
/// </summary>
public class CollisionStateVisualizer01 : MonoBehaviour
{
    /// <summary>
    /// 状態を表す列挙型
    /// 列挙型は、指定それた名前とID(番号)が連動するようなもの。
    /// まぁ、出席番号と、名前(ラベル)が連動しているものだと考えればよい。
    /// 下位のものであれば、
    /// None = 0、Enter = 1、Stay = 2、Exit = 3となる。
    /// これは後々AIでステートAIを学ぶ際によく利用されるので覚えておこう!
    /// </summary>
    private enum CollisionState
    {
        None,       //未反応
        Enter,      //接触した
        Stay,       //接触中
        Exit        //接触から離れた
    }

    [SerializeField]
    [Header("現在のコリジョン状態")]
    private CollisionState m_CollisionState = CollisionState.None;

    // ───────────────────────────────
    // 衝突イベント群
    // ───────────────────────────────
    /// <summary>
    /// 接触した瞬間
    /// </summary>
    /// <param name="collision">接触対象</param>
    private void OnCollisionEnter(Collision collision)
    {
        //接触したので、Enterを代入する
        m_CollisionState = CollisionState.Enter;
    }
    /// <summary>
    /// 接触中
    /// </summary>
    /// <param name="collision">接触対象</param>
    private void OnCollisionStay(Collision collision)
    {
        //接触中なので、Stayを代入する
        m_CollisionState = CollisionState.Stay;
    }
    /// <summary>
    /// 接触から離れた
    /// </summary>
    /// <param name="collision">接触対象</param>
    private void OnCollisionExit(Collision collision)
    {
        //接触から離れたので、Exitを代入する
        m_CollisionState = CollisionState.Exit;
    }

#if UNITY_EDITOR
    // ───────────────────────────────
    // ギズモで状態をY+1の位置に文字表示
    // ───────────────────────────────
    private void OnDrawGizmos()
    {
        Vector3 labelPos = transform.position + Vector3.up * 1.0f;

        string label = "";

        //switch ～ caseは、条件分岐
        //与えられた値に対して、case 番号へ分岐する。
        //わかり易く言えば「選択肢」と同義。
        //この場合、m_CollisionStateが比較値で、
        //例えば、m_CollisionStateの値が、1(つまりm_CollisionStateがEnter(IDは1)なら)
        //case 1:(この場合、case m_CollisionState.Enter:)が選ばれる。
        //m_CollisionStateは列挙型なので、m_CollisionState.EnterはIDとして1に該当する
        //その為、プログラマとして、ID番号忘れても、.を打てばIDが判るという
        //親切設計です。
        switch (m_CollisionState)
        {
            case CollisionState.Enter:
                label = "接触開始 (Collision)";
                break;
            case CollisionState.Stay:
                label = "接触中 (Collision)";
                break;
            case CollisionState.Exit:
                label = "接触終了 (Collision)";
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
