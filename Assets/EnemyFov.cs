using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{
    public float rotationSpeed;
    public float distance;

    public LineRenderer lineOfSightCenter;
    public LineRenderer lineOfSightLeft;


    void Start(){
        Physics2D.queriesStartInColliders = false;

    }
    void Update() {

        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        RaycastHit2D hitInfoLeft = Physics2D.Raycast(transform.position, transform.right, distance);

        if (hitInfo.collider != null){
            lineOfSightCenter.SetPosition(1, hitInfo.point);
            lineOfSightLeft.SetPosition(2, hitInfoLeft.point);
            
            if(hitInfo.collider.CompareTag("Player")){
                Destroy(hitInfo.collider.gameObject);
            }
        } else {
            lineOfSightCenter.SetPosition(1, transform.position + transform.right * distance);
            lineOfSightLeft.SetPosition(2, transform.position + transform.right * distance);
        }
        

        lineOfSightCenter.SetPosition(0, transform.position);
        lineOfSightLeft.SetPosition(0, transform.position);

    }
}
