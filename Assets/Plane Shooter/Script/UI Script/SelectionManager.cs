using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] characterPrefabs;

    void Start()
    {
        LoadCharacter();
    }


    void Update()
    {

    }

    private void LoadCharacter()
    {
        int characterIndex = PlayerPrefs.GetInt("CharacterIndex");
        Instantiate(characterPrefabs[characterIndex], transform.position, Quaternion.identity);
    }
}
