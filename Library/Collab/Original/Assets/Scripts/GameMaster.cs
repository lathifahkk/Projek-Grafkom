using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;

    public GameObject live1;
    public GameObject live2;
    public GameObject live3;
    public static int lives = 3;

    public Text b3Text;
    public Text organicText;
    public Text inorganicText;
    public Text scoreText;
    public Text winScoreText;

    public GameObject gameOver;
    public GameObject PoinKurang;
    public GameObject NyawaHabis;
    public GameObject Win;

    public static int B3 = 0; 
    public static int Organic = 0; 
    public static int Inorganic = 0; 
    public static int trash = 0;
    public static int score = 0;
    public static int scorelive = 0;
    
    public bool life = true;
    static bool poinMin = false;
    static bool win = false;

    public Transform playerPrefab;
    public Transform spawnPoint;
    public int spawnDelay = 1;

    
    

    void Start(){
        if(gm == null) {
            gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameMaster>();
        }
    }

    void Update(){
        if(lives > 3) lives = 3;
        if(lives == 3){
            live1.gameObject.SetActive(true);
            live2.gameObject.SetActive(true);
            live3.gameObject.SetActive(true);
        }
        else if(lives == 2){
            live1.gameObject.SetActive(true);
            live2.gameObject.SetActive(true);
            live3.gameObject.SetActive(false);
        }
        else if(lives == 1){
            live1.gameObject.SetActive(true);
            live2.gameObject.SetActive(false);
            live3.gameObject.SetActive(false);
        }
        else if(lives <= 0){
            live1.gameObject.SetActive(false);
            live2.gameObject.SetActive(false);
            live3.gameObject.SetActive(false);
        }

        if(lives <= 0){
            gameOver.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }

        if(poinMin){
            PoinKurang.gameObject.SetActive(true);
            NyawaHabis.gameObject.SetActive(false);
        } else{
            PoinKurang.gameObject.SetActive(false);
            NyawaHabis.gameObject.SetActive(true);
        }

        if(win){
            Win.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }  

        b3Text.text = B3.ToString();
        organicText.text = Organic.ToString();
        inorganicText.text = Inorganic.ToString();
        scoreText.text = score.ToString();
        winScoreText.text = score.ToString();
    }

    public void TryAgain(){
        SceneManager.LoadScene("SampleScene");
        lives = 3;
        Organic = 0; Inorganic = 0; B3 = 0;
        score = 0; scorelive = 0;
        poinMin = false;
        win = false;
        gameOver.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void LevelPicker(){
        //SceneManager.LoadScene("SampleScene");
        Debug.Log("GO TO Level Picker");
        lives = 3;
        Organic = 0; Inorganic = 0; B3 = 0;
        score = 0; scorelive = 0;
        poinMin = false;
        win = false;
        gameOver.gameObject.SetActive(false);
        Win.gameObject.SetActive(false);

        Time.timeScale = 1f;
    }

    public void NextLevel(){
        SceneManager.LoadScene("Level2");
        Debug.Log("GO TO Next Level");
        lives = 3;
        Organic = 0; Inorganic = 0; B3 = 0;
        score = 0; scorelive = 0;
        win = false;
        Win.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public static void DecLives(){
        lives -= 1;
    }
	
	public static void IncLives(){
		if (scorelive >=100){
		lives += 1;
		scorelive -= 100;
		}
	}
	
    public IEnumerator RespawnPlayer(){
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(playerPrefab.gameObject, spawnPoint.position, spawnPoint.rotation);
    }

    public static void KillPlayer(Idle player){
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer());
    }

    public static void PickUpB3(){
        B3 += 1;
    }

    public static void PickUpOrg(){
        Organic += 1;
    }

    public static void PickUpAnorg(){
        Inorganic += 1;
    }

    public static void ThrowOrg(bool stat){
        if(stat){
            score += Organic *10;
            scorelive += Organic *10;
            IncLives();
        } 
        Organic -= Organic;    
    }

    public static void ThrowAnorg(bool stat){
        if(stat){
            score += Inorganic*10;
            scorelive += Inorganic*10;
            IncLives();
        }     
        Inorganic -= Inorganic;
    }
    
    public static void ThrowB3(bool stat){
        if(stat){
            score += B3*10;
            scorelive += B3*10;
            IncLives();
        }
        B3 -= B3;  
    }

    public static void CollectEnemyPoint(){
        score += 5;
        scorelive += 5;
        IncLives();
    }
    
    public static void isWin(){
		if(score < 100) {
			//Game Over
            lives = 0;
            poinMin = true;
		}else{
            win = true;
        }
		
		
	}
	
}
