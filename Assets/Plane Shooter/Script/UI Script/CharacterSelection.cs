using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefab;
    private int characterIndex;

    [SerializeField]
    private List<ShootManager> shootManager;
    [SerializeField]
    private List<PlaneFanRotate> fanRotate;
    public List<GameObject> muzzleFlash;

    void Start()
    {
        foreach (var script in shootManager)
        {
            if (script != null)
            {
                script.enabled = false;
            }
        }
        foreach (var script in fanRotate)
        {
            if (script != null)
            {
                script.enabled = false;
            }
        }
        foreach (var gameObject in muzzleFlash)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(false);
            }
        }
    }

    
    void Update()
    {
        
    }

    public void ChangeCharacter(int index)
    {
        for (int i = 0; i < characterPrefab.Length; i++ )
        {
            characterPrefab[i].SetActive(false);
        }
        this.characterIndex = index;
        characterPrefab[index].SetActive(true);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("LEVEL 01");
        PlayerPrefs.SetInt("CharacterIndex", characterIndex);

        foreach (var script in shootManager)
        {
            if (script != null)
            {
                script.enabled = true;
            }
        }
        
        foreach (var script in fanRotate)
        {
            if ( script != null)
            {
                script.enabled = true;
            }
        }
        
        foreach (var gameObject in muzzleFlash)
        {
            if (gameObject != null)
            {
                gameObject.SetActive(true);
            }
        }
    }
}
