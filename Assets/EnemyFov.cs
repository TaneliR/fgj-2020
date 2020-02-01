using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFov : MonoBehaviour
{
    public float distance;
    public float rotationSpeed;
    
    public LineRenderer lineOfSight;
    public GameObject coneOfSight;

    void Start(){
        Physics2D.queriesStartInColliders = false;

    }
    void Update() {
        
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        
    }

    /*public void LineCheck()
    {
        //RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, GameObject.FindWithTag("Player").transform.position
        //    , distance);
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, GameObject.FindWithTag("Player").transform.position, distance);
        lineOfSight.SetPosition(1, GameObject.FindWithTag("Player").transform.position);

        //lineOfSight.SetPosition(1, GameObject.FindWithTag("Player").transform.position);
            if (hitInfo.collider.gameObject != null){
                lineOfSight.SetPosition(1, hitInfo.point);
                if (gameObject.tag == "Player") {
                    Destroy(hitInfo.collider.gameObject);
                }
            } 
            
            lineOfSight.SetPosition(0, transform.position);
    }*/

}
