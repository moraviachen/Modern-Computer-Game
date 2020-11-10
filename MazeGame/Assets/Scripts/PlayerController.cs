using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    public float Speed =20.0f;
    public float jump=100f;
    public float Gravity = 9.8f;
    private float velocity = 0;
    private Camera cam;
    private Rigidbody rb;

    
 
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        rb=GetComponent<Rigidbody>();
        cam=Camera.main;
    }
 
    void Update()                                                                              
    {
        // get player input 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //update the direction according to the camera rotation
        var facing=cam.transform.eulerAngles.y;

        Vector3 input= new Vector3(horizontal*Speed,0,vertical*Speed);
        Vector3 finalInput = Quaternion.Euler(0, facing, 0) * input;

        characterController.Move(finalInput * Time.deltaTime);
 

        //set jump
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.AddForce(Vector3.up*jump, ForceMode.Impulse);
        }

        // check whether the player is in air
        //if the player is in air, change the velocity
        if(characterController.isGrounded){
            velocity = 0;
        }else{
            velocity -= Gravity * Time.deltaTime;
            characterController.Move(new Vector3(0, velocity, 0));
        }
    }
}