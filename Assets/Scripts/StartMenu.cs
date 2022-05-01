using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

// #if UNITY_EDITOR 
//  using UnityEditor;
// #endif 

public class StartMenu : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    public static int selectedSkin = 0;   
    public GameObject playerskin;

    private void Start()
    {
        NextOption();
        BackOption();
    }

    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;
        if(selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }
        sr.sprite = skins[selectedSkin];
        Debug.Log(selectedSkin);
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;
        if(selectedSkin < 0)
        {
            selectedSkin = skins.Count - 1;
        }
        sr.sprite = skins[selectedSkin];
        Debug.Log(selectedSkin);
    }

    public void SelectVirtualBoy()
    {
        sr.sprite = skins[0];
    }

    public void SelectPinkMan()
    {
        sr.sprite = skins[1];
    }

    public void SelectNinjaFrog()
    {
        sr.sprite = skins[2];
    }

    public void SelectMaskDude()
    {
        sr.sprite = skins[3];
    }

    public int getSelectedSkin()
    {
        return selectedSkin;
    }


    public void StartGame()
    {
        Debug.Log(selectedSkin);
        // PrefabUtility.SaveAsPrefabAsset(playerskin, "Assets/selectedskin.prefab");
        SceneManager.LoadScene("Level 1");
    }

    
}
