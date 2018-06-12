using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FirstPersonController : MonoBehaviour
{


    public float movementSpeed = 5.0f;
    public float mouseSensitivity = 5.0f;
    float verticalRotation = 0;
    public float upDownRange = 60.0f;
    float verticalVelocity = 0;
    CharacterController characterController;
    public float jumpSpeed = 20.0f;
    public AudioClip jumpSound;
    public AudioClip stepsSound;
    private AudioSource soundSource;

    void Awake()
    {

        soundSource = GetComponent<AudioSource>();


    }
    void Start()
    {
        // Screen.lockCursor = true;
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.timeScale != 0)
        {
            //ROTATION
            float rotLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity; //yaw. we cannot do up-down view like this because playercontroller do not move pitch
            transform.Rotate(0, rotLeftRight, 0); //now when we rotate the mouse it works but still going forward not to the new direction. 
            //to do that we need to modify speed according to player's rotation


            verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;  //pitch
            verticalRotation = Mathf.Clamp(verticalRotation, -upDownRange, upDownRange);
            Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);





            //MOVEMENT
            float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
            float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

            verticalVelocity += Physics.gravity.y * Time.deltaTime;

            if (characterController.isGrounded && Input.GetButton("Jump"))
            {
                soundSource.PlayOneShot(jumpSound);

                    verticalVelocity = jumpSpeed;
            }

            if (characterController.isGrounded && characterController.velocity.magnitude > 2f && soundSource.isPlaying == false)
            {
                soundSource.volume = Random.Range(0.0f, 1);
                soundSource.pitch = Random.Range(0.8f, 1.1f);
                soundSource.PlayOneShot(stepsSound);
            }



            //first number 0 is for left-right, second0 is for up-down, third one is backward-forward
            //   Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed); //our forward move is going to be on the z axis 

            Vector3 speed = new Vector3(sideSpeed, verticalVelocity, forwardSpeed);

            speed = transform.rotation * speed;   //to modify speed with player's rotation


            characterController.Move(speed * Time.deltaTime);

        }

    }

}