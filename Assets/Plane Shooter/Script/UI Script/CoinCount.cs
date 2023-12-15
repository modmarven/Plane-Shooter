using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class CoinCount : MonoBehaviour
{
    public TextMeshProUGUI coinCountText;
    private int count = 0;
    
    void Start()
    {
        coinCountText = FindObjectOfType<TextMeshProUGUI>();
    }

    
    void Update()
    {
        coinCountText.text = count.ToString();
    }

    public void AddCoin()
    {
        count++;
    }
}
