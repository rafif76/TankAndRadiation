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

    public TextMeshProUGUI levelText;



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
        PlayerPrefs.SetInt("level", level++);
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
                    setValueForwaitForSeconds(8);
                    setValueForMovementEnemySpeed(10f);

                    Debug.Log(" LEVEL " + i + " pada if terdeteksi");


                }
                else if (i == 3)
                {
            //directionalLightMatiin

            Material otherSkyboxMaterial = Resources.Load<Material>("Assets/Custom/Custom Dark Material for Skybox.mat");
                 setValueForwaitForSeconds(8);
            changeSky(otherSkyboxMaterial);



                 Debug.Log(" LEVEL " + i + " pada if terdeteksi");
                 setValuePowerTime(3f);



                }
                else if (i == 4)
                {

            //directionalLightMatiin
            //SkyGanti.
            //syk dome disable
            //object montain yang menglilingi di disable atau gak di agak bawahin
            Material otherSkyboxMaterial = Resources.Load<Material>("Assets/Snow_mountain/snow_mountain/Materials/Snow_mountain_t1_2.mat");
            

            

            setValueForwaitForSeconds(6);
                    setValueForMovementEnemySpeed(35f);
                     setValuePowerTime(5f);

                 Debug.Log(" LEVEL " + i + " pada if terdeteksi");

                }
                else if (i == 5)
                {   
            
                    setValuePowerTime(12f);
                    setValueForwaitForSeconds(6);
                    setValueForMovementEnemySpeed(35f);
                    spawnManager2object.SetActive(true);
            
                    Debug.Log(" LEVEL " + i + " pada if terdeteksi");


        }



        // PR BLOM di otak atik
                else if (i == 6)
                {
                    setValueForwaitForSeconds( 4);
                 
                    setValuePowerTime(16f);

                spawnManager3object.SetActive(true);
                spawnManager2object.SetActive(true);
                Debug.Log(" LEVEL " + i + " pada if terdeteksi");

                }
                else if (i == 7)
                {
                    setValueForwaitForSeconds(4);
      
                 setValueForMovementEnemySpeed(35f);
                 setValuePowerTime(18f);

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

