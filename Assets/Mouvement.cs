using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    private Animator anm;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anm = GetComponent<Animator>();
    }

    void Update()
    {

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");


        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);


        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.3f);
        }


        if (verticalInput != 0 || horizontalInput != 0)
        {
            anm.SetBool("move", true);
        }
        else
        {
            anm.SetBool("move", false);

        }
    }
}
