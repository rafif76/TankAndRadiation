using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
     int level;
    public GameObject spawnManager2object;
    private MoveFoward moveFoward;
    public GameObject spawnManager3object;
    public Material newSkyboxMaterial; // Assign your new Skybox material in the Inspector
    public GameObject gameObject;
    private SpawnManager spawnManager;



    public int intPowerUpTransferdatabetweenScript;
    public float floatMovementdatabetweenScript;
    public float repeatTimePowerUpbetweenScript;
    public float speedDecreaseBetweenScript;
    public float MaxPlayerGoesMeterBetweenScript;


    public TextMeshProUGUI levelText;

    private Material otherSkyboxMaterial;
    bool boolean = true;

 

    // Start is called before the first frame update
    void Start()
    {


        moveFoward = FindObjectOfType<MoveFoward>();
        spawnManager = FindObjectOfType<SpawnManager>();

        if (SceneManager.GetActiveScene().name == "PersonalProjectRafif Main Menu dan Level 1")
        {
            level = 1;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.Save();


        }
        else
        {
            level = PlayerPrefs.GetInt("level", level);
        }



        levelText.text = "Level : " + level.ToString();

        levelManaging();



    }

    // Update is called once per frame
    void Update()
    {

    }


    //JANGAN LUPA DIPANGGIL DI TOMBOL NEXT!!!!
    public void levelnext()
    {

        level++;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();


    }

    private void setValueForwaitForSeconds(int data)
    {

        intPowerUpTransferdatabetweenScript = data;
    } 
    
    private void setValueForMovementEnemySpeed(float data)
    {

        floatMovementdatabetweenScript = data;
    }


    private void setValuePowerTime(float data)
    {

        repeatTimePowerUpbetweenScript = data;
    }

    private void speedtime(float data)
    {

        speedDecreaseBetweenScript = data;
    }

    public void levelManaging( )
    {


        //combined between menu and misc gameplay stuff



        // SIBANGQ ini eror, karena dia manggil variabl waitForSecondsPublicVariableFun yang bahkan belum ada di scene. krn object Player blom
        //spawn
        int i = level;

        if (i == 0 )
        {
            //continuebuton.continue disapper
            //
        }

        //yg buat ngatur rasio waktu spawn power, Agak bug! Dia yg pake spawnManager(active), ga akan menghasilkan log.!
        else if (i == 1)
                {
                  
                    setValueForwaitForSeconds(10);
                    Debug.Log(" LEVEL " + i + " pada if terdeteksi");
                }

               else if (i == 2)
                {
               // otherSkyboxMaterial = Resources.Load<Material>("Assets/Free HDR Skyboxes Pack/Material/sky-1.mat");
                //changeSky(otherSkyboxMaterial);

                  



            setValueForwaitForSeconds(8);
                    setValueForMovementEnemySpeed(10f);

                   
                    Debug.Log(" LEVEL " + i + " pada if terdeteksi");
                    

                }
                else if (i == 3)
                {

                //directionalLightMatiin
                otherSkyboxMaterial = Resources.Load<Material>("Assets/Free HDR Skyboxes Pack/Material/sky-1.mat");


                 


                setValueForwaitForSeconds(8);
                Debug.Log(" LEVEL " + i + " pada if terdeteksi");
                setValuePowerTime(3f);
                speedtime(2);


        }
             else if (i == 4)
                {

            //directionalLightMatiin
            //SkyGanti.
            //syk dome disable
            //object montain yang menglilingi di disable atau gak di agak bawahin

             

               
                    


            otherSkyboxMaterial = Resources.Load<Material>("Assets/Snow_mountain/snow_mountain/Materials/Snow_mountain_t1_2.mat");

            setValueForwaitForSeconds(6);
                    setValueForMovementEnemySpeed(35f);
                     setValuePowerTime(5f);
                speedtime(4);
                 Debug.Log(" LEVEL " + i + " pada if terdeteksi");

        

        }
        else if (i == 5)
                {


          

            setValuePowerTime(12f);
                    setValueForwaitForSeconds(6);
                    setValueForMovementEnemySpeed(35f);
                     speedDecreaseBetweenScript = 6;
                    MaxPlayerGoesMeterBetweenScript = 500f;



                spawnManager2object.SetActive(true);

                    Debug.Log(" LEVEL " + i + " pada if terdeteksi");
                

        }



        // PR BLOM di otak atik
        else if (i == 6)
                {


            if (i != 6)
            {
                SceneManager.LoadScene("Level 5 - 8");
                boolean = false;
            }

            setValueForwaitForSeconds( 4);
                 setValueForMovementEnemySpeed(15f);

            setValuePowerTime(16f);
                speedtime(7);

                spawnManager3object.SetActive(true);
                spawnManager2object.SetActive(true);
                Debug.Log(" LEVEL " + i + " pada if terdeteksi");


        }
        else if (i == 7)
                {

            if (i != 7)
            {
                SceneManager.LoadScene("Level 5 - 8");
                boolean = false;
            }

            setValueForwaitForSeconds(4);
      
                 setValueForMovementEnemySpeed(35f);
                 setValuePowerTime(18f);
            speedtime(8);

            MaxPlayerGoesMeterBetweenScript = 1000f;


            spawnManager3object.SetActive(true);
                 spawnManager2object.SetActive(true);
                Debug.Log(" LEVEL " + i + " pada if terdeteksi");
            



        }
        else if (i == 8)
                {
  
                setValueForMovementEnemySpeed(50f);
                setValueForwaitForSeconds(2);

                  setValuePowerTime(20f);
                spawnManager3object.SetActive(true);
                 spawnManager2object.SetActive(true);
                 Debug.Log(" LEVEL " + i + " pada if terdeteksi");
            speedtime(10);


        } 




    }

    public void sceneChanger()
    {

        int i = level;

        if (i == 0)
        {
            //continuebuton.continue disapper
            //
        }

        
        else if (i == 2)
        {
            if (SceneManager.GetActiveScene().name != "Level 2-5")
            {
                SceneManager.LoadScene("Level 2-5");

            }
        }
        else if (i == 3)
        {
            if (SceneManager.GetActiveScene().name != "Level 2-5 Edited Enviroment")
            {
                SceneManager.LoadScene("Level 2-5 Edited Enviroment");
            }

        } else if (i == 4)
        {
            SceneManager.LoadScene("Level 2-5 Edited Enviroment");

        }
        else if (i == 5)
        {
            if (SceneManager.GetActiveScene().name != "Level 5 - 8")
            {
                SceneManager.LoadScene("Level 5 - 8");
            }


        }
        else if (i == 6)
        {
            SceneManager.LoadScene("Level 5 - 8");

        }
        else if (i == 7)
        {
            SceneManager.LoadScene("Level 5 - 8");

        }
        else if (i == 8)
        {

        }
    }

        private void changeSky(Material material)
    {
       
            // Ganti Skybox
            RenderSettings.skybox = material;

            // Memaksa pembaruan untuk melihat perubahan
            DynamicGI.UpdateEnvironment();
   
    }

   }

