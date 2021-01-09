using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    private Animator anim;

    private float timeBetweenShot;
    public float startTimeBetweenShot;

    void Start(){
        anim = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBetweenShot <=0){
            anim.SetBool("isAttacking", false);
            if (Input.GetKeyDown("right ctrl")){
                SoundManager.PlaySound("shoot");
                anim.SetBool("isAttacking", true);
                Instantiate(projectile.gameObject, shotPoint.position, transform.rotation);
                timeBetweenShot = startTimeBetweenShot;
            }
        }
        else
        {
            
            timeBetweenShot -= Time.deltaTime;
        }
        
    }
}
