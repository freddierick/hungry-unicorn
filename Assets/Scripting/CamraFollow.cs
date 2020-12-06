using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamraFollow : MonoBehaviour
{
    public Transform Player;
    public float camraDistance = 30.0f;
    public float CameraHight = 3;
    public float xBoder = -100;
    public float z2DOffset = -10;


    void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / camraDistance);
    }

    void FixedUpdate()
    {
        if (Player.position.x< xBoder)
        {
            transform.position = new Vector3(xBoder, Player.position.y + CameraHight, z2DOffset);
        }
        else
        {
            transform.position = new Vector3(Player.position.x, Player.position.y+CameraHight, z2DOffset);
        }
    }
}
