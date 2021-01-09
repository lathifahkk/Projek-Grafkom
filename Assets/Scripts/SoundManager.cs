using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip startSound, shootSound;
    public static AudioClip destroySound, pickTrashSound;
    public static AudioClip jumpSound, openTrashbinSound;
    public static AudioClip buttonClickSound, gameOverSound;
    public static AudioClip deathSound, winSound, pauseSound;

    public GameObject sfxOn;
    public bool isMuted;

    static AudioSource audioSrc;

    void Start()
    {
        startSound = Resources.Load<AudioClip> ("start");
        shootSound = Resources.Load<AudioClip> ("shoot");
        destroySound = Resources.Load<AudioClip> ("destroy");
        pickTrashSound = Resources.Load<AudioClip> ("pickTrash");
        jumpSound = Resources.Load<AudioClip> ("jump");
        openTrashbinSound = Resources.Load<AudioClip> ("openTrashbin");
        buttonClickSound = Resources.Load<AudioClip> ("buttonClick");
        gameOverSound = Resources.Load<AudioClip> ("gameOver");
        pauseSound = Resources.Load<AudioClip> ("pause");
        deathSound = Resources.Load<AudioClip> ("death");
        winSound = Resources.Load<AudioClip> ("win");

        isMuted = false;

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound(string clip){
        switch(clip){
            case "start":
                audioSrc.PlayOneShot(startSound);
                break;
            case "shoot":
                audioSrc.PlayOneShot(shootSound);
                break;
            case "destroy":
                audioSrc.PlayOneShot(destroySound);
                break;
            case "pickTrash":
                audioSrc.PlayOneShot(pickTrashSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "openTrashbin":
                audioSrc.PlayOneShot(openTrashbinSound);
                break;
            case "buttonClick":
                audioSrc.PlayOneShot(buttonClickSound);
                break;
            case "pause":
                audioSrc.PlayOneShot(pauseSound);
                break;
            case "gameOver":
                audioSrc.PlayOneShot(gameOverSound);
                break;
            case "death":
                audioSrc.PlayOneShot(deathSound);
                break;
            case "win":
                audioSrc.PlayOneShot(winSound);
                break;
        }
    }

    public void Mute(){
        SoundManager.PlaySound("buttonClick");
        isMuted = !isMuted;
        audioSrc.enabled = !isMuted;
        sfxOn.gameObject.SetActive(false);
    }

    public void unMute(){
        SoundManager.PlaySound("buttonClick");
        isMuted = !isMuted;
        audioSrc.enabled = !isMuted;
        sfxOn.gameObject.SetActive(true);
    }
}
