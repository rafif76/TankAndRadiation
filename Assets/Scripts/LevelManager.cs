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


    public int intPowerUpTransferdatabetweenScript;
    public float floatMovementdatabetweenScript;
    public float repeatTimePowerUpbetweenScript;

    public TextMeshProUGUI levelText;



    // Start is called before the first frame update
    void Start()
    {
        moveFoward = FindObjectOfType<MoveFoward>();

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

                    setValueForwaitForSeconds(8);
               

            Debug.Log(" LEVEL " + i + " pada if terdeteksi");
                   setValuePowerTime(3f);



                }
                else if (i == 4)
                {
                    setValueForwaitForSeconds(6);
                    setValueForMovementEnemySpeed(35f);
                     setValuePowerTime(5f);

            Debug.Log(" LEVEL " + i + " pada if terdeteksi");

                }
                else if (i == 5)
                {
                    setValueForwaitForSeconds(6);
                    setValueForMovementEnemySpeed(35f);
                    spawnManager2object.SetActive(true);
            
                    Debug.Log(" LEVEL " + i + " pada if terdeteksi");
            setValuePowerTime(12f);
                

        }

        // PR BLOM di otak atik
        else if (i == 6)
                {
                    setValueForwaitForSeconds( 4);
                    spawnManager3object.SetActive(true);
                    spawnManager2object.SetActive(true);
            setValuePowerTime(16f);


            Debug.Log(" LEVEL " + i + " pada if terdeteksi");

                }
                else if (i == 7)
                {
                    setValueForwaitForSeconds(4);
            spawnManager3object.SetActive(true);
            spawnManager2object.SetActive(true);
            setValueForMovementEnemySpeed(35f);
            setValuePowerTime(18f);


            Debug.Log(" LEVEL " + i + " pada if terdeteksi");


                }
                else if (i == 8)
                {
            spawnManager3object.SetActive(true);
            spawnManager2object.SetActive(true);
            setValueForMovementEnemySpeed(50f);
            setValueForwaitForSeconds(2);

            setValuePowerTime(20f);

            Debug.Log(" LEVEL " + i + " pada if terdeteksi");

                }




            }
        }

