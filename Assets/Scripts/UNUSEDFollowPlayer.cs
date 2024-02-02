using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UNUSEDFollowPlayer : MonoBehaviour
{

    public GameObject Player;
    public Camera Camera;

    /*
     * SKRIP JENIS INI PUNYA KELEMAHAN.
     * YAITU, DIA GABISA DI PAKE KE OBJEK PREFAB.
     * 
     * 
     */


    Vector3 offsetKamera = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    // Function untuk tiap detik frame, kamera ikuti player.
    void LateUpdate()
    {
        if (Player != null)  // Pastikan Player tidak null untuk menghindari kesalahan
        {
            transform.position = Player.transform.position + offsetKamera;
        }
    }


}
