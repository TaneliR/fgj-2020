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
    public GameControl gameControl;
    public float oilAmount = 100f;
    float rotate;
    float move;
    // Update is called once per frame
    void Update()
    {
        // gameControl.SetOilBar(oilAmount);
        // oilAmount -= 0.01f; 
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if (Input.GetKey("i") && Input.GetKey("o")){
            transform.Translate(Vector3.up * Time.fixedDeltaTime);
        }
        if (Input.GetKey("k") && Input.GetKey("l")){
            transform.Translate(Vector3.down * Time.fixedDeltaTime);
        }
        if (Input.GetKey("k") && Input.GetKey("o")){
            transform.Rotate(new Vector3(0,0,1 * rotationSpeed * Time.fixedDeltaTime));
        }
        if (Input.GetKey("i") && Input.GetKey("l")){
            transform.Rotate(new Vector3(0,0,-1 * rotationSpeed * Time.fixedDeltaTime));
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnCollisionEnter2D");
        
        if (col.gameObject.tag == "scrap") {
             Destroy (col.gameObject);
             gameControl.IncreaseScore(1);
        }
    }
}
