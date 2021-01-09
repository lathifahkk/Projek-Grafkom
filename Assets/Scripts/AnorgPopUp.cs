using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnorgPopUp : MonoBehaviour
{
    public GameObject anorgPopUp;

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col){
        if((col.tag == "Player")){
            anorgPopUp.SetActive(true);
            SoundManager.PlaySound("openTrashbin");
            Time.timeScale = 0f;
            //col.enabled = false;
        }
    }

    public void ThrowOrgTrash(){
        GameMaster.ThrowOrg(false);
        SoundManager.PlaySound("buttonClick");
        anorgPopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ThrowAnorgTrash(){
        GameMaster.ThrowAnorg(true);
        SoundManager.PlaySound("buttonClick");
        anorgPopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ThrowB3Trash(){
        GameMaster.ThrowB3(false);
        SoundManager.PlaySound("buttonClick");
        anorgPopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close(){
        anorgPopUp.SetActive(false);
        SoundManager.PlaySound("buttonClick");
        Time.timeScale = 1f;
    }
}
