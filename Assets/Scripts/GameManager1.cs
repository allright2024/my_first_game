using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public GameObject selectedskin;
    public GameObject Player;
    //private StartMenu startMenu = new StartMenu();

    private Sprite playersprite;
    void Start()
    {
        playersprite = selectedskin.GetComponent<SpriteRenderer>().sprite;

        // Debug.Log(selectedskin);
        // Debug.Log(Player);

        Player.GetComponent<SpriteRenderer>().sprite = playersprite;
    }

    /*void Update()
    {
        Debug.Log(startMenu.getSelectedSkin());
        
    }*/
}