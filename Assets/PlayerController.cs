using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 50f;
    public Rigidbody2D rb;
    public Rigidbody2D rightTela;
    public Rigidbody2D leftTela;

    float rotate;
    float move;
    // Update is called once per frame
    void Update()
    {
        rotate = Input.GetAxisRaw("Horizontal");
        move = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
            rb.velocity = move * transform.up * moveSpeed * Time.fixedDeltaTime;
            transform.Rotate(new Vector3(0,0,-rotate * rotationSpeed * Time.fixedDeltaTime));

        if (Input.GetKeyDown("a") && Input.GetKeyDown("d"))
        {
        }
        else if (Input.GetKeyDown("a") || Input.GetKeyDown("d"))
        {
        }
        // rightTela.AddForce(transform.up * movementRight * moveSpeed * Time.fixedDeltaTime);
        // leftTela.AddForce(transform.up * movementLeft * moveSpeed * Time.fixedDeltaTime);
    }
}
