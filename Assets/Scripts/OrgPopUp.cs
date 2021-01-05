using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrgPopUp : MonoBehaviour
{

    public GameObject orgPopUp;

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D col){
        if((col.tag == "Player")){
            SoundManager.PlaySound("openTrashbin");
            orgPopUp.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void ThrowOrgTrash(){
        GameMaster.ThrowOrg(true);
        SoundManager.PlaySound("buttonClick");
        orgPopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ThrowAnorgTrash(){
        GameMaster.ThrowAnorg(false);
        SoundManager.PlaySound("buttonClick");
        orgPopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ThrowB3Trash(){
        GameMaster.ThrowB3(false);
        SoundManager.PlaySound("buttonClick");
        orgPopUp.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Close(){
        orgPopUp.SetActive(false);
        SoundManager.PlaySound("buttonClick");
        Time.timeScale = 1f;
    }
}
