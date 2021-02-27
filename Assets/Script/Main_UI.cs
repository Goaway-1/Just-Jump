using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_UI : MonoBehaviour
{
    public AudioSource click;

    public void startButton()
    {
        SceneManager.LoadScene(1);
        click.Play();
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android) //뒤로가기 누르면 게임 종료
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
}
