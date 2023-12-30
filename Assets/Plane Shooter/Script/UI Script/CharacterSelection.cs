using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    public SpriteRenderer render;
    public List<Sprite> sprites = new List<Sprite>();
    private int selectSkin = 0;
    public GameObject playerSkin;
    public ShootManager shootManager;

    private void Start()
    {
        shootManager.enabled = false;
    }

    public void NextCharacter()
    {
        selectSkin = selectSkin + 1;
        if (selectSkin == sprites.Count)
        {
            selectSkin = 0;
        }
        render.sprite = sprites[selectSkin];
        
    }

    public void BackCharacter()
    {
        selectSkin = selectSkin - 1;
        if (selectSkin < 0)
        {
            selectSkin = sprites.Count - 1;
        }
        render.sprite = sprites[selectSkin];
        
    }

    public void PlayGame()
    {    
            shootManager.enabled = true;
            PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Plane.prefab");
            SceneManager.LoadScene("LEVEL 01");      
    }
}
