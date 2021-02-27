
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public GameObject Ifdie;

    public static int Now = 0;
    private int High = 0;
    public Text Now_text;
    public Text High_text;
    public GameObject muteButton;
    public bool ismute; //소리 불러올때 판단용
    public GameObject nomuteButton;
    private int issound;

    public AudioSource clicked;
    public GameObject clapping;
    public GameObject end_sound;

    private bool ishigh = false;
    private bool isend = false;

    void Start()
    {
        Load();
        loadsound();
        if (issound == 0) //소리가 난다.
            nomute();
        else if (issound == 1) //소리가 안난다.
            mute();
    }
    void Update()
    {
        loadsound();
        if (Application.platform == RuntimePlatform.Android) //뒤로가기 누르면 게임 종료
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        if (Player.Stop)
        {
            Ifdie.SetActive(true);
            ScoreSum();
        }
        if (ismute == true) //소리가 날때
        {
            issound = 0;
            savesound();
        }
        else //나지 않을때
        {
            issound = 1;
            savesound();
        }
        if (ishigh)
        {
            clapping.SetActive(true);
            ishigh = false;
        }
        if (isend)
        {
            end_sound.SetActive(true);
            isend = false;
        }
    }
    public void Retry()
    {
        Player.Stop = false;
        SceneManager.LoadScene(1);
    }
    public void ScoreSum()
    {
        Now_text.text = Now.ToString();
        Save();
        isend = true;
        if(High < Now)
        {
            High = Now;
            High_text.text = High.ToString();
            ishigh = true;
        }
        else
        {
            High_text.text = High.ToString();
        }
        Player.score = 0;
    }
    public void mute() //소리를 끌때
    {
        muteButton.SetActive(false);
        nomuteButton.SetActive(true);
        AudioListener.pause = true;
        ismute = false;
    }
    public void nomute() //소리를 켤때
    {
        muteButton.SetActive(true);
        nomuteButton.SetActive(false);
        AudioListener.pause = false;
        ismute = true;
        clicked.Play();
    }
    public void Save() //저장
    {
        PlayerPrefs.SetInt("save", High);
    }
    public void Load() //로드
    {
        High = PlayerPrefs.GetInt("save");
    }
    public void savesound() //소리 저장
    {
        PlayerPrefs.SetInt("Savesound", issound);
    }
    public void loadsound()
    {
        issound = PlayerPrefs.GetInt("Savesound");
    }
}
