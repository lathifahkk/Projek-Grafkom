using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B3PopUp : MonoBehaviour
{
    public GameObject b3PopUp;

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col){
        if((col.tag == "Player")){
            b3PopUp.SetActive(true);
            SoundManager.PlaySound("openTrashbin");
            Time.timeScale = 0f;
            //col.enabled = false;
        }
    }

    public void ThrowOrgTrash(){
        GameMaster.ThrowOrg(false);
        SoundManager.PlaySound("buttonClick");
        b3PopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ThrowAnorgTrash(){
        GameMaster.ThrowAnorg(false);
        SoundManager.PlaySound("buttonClick");
        b3PopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ThrowB3Trash(){
        GameMaster.ThrowB3(true);
        SoundManager.PlaySound("buttonClick");
        b3PopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close(){
        b3PopUp.SetActive(false);
        SoundManager.PlaySound("buttonClick");
        Time.timeScale = 1f;
    }
}
