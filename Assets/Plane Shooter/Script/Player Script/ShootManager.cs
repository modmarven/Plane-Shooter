using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefabs;

    public Transform spawnPointLeft;
    public Transform spawnPointRight;

    public GameObject muzzleFlash;

    public float bulletSpawnTime = 1.0f;
    public float muzzleFlashSpawn = 0.5f;

    void Start()
    {
        muzzleFlash.SetActive(false);
        StartCoroutine(Shooting());
    }

    void Update()
    {

    }

    void WeaponFire()
    {
            Instantiate(bulletPrefabs, spawnPointLeft.position, Quaternion.identity);
            Instantiate(bulletPrefabs, spawnPointRight.position, Quaternion.identity);
    }

    IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            WeaponFire();
            muzzleFlash.SetActive(true);
            yield return new WaitForSeconds(muzzleFlashSpawn);
            muzzleFlash.SetActive(false);
        }
       
    }
}
