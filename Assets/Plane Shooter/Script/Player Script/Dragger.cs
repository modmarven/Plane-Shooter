using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    public bool IsDragging;

    private Collider2D collider2d;
    private PlayerDragnDrop dragController;
    public PlayerHealthBar healthBar;
    public CoinCount coinCount;
    public UiController uiController;


    private float minX = -4.0f, maxX = 4;
    private float minY = -9.40f, maxY = 9.0f;

    [SerializeField]
    private float paddingX = 1.6f;
    [SerializeField]
    private float paddingY = 1.8f;

    public GameObject explosion;

    public float health = 20.0f;
    private float barFillAmount = 1.0f;
    private float damage = 0.0f;

    [SerializeField]
    private GameObject damageEffect;


    void Start()
    {
        collider2d = GetComponent<Collider2D>();
        dragController = FindObjectOfType<PlayerDragnDrop>();
        damage = barFillAmount / health;
    }

    private void Update()
    {
        LimitPosition();
        FindBoundaries();
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "EnemyBullet")
        {
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVFX = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVFX, 0.2f);
            if (health <= 0)
            {
                uiController.GameOver();
                Destroy(gameObject);
                GameObject explosionVFX = Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(explosionVFX, 0.4f);
            }
            
        }

        if (collision.gameObject.tag == "Coin")
        {
            Destroy(collision.gameObject);
            coinCount.AddCoin();
        }

        Dragger colliderDragger = collision.GetComponent<Dragger>();

        if (colliderDragger != null && dragController.lastDragged.gameObject == gameObject)
        {
            ColliderDistance2D colliderDistance2D = collision.Distance(collider2d);
            Vector3 different = new Vector3(colliderDistance2D.normal.x, colliderDistance2D.normal.y) * colliderDistance2D.distance;
            transform.position -= different;
        }

    }

    private void LimitPosition()
    {
        Vector3 playerPosX = transform.position;
        playerPosX.x = Mathf.Clamp(playerPosX.x, minX, maxX);
        transform.position = playerPosX;

        Vector3 playerPosY = transform.position;
        playerPosY.y = Mathf.Clamp(playerPosY.y, minY, maxY);
        transform.position = playerPosY;

    }

    private void FindBoundaries()
    {
        Camera worldCam = Camera.main;
        minX = worldCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + paddingX;
        maxX = worldCam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - paddingX;
        // X position view to world point

        minY = worldCam.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + paddingY;
        maxY = worldCam.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - paddingY;
        /// Y position view to world point
    }

    private void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barFillAmount = barFillAmount - damage;
            healthBar.SetAmount(barFillAmount);
        }
    }

}
