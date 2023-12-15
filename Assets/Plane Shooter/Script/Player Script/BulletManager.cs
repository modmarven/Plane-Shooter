using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
