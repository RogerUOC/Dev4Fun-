using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

[System.Serializable]
//Interfaz margenes juego
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

    

public class PlayerController : MonoBehaviour
{
    //Variable velocidad
    public float speed;
    //Variable inclinacion nave
    public float tilt;
    //Variable no salir margenes
    public Boundary boundary;   
    //Variable control nave
    private Rigidbody rig;

    // Start is called before the first frame update
    void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizonatal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizonatal, 0f, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector3(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), 0f, Mathf.Clamp(rig.position.z, boundary.zMin, boundary.zMax));
        rig.rotation = Quaternion.Euler(0f, 0f, rig.velocity.x * -tilt);

    }
}
