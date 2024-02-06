using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsBehaviour : MonoBehaviour

{


    [SerializeField] private GameObject _particleSystems;
    private PlayerBehaviourScript playerBehaviourScript;
    private ParticleSystem particleSyste;


    // Start is called before the first frame update
    void Start()
    {
        playerBehaviourScript = FindObjectOfType<PlayerBehaviourScript>();
        particleSyste = _particleSystems.GetComponent<ParticleSystem>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!gameObject.activeSelf)
        {

        }

    }



  private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player") && playerBehaviourScript.hasPowerUp)
        {
            playParticle();
            // playerAudio.PlayOneShot(crashSound, 1.0f);

        }

    }



        private void playParticle()
           {
       
            // Mainkan partikel effect.
            Instantiate(_particleSystems, gameObject.transform.position, Quaternion.identity);
            particleSyste.Play();
     
    }

}





