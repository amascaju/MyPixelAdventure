using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    private GameObject sndManager;
    //LEVEL STATES
    public bool isGameOver = false;
    public bool isLevelRestarted = false;
    public bool isLevelCompleted = false;
    public bool isGameCompleted = false;


    [SerializeField] private GameObject pFinish;
    [SerializeField] private TextMeshProUGUI textWin;

    void Start()  {
        //SOUNDMANAGER
        InitSoundManager();
    }

    void InitSoundManager() {
        sndManager = GameObject.FindGameObjectWithTag("SoundManager");
        sndManager.GetComponent<SoundManager>().SetMusicVolume(PlayerPrefs.GetFloat("musicVolume"));
        sndManager.GetComponent<SoundManager>().fxVolume = PlayerPrefs.GetFloat("fxVolume");
        sndManager.GetComponent<SoundManager>().SetEnableMusic(PlayerPrefs.GetInt("music")==1?true:false);
        sndManager.GetComponent<SoundManager>().isFXEnabled = PlayerPrefs.GetInt("fx")==1?true:false;
        sndManager.GetComponent<SoundManager>().PlayMusic(0);
    }

    void Reset() {
        isGameOver = false;
        isLevelRestarted = false;
        isLevelCompleted = false;
        isGameCompleted = false;
    }

    void OnGUI() {
        if (isGameCompleted || isGameOver) {
            textWin.text = isGameCompleted ? "CONGRATULATIONS!!" : "GAMEOVER!!";
            pFinish.SetActive(true);
            Reset();
        }
    }

    public void GameOver() {
        isGameOver = true; 
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void CompleteLevel() {
        if (SceneManager.GetActiveScene().name == "Level1"){
            isGameCompleted = true;
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}