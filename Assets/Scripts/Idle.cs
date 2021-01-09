using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idle : MonoBehaviour
{
    public float speed;
    Rigidbody2D aff;
    public bool isGrounded = false;
    public bool isTouchingEnemy = false;
    bool facingRight = true;
    private Animator anim;
    public int fallBoundary = -5;
    public int lives = 3;

    void flip(){
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        aff = GetComponent<Rigidbody2D> ();
        //SoundManager.PlaySound("start");        
    }

    // Update is called once per frame
    void Update()
    {
        //jump
       if(Input.GetButtonDown("Jump") && isGrounded == true){
            aff.AddForce(new Vector2(0f, 8.5f), ForceMode2D.Impulse);
            SoundManager.PlaySound("jump");
        }  

        if(transform.position.y <= fallBoundary){
            GameMaster.DecLives();
            GameMaster.KillPlayer(this);
        }

        if(isTouchingEnemy){
            GameMaster.DecLives();
            GameMaster.KillPlayer(this);
        }

    }
    
    void FixedUpdate(){
        //move horizontal
		float move = Input.GetAxis("Horizontal");
		aff.velocity = new Vector2 (speed*move, aff.velocity.y);
        
        //animation transition - idle <-> run
        if(move == 0) anim.SetBool("isRunning",false);
        else anim.SetBool("isRunning",true);
        
        //flip player
        if(move < 0 && facingRight) flip(); 
        else if(move > 0 && !facingRight) flip(); 

        if(aff.velocity.y <= 0.5 && aff.velocity.y >= -0.5){
            anim.SetBool("isJumping",false);
            anim.SetBool("isFalling",false);
        }

        if(aff.velocity.y > 0.5){
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling",false);
        }

        if(aff.velocity.y < -0.5){
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
        }
	}
    
	    //collect Trash
    public void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "TrashB3")
		{
            SoundManager.PlaySound("pickTrash");
			Destroy(col.gameObject);
			GameMaster.PickUpB3();
		}
	    else if(col.tag == "TrashOrganic")
		{
            SoundManager.PlaySound("pickTrash");
			Destroy(col.gameObject);
			GameMaster.PickUpOrg();
		}
	    else if(col.tag == "TrashInorganic")
		{
            SoundManager.PlaySound("pickTrash");
			Destroy(col.gameObject);
			GameMaster.PickUpAnorg();
		}



        if(col.gameObject.CompareTag("Trashbag")){
            SoundManager.PlaySound("pickTrash");
            Destroy(col.gameObject);
            GameMaster.CollectEnemyPoint();
        }

        if(col.tag == "enemy"){
            isTouchingEnemy = true;
        }
        
        if(col.tag == "CheckPoint"){
			GameMaster.isWin();
        }	
	}

    private void OnTriggerExit2D(Collider2D col) {
        if(col.tag == "enemy"){
            isTouchingEnemy = false;
        }
    }
	
}
