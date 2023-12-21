using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondEnemyManager : MonoBehaviour
{
    [SerializeField]
    private Transform gunPointCenter;

    public GameObject enemyBulletPrefabs;
    public float bulletSpawnTime = 0.5f;

    [SerializeField]
    private GameObject muzzleFlash;
    public float muzzleFlashSpawnTime = 0.3f;

    [SerializeField]
    private float enemySpeed = 5.0f;
    public GameObject enemyExplosion;

    public GameObject coinPrefabs;
    public EnemyHealthBar enemyHealthBar;

    public float health = 10f;

    float bar = 1f;
    float damage = 0f;

    private void Start()
    {
        muzzleFlash.SetActive(false);
        StartCoroutine(ShootEnemy());
        damage = bar / health;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * enemySpeed * Time.deltaTime);
    }

    private void EnemyShoot()
    {
        Instantiate(enemyBulletPrefabs, gunPointCenter.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            DamageHealth();
            Destroy(collision.gameObject);
            if (health <= 0)
            {
                Instantiate(coinPrefabs, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
                Destroy(explosion, 0.4f);
            }
            
        }
    }

    public void DamageHealth()
    {
        if (health > 0)
        {
            health -= 1;
            bar = bar - damage;
            enemyHealthBar.SetBarScale(bar);
        }
    }

    IEnumerator ShootEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            EnemyShoot();
            muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(muzzleFlashSpawnTime);
            muzzleFlash.SetActive(false);

        }

    }
}
