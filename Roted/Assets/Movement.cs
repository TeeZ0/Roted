using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController character;
    private Rigidbody rb;
    public float forwardSpeed = 5;
    public float backwardSpeed = 4;
    public float sidewaySpeed = 4;
    public float sprintSpeedMultiplier = 1.5f;
    public float jumpForce = 30;
    public bool isSprinting = false;
    private float curSpeed;
    // Use this for initialization
    void Start()
    {
        character = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
    }

   

    // Update is called once per frame
    void Update()
    {
       
        if (character.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Vector3 up = transform.TransformDirection(Vector3.up);
                float curJump = jumpForce * 1;
                character.SimpleMove(up * curJump);
            }
        }


        isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        if (Input.GetAxis("Vertical") > 0)
        {
            //Going forward
            if (isSprinting)
            {
                curSpeed = forwardSpeed * Input.GetAxis("Vertical");
                curSpeed *= sprintSpeedMultiplier;
            }
            else
                curSpeed = forwardSpeed * Input.GetAxis("Vertical");
        }
        else
        {
            //Going backwards
            curSpeed = backwardSpeed * Input.GetAxis("Vertical");
        }
        character.SimpleMove(forward * curSpeed);

        float curSpeed2 = sidewaySpeed * Input.GetAxis("Horizontal");
        character.SimpleMove(right * curSpeed2);
    }

   
}
    