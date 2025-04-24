using UnityEngine;

public class FireControlSystem001 : MonoBehaviour
{
    [Header("Mountクラスにリンクする")]
    public Mount001 m_Mount;
    void Start()
    {
        ///Mountクラスが存在しない場合、ゲームオブジェクトにMountクラスがあれば
        ///そのMountクラスとリンクする
        ///無い場合はエラーとしてコンソールに告知
        if (!m_Mount)
            if (GetComponent<Mount001>())
                m_Mount = GetComponent<Mount001>();
            else
                Debug.LogError(gameObject + "に、Mountクラスが存在しません");
    }

    void Update()
    {
        
    }
    /// <summary>
    /// Objectが物理的に接触した場合
    /// </summary>
    /// <param name="collision">当たった対象</param>
    private void OnCollisionExit(Collision collision)
    {
        
    }
}
