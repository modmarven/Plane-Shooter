using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefab;
    private int characterIndex;

    void Start()
    {
        
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
    }
}
