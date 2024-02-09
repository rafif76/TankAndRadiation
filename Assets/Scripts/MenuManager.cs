using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class MenuManager : MonoBehaviour
{
   

    public GameObject panelGameOver;
    public GameObject miscManager;
    public GameObject panelmenu;
    public GameObject player;
 


    private SpawnManager spawnManager;
    LevelManager levelManager;

    void Start()
    {
        //spawnManager = new SpawnManager(); <- inisialisasi yg salah
        levelManager = FindObjectOfType<LevelManager>();
        spawnManager = FindObjectOfType<SpawnManager>();

    }



    public void callGameOverPanel()
    {

            panelGameOver.SetActive(true);

    }


    public void quitGame()
    {
        Application.Quit();
    }

    public void retryGameVoid()
    {

        //score
        //level

        panelGameOver.SetActive(false);

    }


    public void playbuttonForMenu()
    {

        //score
        //level

        SceneManager.LoadScene("Level 2-5 Edited Enviroment");


    }


    public void newGame()
    {

      
        SceneManager.LoadScene("PersonalProjectRafif Main Menu dan Level 1");


    }



  




    public void backToMenuVoid()
    {

        //fungsi ini jalan dan dipanggil via click button


         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    print("The button is working.");




    }


    public void backToMenuVoidForLevel2till5()
    {

        //fungsi ini jalan dan dipanggil via click button


        miscManager.SetActive(false);
        panelmenu.SetActive(true);


    }


    public void unloadObjectLevel1()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void unloadObjectLevel2till5()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

}
