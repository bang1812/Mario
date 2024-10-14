using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Text scoreText, highScoreText;
    public int score, HighScore;
    public GameObject chooseLevel;
    public GameObject StartPanel;
    public GameObject PausePanel;
    public GameObject GameOverPanel;
    public GameObject LastPanel;
    public GameObject HelpPanel;
    
    public Button Sound;
    public GameObject PauseButton;
    
    public static UIManager instance;
    public AudioManager audioManager;
    
    private void Awake()
    {
        instance = this;
    }
    

    private void Start()
    {
        audioManager = AudioManager.instance;
        
        
        scoreText.text = "SCORE \n" + score;
        audioManager.audioEffect.mute = false;
        if(PlayerPrefs.HasKey("HighScore"))
            HighScore = PlayerPrefs.GetInt("HighScore");
        else
            HighScore = 0;
        
    }

    
    private void FixedUpdate()
    {
        

        HighScore = PlayerPrefs.GetInt("HighScore");
        highScoreText.text = "High Score: " + HighScore.ToString();
        if (score * 10 > PlayerPrefs.GetInt("HighScore")){
            PlayerPrefs.SetInt("HighScore", score * 10);
        }

        if (LevelManager.instance.curPlayer != null)
        {
            Player player = LevelManager.instance.curPlayer.GetComponent<Player>();
            if (player.die == false)
                return;
            else
                StartCoroutine(Delay());

        }
    }
    
    
    
    
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);

        GameOverPanel.SetActive(true);
    }

    public void SetScore()
    {
        scoreText.text = "SCORE \n" + score * 10;
    }
    
    
    public void Return()
    {
        chooseLevel.SetActive(false);
        StartPanel.SetActive(true);
        
    }
    public void Pause()
    {
        Time.timeScale = 0;
        PausePanel.SetActive(true);
        PauseButton.SetActive(false);
        

    }
    public void Continues()
    {
        Time.timeScale = 1;
        PausePanel.SetActive(false);
        PauseButton.SetActive(true);
        
    }
    
    public void Replay()
    {
        GameOverPanel.SetActive(false);
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        Destroy(LevelManager.instance.curPlayer);
        LevelManager.instance.curPlayer = null;
        score = 0;
        SetScore();
        LevelManager.instance.SetLevel(LevelManager.instance.levelnumber);
    }
    public void ExitToStartPanel()
    {
        score = 0;
        SetScore();
        Time.timeScale = 1;
        Destroy(LevelManager.instance.curLevel.gameObject);
        Destroy(LevelManager.instance.curPlayer);
        LevelManager.instance.mainCam.GetComponent<FollowCamera>().player = LevelManager.instance.mainCam.transform;
        PausePanel.SetActive(false);
        StartPanel.SetActive(true);
        GameOverPanel.SetActive(false);
        PauseButton.SetActive(false);
        LastPanel.SetActive(false);
        
        audioManager.PlayMusic(audioManager.StartMusic);
    }
    public void SetLastPanel()
    {
        LastPanel.SetActive(true);
        
    }
    public void PlayGame()
    {
        chooseLevel.SetActive(true);
        StartPanel.SetActive(false);
    }
    
    public void SetHelpPanel(bool show)
    {
        HelpPanel.SetActive(show);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    //public void JumpButton()
    //{
    //    LevelManager.instance.curPlayer.GetComponent<Player>().Jump();
        
    //}
    //public void FireButton()
    //{
    //    LevelManager.instance.curPlayer.GetComponent<Player>().Shootting();

    //}
    //public void LeftButton()
    //{

    //    InputPlayer.instance.horizontal = -1;

    //}
    //public void RightButton()
    //{

    //    InputPlayer.instance.horizontal = 1;

    //}
    //public void UpButton()
    //{
    //    InputPlayer.instance.horizontal = 0;
    //}

}

