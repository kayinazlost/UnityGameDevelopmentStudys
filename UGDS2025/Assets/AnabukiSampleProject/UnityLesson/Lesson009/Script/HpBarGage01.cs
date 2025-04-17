using UnityEngine;
using UnityEngine.UI;

public class HpBarGage01 : MonoBehaviour
{
    [Header("HPバーゲージ用Image")]
    public Image m_HpGage;
    [Header("HP数値")]
    public Text m_HitPintText;
    [Header("HPを獲得する対象")]
    public Parameta001 m_Parameta;
    void Start()
    {
        //HPバーゲージが設定されていない場合、自身がHPバーゲージのImageであるならそれとリンクする
        if (!m_HpGage)
        {
            //Imageを取り込む
            m_HpGage = GetComponent<Image>();
            //初期はHPバーゲージを0とする。
            m_HpGage.fillAmount = 0.0f;
        }
        //HPテキストがない場合、今回は【GameObjectの名前】からリンクをセットする
        if (!m_HitPintText)
        {
            //ヒエラルキー内のGameObjectで「HPテキスト」という名前のGameObjectを探し、Dummyに代入
            GameObject Dummy = GameObject.Find("HPテキスト");
            //Dummy内のコンポーネント(プログラム)に「Text」がある場合は、m_HitPointTextにリンク代入、文字は0に
            if (Dummy.GetComponent<Text>())
            {
                m_HitPintText = Dummy.GetComponent<Text>();
                m_HitPintText.text = "0";
            }
        }
    }

    void Update()
    {
        //HPバーゲージがセットしていない
        if (!m_HpGage || !m_HitPintText)
        {
            Debug.LogError("HPバーゲージ、HPテキストがセットされていません!!");
            return;
        }
        //もし、HPバーゲージとパラメーターが設定されている場合のみ起動
        if (m_Parameta)
        {
            //現在のHPが0以上である
            if (m_Parameta.m_Hp > 0)
            {
                //HPテキストに数値を代入(もし、float型だった場合はint値にするのがベスト)
                int Dummy = m_Parameta.m_Hp;
                m_HitPintText.text = Dummy.ToString();
                //HPが最大HPを超えている場合、バーゲージは最大値、それ以外なら、割合を出して代入
                if (m_Parameta.m_Hp <= m_Parameta.m_MaxHp)
                    m_HpGage.fillAmount = (1.0f / m_Parameta.m_MaxHp) * m_Parameta.m_Hp;
                else
                    m_HpGage.fillAmount = 1.0f;
            }
            else
            {
                m_HpGage.fillAmount = 0.0f; //それ以外は、HP0なので、バーゲージは0
                m_HitPintText.text = "0";
            }
        }
        else
        {
            m_HpGage.fillAmount = 0.0f; //対象がいないので、バーゲージは0
            m_HitPintText.text = "0";
        }
    }
}
