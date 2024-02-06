using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviourScript : MonoBehaviour
{
    float speed = 20f;
    float turnSpeed = 40f;
    float horizontalInput;
    float verticalInput;
    public bool gameOver = false;
    public AudioClip crashSound;
    public AudioClip powerUpTaking;
    private AudioSource playerAudio;
    private Rigidbody playerRb;
    private Animator playerAnim;
    public GameObject powerupindicator;
    public GameObject player;
    private GameObject instancePowerIndicatorPrefab;


    private Camera mainCamera;
    [SerializeField] private GameObject particleSystems;




    private float FinishBounds = 390f;
    private float topBounds = 71f;
    private float lowerBounds = -47f;
    private float yLowerBounds = -5f;

    public bool hasPowerUp = false;
    Vector3 offsetKamera = new Vector3(0, 5, -7);
    private Vector3 initialPos = new Vector3(0, 0, 0);

    private bool triggerEntered = false;
    private int waitForSecondsPublicVariable;
    private ParticleSystem particleSystem;
    private SpawnManager spawnManager;
    private MenuManager menuManager;
    private LevelManager levelManager;
    private CarsBehaviour carsBehaviour;

    private CarsBehaviour[] carsBehaviours;

    Vector3 pos;




    /*
    * BIG MISTAKE BIG NOTES
    * 
    * Tuh kan bner, gak boleh bikin spawn2 di player behaviur script. GAKAN MUNCUL Dia.
    * Kalau mau spawn2 itu harus dipisah sama script Baru yang khusus buat spawn aja.Karena jatuhnya 
    * dia itu kaya penyelenggara gitu kayak perantara, Yang enggak boleh terilbat Langsung 
    */


    private void terimaData(int data)
    {
        waitForSecondsPublicVariable = data;
    }


    // Start is called before the first frame update
    void Start()
    {
        particleSystem = particleSystems.GetComponent<ParticleSystem>();
        spawnManager = GetComponent<SpawnManager>();


        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        //gameManager = GameObject.Find("gameOver").GetComponent<GameManager>();

        levelManager = FindObjectOfType<LevelManager>();
        menuManager = FindObjectOfType<MenuManager>();
        mainCamera = Camera.main;
        //prefabInstance = Instantiate(gameObject, Vector3.zero, Quaternion.identity);

        carsBehaviours = FindObjectsOfType<CarsBehaviour>();



        terimaData(levelManager.intPowerUpTransferdatabetweenScript);


        if (particleSystems == null)
        {
            Debug.LogError("Particle System tidak ditemukan pada game objek pemain.");
        }

    }

 
    // Update is called once per frame
    private void Update()
    {


        PlayerBounds();

        takingPos();


    }



    private void PlayerBounds()
    {



           GameManager gameManager = FindObjectOfType<GameManager>();




        {
            if (transform.position.z >= FinishBounds)
            {
                Debug.Log("Game Selesai ! Selamat !");
                //Destroy(gameObject);
                gameManager.GameOver();
                gameObject.SetActive(false);
            }

            if (transform.position.x > topBounds)

            {

                gameObject.SetActive(false);
                menuManager.callGameOverPanel();
                Debug.Log("Game Over! Payah!");
                StartCoroutine(PowerupCountdownRoutine(0, false));


            }
            if (transform.position.x < lowerBounds)
            {
                gameObject.SetActive(false);
                menuManager.callGameOverPanel();
                Debug.Log("Game Over! Payah!");
                StartCoroutine(PowerupCountdownRoutine(0, false));



            }
            if (transform.position.y < yLowerBounds)

            {
                gameObject.SetActive(false);
                menuManager.callGameOverPanel();
                Debug.Log("Game Over! Payah!");
                StartCoroutine(PowerupCountdownRoutine(0, false));


            }


        }
    }

   

    void FixedUpdate()
    {
        cameraOon();




        if (gameObject.activeSelf) //if condition for prevent codes error
        {

            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");



            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

        }

        if (triggerEntered)
        {

            // Lakukan aksi yang diinginkan di sini
            instancePowerIndicatorPrefab.transform.position = transform.position + new Vector3(0, 5f, 1);


        }


    }

    //1) Function ini tidak membutuhkan panggilan. ke khas an unity
    //2) function ini untuk ngurus Collider . kyakanya collider yang manggil
    //3) harus di gameObject terkait agar berfungsi. Jadi gak bisa Manggil antar script atau transit gitu
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Cars"))
        {

           // playerAudio.PlayOneShot(crashSound, 1.0f);

        }

        if (collision.gameObject.CompareTag("Cars") && hasPowerUp )
        {
            playerAudio.PlayOneShot(crashSound, 1.0f);
    
            Destroy(collision.gameObject);
            playParticle();

            StartCoroutine(PowerupCountdownRoutine(waitForSecondsPublicVariable, false));
        }


    }

    private void OnTriggerEnter(Collider other)
    {
          if (other.CompareTag("PowerUp"))
            {
            hasPowerUp = true;
            playerAudio.PlayOneShot(powerUpTaking, 1.0f);
            Destroy(other.gameObject);
            //powerupindicator.gameObject.SetActive(true);
            instancePowerIndicatorPrefab = Instantiate(powerupindicator, transform.position + new Vector3(0, 5f, 1), transform.rotation);
            StopAllCoroutines();
            StartCoroutine(PowerupCountdownRoutine(waitForSecondsPublicVariable, false));

            triggerEntered = true;


        }
    }

     IEnumerator PowerupCountdownRoutine(int WaitForSeconds, bool haspowerUp)
    {
        yield return new WaitForSeconds(WaitForSeconds); hasPowerUp = haspowerUp; Destroy(instancePowerIndicatorPrefab); triggerEntered =false ;
    }

   

    private void cameraOon()
    {
       
            if (gameObject != null)
            {
            // Follow the player with an offset
            mainCamera.transform.position = gameObject.transform.position + offsetKamera;
            }
   
    }

    private void takingPos()
    {

        foreach (CarsBehaviour enemyScript in carsBehaviours)
        {
            pos = enemyScript.gameObject.transform.position;


        }
    }

    private void playParticle()
    {


        int carsIndex = Random.Range(0, spawnManager.cars.Length);

        // Mainkan partikel effect.
        Instantiate(particleSystems, spawnManager.cars[carsIndex].transform.position + new Vector3(0f,0f,10f), Quaternion.identity);
            particleSystem.Play();

    }

 }