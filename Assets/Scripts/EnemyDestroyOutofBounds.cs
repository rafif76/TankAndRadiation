using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDestroyOutofBounds : MonoBehaviour
{



    public float topBounds = 71f;
    public float lowerBounds = -47f;
    public float yLowerBounds = -5f;






    // Update is called once per frame
    void Update()
    {
     
        {
         

            if (transform.position.x > topBounds)

            {
                Destroy(gameObject);
               
            }
            if (transform.position.x < lowerBounds)
            {
                Destroy(gameObject);
         


            }
            if (transform.position.y < yLowerBounds)

            {
                Destroy(gameObject);
            

            }


        }

    }



   
}

