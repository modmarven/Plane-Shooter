using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Transform healthBar;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void SetBarScale(float size)
    {
        healthBar.localScale = new Vector2(size, 1f);
    }
}
