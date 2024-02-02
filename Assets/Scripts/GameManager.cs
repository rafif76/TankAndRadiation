using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;




public class GameManager : MonoBehaviour
{

    public int level = 0;
    public GameObject MissionComplete;


    public Button buttonPlayGame;
    public int waitforSeconds = 10;

    private void Update()
    {

    }

        public void GameOver()
    {
        MissionComplete.SetActive(true);
    }

    private void nextLevel()
    {
        PlayerBehaviourScript playerBehaviourScript = FindObjectOfType<PlayerBehaviourScript>();

        for (int i = 0; i < level; i++) {

            waitforSeconds = -2;
        }

    }

    


    //kode dan logika lama
        private void levelload(int oldlevel)
    {
        MoveFoward moveFoward = FindObjectOfType<MoveFoward>();
        oldlevel = level -1;

        if (oldlevel < level)
        {
           // moveFoward.speed = +10f;

        }

        //utang naro angka 1 pertambahan level, ketrigger by click button next

    }


    public void nextLevelTrigger()
    {
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.level = +1;
    }


    // Start is called before the first frame update


    // Update is called once per frame

}
