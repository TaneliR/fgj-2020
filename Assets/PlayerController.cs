using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 500f;
    public Rigidbody2D rb;
    public Rigidbody2D rightTela;
    public Rigidbody2D leftTela;

    float movementRight;
    float movementLeft;
    // Update is called once per frame
    void Update()
    {
        movementRight = Input.GetAxisRaw("Horizontal");
        movementLeft = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        rightTela.AddForce(transform.up * movementRight * moveSpeed * Time.fixedDeltaTime);
        leftTela.AddForce(transform.up * movementLeft * moveSpeed * Time.fixedDeltaTime);
    }
}
