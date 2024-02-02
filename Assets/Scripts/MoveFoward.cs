using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    private float speed =15f;
    LevelManager levelManager;



    private void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

        speedss(levelManager.floatMovementdatabetweenScript);

    }



    // Update is called once per frame
    void Update()
    {
    
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
    }


    private void speedss(float speeds)
    {
        speed += speeds;
    }
        
}
