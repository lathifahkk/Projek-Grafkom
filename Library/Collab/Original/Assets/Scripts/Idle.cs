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
    public int B3 = 0; 
    public int Organic = 0; 
    public int Inorganic = 0; 
    public int trash = 0;
    public int lives = 3;
    public Text trashtext;
    

    void flip(){
        facingRight = !facingRight;
        transform.Rotate(0f,180f,0f);
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator> ();
        aff = GetComponent<Rigidbody2D> ();
        
    }

    // Update is called once per frame
    void Update()
    {
        //jump
       if(Input.GetButtonDown("Jump") && isGrounded == true){
            aff.AddForce(new Vector2(0f, 8.5f), ForceMode2D.Impulse);
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

   /* private void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.CompareTag("trash")){
            Destroy(col.gameObject);
        }

        if(col.gameObject.CompareTag("Trashbag")){
            Destroy(col.gameObject);
            Debug.Log("TRASHMAN HAS COLLECT ENEMY, ADD POINT!");
        }
    }
    * */
    
	    //collect Trash
    private void OnTriggerEnter2D(Collider2D col) {
		if(col.tag == "TrashB3")
		{
			Destroy(col.gameObject);
			B3 += 1;
			trash +=1;
			trashtext.text = trash.ToString() ;
		}
	    else if(col.tag == "TrashOrganic")
		{
			Destroy(col.gameObject);
			Organic += 1;
			trash +=1;
			trashtext.text = trash.ToString() ;
		}
	    else if(col.tag == "TrashInorganic")
		{
			Destroy(col.gameObject);
			Inorganic += 1;
			trash +=1;
			trashtext.text = trash.ToString() ;
		}
		

        if(col.gameObject.CompareTag("Trashbag")){
            Destroy(col.gameObject);
            Debug.Log("TRASHMAN HAS COLLECT ENEMY, ADD POINT!");
        }

        if(col.tag == "enemy"){
            isTouchingEnemy = true;
            trash -= trash ;
            trashtext.text = trash.ToString() ;
        }
	}

    private void OnTriggerExit2D(Collider2D col) {
        if(col.tag == "enemy"){
            isTouchingEnemy = false;
        }
    }
	
}
