using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button exitBtn;
    // Start is called before the first frame update
    void Start()
    {
        playBtn.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Level1");
        });
        exitBtn.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }
}
