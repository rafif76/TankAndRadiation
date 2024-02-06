using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{


    public GameObject[] cars;
    public GameObject powerUp;
    public GameObject player;
    LevelManager levelManager;


    public TextMeshProUGUI gameOverText;

    float spawnPosZ = 63;
    float spawnPosZmax = 380;
    float spawnPosX = 63;
    float spawnPosY = 0;
    float powerPosX = 40;
    float powerPosX2 = 67;

    public float startSpawning = 0.2f;
    public float startSpawningPow = 3f;
    private float repeatRatePow = 4f;



    private bool once = false;

    // public float spawningInterval = 1.5f;
    public float repeatRate = 0.1f;
    // public float minSpawningInterval = 1.0f;
    // public float maxSpawningInterval = 2.0f;


    private int maxSpawnCount = 5;
    private int currentSpawnCount = 0;




    private void Start()
    {

    


        //InvokeRepeating("SpawnRandomCars", startSpawning, Random.Range(minSpawningInterval, maxSpawningInterval));
        InvokeRepeating("SpawnRandomCars", startSpawning, repeatRate);
        InvokeRepeating("SpawnPowerUp", startSpawningPow, repeatRatePow);


          currentSpawnCount = powerUp.transform.childCount;



        once = true;


    }

    void FixedUpdate()
    {

        detectSumOfPowerUp();

        if (once)
        {
            Instantiate(player, Vector3.zero, Quaternion.identity);
           
        levelManager = FindObjectOfType<LevelManager>();
        time(levelManager.repeatTimePowerUpbetweenScript);
        Debug.Log(" repeatpow " + repeatRatePow);

            once = false;
        }
    }

    private void time(float time)
    {
        repeatRatePow += time;
     

    }



    public void spawnFirstTime()
    {
        once = true;
    }

    // Function untuk memicu spawn Player (2)
    public void SpawnPlayer()
    {
        Instantiate(player, Vector3.zero, Quaternion.identity);
    }


    private void detectSumOfPowerUp()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("PowerUp");
         currentSpawnCount = objectsWithTag.Length;

    }
   



    void SpawnRandomCars ()
    {
        // spawn cars

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, Random.Range(spawnPosZ,spawnPosZmax));

        int carsIndex = Random.Range(0, cars.Length); // <- ini gajadi diubah jadi public, karena alasan kebutuhan PlayerBehaviourScript mau manggil partikel

       
      
        Instantiate(cars[carsIndex], spawnPos, cars[carsIndex].transform.rotation);

    }
    void SpawnPowerUp()
    {
        // spawn powerup
        if (currentSpawnCount < maxSpawnCount)
        {
            Instantiate(powerUp, GenerateSpawnPosition(), transform.rotation);
            Debug.Log("Spawned Prefab: " + currentSpawnCount);
        }
      

    }


    private Vector3 GenerateSpawnPosition()
    {
        float spawnPostX = Random.Range(-powerPosX, powerPosX2);
        float spawnPostZ = Random.Range(spawnPosZ, spawnPosZmax);
        Vector3 randomPos = new Vector3(spawnPostX, 3, spawnPostZ);

        return randomPos;

    }

    // Function untuk memicu spawn Player (1)
    public void SpawnPlayer(int playerToSpawn) 
        //int untuk trigger dan siapin for. cerdas. (kodingan Modul Makul Game)
    {
        for (int i = 0; i < playerToSpawn; i++)
        {

            Instantiate(player, GeneratSpawnPosition(), transform.rotation);



        }
    }

    private Vector3 GeneratSpawnPosition()
    {

        Vector3 randomPos = new Vector3(0, 0, 0);

        return randomPos;

    }


}
