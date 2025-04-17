using UnityEngine;

public class DamageSystem001 : MonoBehaviour
{
    [Header("与えるダメージポイント")]
    public int m_Damage = 1;
    [Header("爆発エフェクト")]
    public GameObject m_Effect;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.GetComponent<Parameta001>())
        {
            collision.transform.GetComponent<Parameta001>().AddDamage(m_Damage);
            GameObject Dummy = Instantiate(m_Effect, this.transform.position, this.transform.rotation);
            Destroy(Dummy, 5.0f);
            Destroy(this.gameObject);
        }
    }
}
