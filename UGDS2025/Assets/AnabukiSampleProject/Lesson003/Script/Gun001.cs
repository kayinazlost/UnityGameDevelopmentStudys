using UnityEngine;

/// <summary>
/// Gun001：マウス左クリックで弾を発射するクラス。
/// 火薬量に応じたAddForceで飛距離が変化。生成した弾は5秒後に自動破棄される。
/// Rigidbodyがなければ自動で追加。
/// </summary>
public class Gun001 : MonoBehaviour
{
    // ───────────────────────────────
    // パブリック変数（インスペクター表示）
    // ───────────────────────────────

    [Header("弾プレハブ")]
    public GameObject m_ProjectilePrefab;

    [Header("弾の発射位置")]
    public Transform m_FirePoint;

    [Header("火薬量（AddForceに使う力）")]
    public float m_ExplosiveForce = 500f;

    [Header("弾の寿命（秒）")]
    public float m_ProjectileLifetime = 5f;

    // ───────────────────────────────
    // プライベート変数（インスペクター表示）
    // ───────────────────────────────

    [SerializeField]
    [Header("弾発射方向")]
    private Vector3 m_FireDirection = Vector3.forward;

    // ───────────────────────────────
    // 毎フレームの入力処理
    // ───────────────────────────────
    private void Update()
    {
        // 左クリックで発射
        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }
    }

    // ───────────────────────────────
    // 弾の生成＆発射
    // ───────────────────────────────
    private void FireProjectile()
    {
        if (m_ProjectilePrefab == null || m_FirePoint == null)
        {
            Debug.LogWarning("ProjectilePrefabかFirePointが未設定です！");
            return;
        }

        // 弾を生成
        GameObject projectile = Instantiate(m_ProjectilePrefab, m_FirePoint.position, m_FirePoint.rotation);

        // Rigidbodyを取得または追加
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = projectile.AddComponent<Rigidbody>();
        }

        // 発射方向に力を加える（forward方向）
        m_FireDirection = m_FirePoint.forward;
        rb.AddForce(m_FireDirection * m_ExplosiveForce);

        // 一定時間で破棄
        Destroy(projectile, m_ProjectileLifetime);
    }
}
