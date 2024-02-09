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





    private float FinishBounds = 430f;
    private float topBounds = 71f;
    private float lowerBounds = -47f;
    private float yLowerBounds = -5f;
    private float rotationZLowerBounds1 = 90f;
    private float rotationZLowerBounds2 = 270f;

    public bool hasPowerUp = false;
    public bool particleHasPlayed = false;
    Vector3 offsetKamera = new Vector3(0, 5, -7);
    private Vector3 initialPos = new Vector3(0, 0, 0);

    private bool triggerEntered = false;
    private int waitForSecondsPublicVariable;
    [SerializeField] private GameObject _particleSystems;
    private ParticleSystem particleSyste;


    private SpawnManager spawnManager;
    private MenuManager menuManager;
    private LevelManager levelManager;
    private CarsBehaviour carsBehaviour;
    private MeshCollider meshCollider;


    private CarsBehaviour[] carsBehaviours;
    GameObject[] objectsWithTag;
    private float speedDecrease;

    Vector3 sudutEulerUntukRotasi;
    Quaternion rotasi;

    public float distance = -7.0f;  // Jarak antara kamera dan target
    public float height = 5.0f;  // Ketinggian kamera dari target
    public float smoothSpeed = 5.0f;  // Kecepatan perubahan posisi dan rotasi kamera


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


    private void terimaDataSpeed(float data)
    {
        speedDecrease = data;
    }

    private void terimaDataMaxDistancePlayerGoes(float data)
    {
        FinishBounds = data;
    }

    // Start is called before the first frame update
    void Start()
    {
        particleSyste = _particleSystems.GetComponent<ParticleSystem>();

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
        objectsWithTag = GameObject.FindGameObjectsWithTag("PowerUp");

      

        terimaData(levelManager.intPowerUpTransferdatabetweenScript);
        terimaDataSpeed(levelManager.speedDecreaseBetweenScript);
        managingTheFinishBound();





        if (_particleSystems == null)
        {
            Debug.LogError("Particle System tidak ditemukan pada game objek pemain.");
        }

    }

 
    // Update is called once per frame
    private void Update()
    {

    //deteksi rotasi
        rotasi = transform.rotation;
        sudutEulerUntukRotasi = rotasi.eulerAngles;


        PlayerBounds();





        Debug.Log("the power up time is " + waitForSecondsPublicVariable);


    }

    private void managingTheFinishBound()
    {
        float distance = levelManager.MaxPlayerGoesMeterBetweenScript;

        if (distance != 0)
        {

        terimaDataMaxDistancePlayerGoes(levelManager.MaxPlayerGoesMeterBetweenScript);

        }


            
    }



    private void PlayerBounds()
    {



           GameManager gameManager = FindObjectOfType<GameManager>();




        {

            if (sudutEulerUntukRotasi.z >= rotationZLowerBounds1 && sudutEulerUntukRotasi.z <= rotationZLowerBounds2)
            {


                playParticle();

                if (particleSyste.isStopped)
                {
                    gameObject.SetActive(false);
                    menuManager.callGameOverPanel();
                    Debug.Log("Game Over! Payah!");
                    StartCoroutine(PowerupCountdownRoutine(0, false));
                    particleHasPlayed = false;

                }



            }


            if (transform.position.z >= FinishBounds)
            {       
                


                Debug.Log("Game Selesai ! Selamat !");
                //Destroy(gameObject);
                gameManager.GameOver();
                gameObject.SetActive(false);

            }

            if (transform.position.x > topBounds)

            {
                playParticle();

                if (particleSyste.isStopped)
                {
                    gameObject.SetActive(false);
                    menuManager.callGameOverPanel();
                    Debug.Log("Game Over! Payah!");
                    StartCoroutine(PowerupCountdownRoutine(0, false));
                    particleHasPlayed = false;

                }
            }


            if (transform.position.x < lowerBounds)
            {         
                
                
                playParticle();

                if (particleSyste.isStopped)
                {
                    gameObject.SetActive(false);
                    menuManager.callGameOverPanel();
                    Debug.Log("Game Over! Payah!");
                    StartCoroutine(PowerupCountdownRoutine(0, false));
                    particleHasPlayed = false;
                }
        

            }



            if (transform.position.y < yLowerBounds)

            {
                playParticle();

                if (particleSyste.isStopped)
                {
                    gameObject.SetActive(false);
                    menuManager.callGameOverPanel();
                    Debug.Log("Game Over! Payah!");
                    StartCoroutine(PowerupCountdownRoutine(0, false));
                    particleHasPlayed = false;
                }



            }



        }
    }

   

    void FixedUpdate()
    {



        cameraOon();




        if (gameObject.activeSelf) //if condition for prevent codes error
        {
           //Debug.Log("speed decreaser is: " + speedDecrease);


            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");



            transform.Translate(Vector3.forward * Time.deltaTime * (speed-speedDecrease) * verticalInput);
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
            // playParticle(); <- kita mngunakan scrpt yg berisi effek prtkel di msing2 gmeobjek cars.
            meshCollider.enabled = false;

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
            playerRb.freezeRotation = true;


            triggerEntered = true;


        }
    }

     IEnumerator PowerupCountdownRoutine(int WaitForSeconds, bool haspowerUp)
    {
        yield return new WaitForSeconds(WaitForSeconds); hasPowerUp = haspowerUp; Destroy(instancePowerIndicatorPrefab) ; triggerEntered =false; playerRb.freezeRotation = false;

    }



    private void cameraOon()
    {
       
            if (gameObject != null)
            {


            // Follow the player with an offset
            // Vector3 targetPosition = gameObject.transform.position - transform.forward  * distance + Vector3.up * height;

            // Pergi dari posisi kamera saat ini ke posisi target secara perlahan
            //mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, smoothSpeed * Time.deltaTime);

            // Menghadap ke target
            //mainCamera.transform.LookAt(gameObject.transform);

            mainCamera.transform.position = transform.position + offsetKamera;
           // mainCamera.transform.LookAt(gameObject.transform);
            mainCamera.transform.rotation = transform.rotation;


        }

    }


    private void playParticle()
    {

        // Mainkan partikel effect.
        Instantiate(_particleSystems, gameObject.transform.position, Quaternion.identity);
        particleSyste.Play();
        particleHasPlayed = true;


}


}