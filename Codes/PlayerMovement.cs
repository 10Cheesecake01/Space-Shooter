using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Creating movement for the player ship.
    public float maxSpeed = 5f;
    public float rotSpeed = 180f;

    float ShipBoundaryRadius = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating the ship.
        Quaternion rot = transform.rotation;  //Grab the quaternion.
        float z = rot.eulerAngles.z;  //Grab the z angle.
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;  //Change the z axis on input.
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;

        //Moving the ship.
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);
        pos += rot * velocity;

        //Hold the player in the camera's position.
        if(pos.y + ShipBoundaryRadius > Camera.main.orthographicSize) //Vertical boundary being fixed.
        {
            pos.y = Camera.main.orthographicSize - ShipBoundaryRadius;
        }
        if(pos.y - ShipBoundaryRadius < -Camera.main.orthographicSize)
        {
            pos.y = -Camera.main.orthographicSize + ShipBoundaryRadius;
        }

        float screenRatio = (float)Screen.width / (float)Screen.height;  //Calculating the orthographicsize of the screen.
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if(pos.x + ShipBoundaryRadius > widthOrtho) //Horizontal boundary being fixed.
        {
            pos.x = widthOrtho - ShipBoundaryRadius;
        }
        if(pos.x - ShipBoundaryRadius < -widthOrtho)
        {
            pos.x = -widthOrtho + ShipBoundaryRadius;
        }
        transform.position = pos;
        

    }
}
