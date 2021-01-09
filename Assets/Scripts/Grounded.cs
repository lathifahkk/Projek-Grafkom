using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject groundCheck;

    // Start is called before the first frame update
    void Start()
    {
        groundCheck = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            groundCheck.GetComponent<Idle>().isGrounded = true;
        }

        if(collision.collider.tag == "enemy"){
            groundCheck.GetComponent<Idle>().isTouchingEnemy = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision){
        if(collision.collider.tag == "Ground"){
            groundCheck.GetComponent<Idle>().isGrounded = false;
        }

        if(collision.collider.tag == "enemy"){
            groundCheck.GetComponent<Idle>().isTouchingEnemy = false;
        }
    }

    
}
