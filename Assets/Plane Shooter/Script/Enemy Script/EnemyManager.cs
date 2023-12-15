using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private Transform gunPointLeft;
    [SerializeField]
    private Transform gunPointRight;

    public GameObject enemyBulletPrefabs;
    public float bulletSpawnTime = 0.5f;

    [SerializeField]
    private GameObject muzzleFlash;
    public float muzzleFlashSpawnTime = 0.3f;

    [SerializeField]
    private float enemySpeed = 5.0f;
    public GameObject enemyExplosion;

    public GameObject coinPrefabs;

    private void Start()
    {
        muzzleFlash.SetActive(false);
        StartCoroutine(ShootEnemy());
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.up * enemySpeed * Time.fixedDeltaTime);
    }

    private void EnemyShoot()
    {
        Instantiate(enemyBulletPrefabs, gunPointLeft.position, Quaternion.identity);
        Instantiate(enemyBulletPrefabs, gunPointRight.position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            Instantiate(coinPrefabs, transform.position, Quaternion.identity);
            Destroy(gameObject);
            GameObject explosion = Instantiate(enemyExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 0.4f);
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
