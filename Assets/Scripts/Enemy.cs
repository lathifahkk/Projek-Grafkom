using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool life = true;
    public GameObject trashbag;

    void Update(){
        if (life == false){
            Instantiate(trashbag, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
    
    public void TakeDamage(){
        life = false;
    }
}
