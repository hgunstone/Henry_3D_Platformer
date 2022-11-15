using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    float maxSpeed = 35.0f;
    float rotation = 0.0f;
    float camRotation = 0.0f;
    float rotationSpeed = 2.0f;
    float camRotationSpeed = 1.5f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f

    void Start()
    {
        cam =GameObject.Find("Main Camera");
    }

    void Update()
    {
        myRigidbody = GetComponent<Rigidbody>();

        Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * maxSpeed;
        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X");
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));
        
        camRotation = camRotation + Input.GetAxis("Mouse Y");
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);
    }
}
