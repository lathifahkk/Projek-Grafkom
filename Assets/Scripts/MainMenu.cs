using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public GameObject popUpExit;
    public GameObject popUpCredit;
    public GameObject popUpRule;
    public Button[] levelButton;


    // Start is called before the first frame update
    void Start()
    {
       int levelAt = PlayerPrefs.GetInt("levelAt",0);
       for (int i = 0; i<levelButton.Length; i++){
           if(i > levelAt) levelButton[i].interactable = false;
       }

    }

    public void Mulai(){
        SoundManager.PlaySound("buttonClick");
        SceneManager.LoadScene("levelPicker");       
    } 
    public void Rule(){
        SoundManager.PlaySound("buttonClick");
        popUpRule.gameObject.SetActive(true);
        //Debug.Log("LOAD RULE PAGE + TOMBOL YANG DIPAKE");      
    }

    public void ExitRule(){
        SoundManager.PlaySound("buttonClick");
        popUpRule.gameObject.SetActive(false);
        //Debug.Log("LOAD RULE PAGE + TOMBOL YANG DIPAKE");      
    }

    public void Keluar(){
        SoundManager.PlaySound("buttonClick");
        popUpExit.gameObject.SetActive(true);
    } 

    public void BackToMainMenu(){
        SoundManager.PlaySound("buttonClick");
        SceneManager.LoadScene("WelcomePage");
    } 
    public void Credit(){
        SoundManager.PlaySound("buttonClick");
        popUpCredit.gameObject.SetActive(true);
        //Debug.Log("LOAD CREDITS POP UP");
    }

    public void ExitCredit(){
        SoundManager.PlaySound("buttonClick");
        popUpCredit.gameObject.SetActive(false);
        //Debug.Log("LOAD RULE PAGE + TOMBOL YANG DIPAKE");      
    } 

    public void Level1(){
        SoundManager.PlaySound("buttonClick");
        SceneManager.LoadScene("SampleScene");
        BGM.StopBGM();  
    }

    public void Level2(){
        SoundManager.PlaySound("buttonClick");
        SceneManager.LoadScene("Level2");
        BGM.StopBGM();   
    }

    public void Level3(){
        SoundManager.PlaySound("buttonClick");
        SceneManager.LoadScene("Level3");
        BGM.StopBGM();   
    }

    public void yesExit(){
        SoundManager.PlaySound("buttonClick");
        Application.Quit();  
    }
    public void noExit(){
        SoundManager.PlaySound("buttonClick");
        popUpExit.gameObject.SetActive(false);  
    }
}
