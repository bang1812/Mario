using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Level> levels;
    public Level curLevel;
    
    public GameObject prefabPlayer;
    public Camera mainCam;
    public int levelnumber;
    public GameObject curPlayer;
    public static LevelManager instance;
    
    private void Awake()
    {
        instance = this;
    }
    public void SetLevel(int index)
    {
        AudioManager.instance.PlayMusic(AudioManager.instance.PlayGameMusic);
        UIManager.instance.PauseButton.SetActive(true);
        UIManager.instance.chooseLevel.SetActive(false);
        if (curLevel != null)
        {
            Destroy(curLevel.gameObject);
        }
        
        levelnumber = index;
        curLevel = Instantiate(levels[index]);

        if (curPlayer != null)
        {

            
            Player player = curPlayer.GetComponent<Player>();
            player.speedmove = 8;
        }
        else
        {
            curPlayer = Instantiate(prefabPlayer);
        }
        
        
        FollowCamera camFollow = mainCam.GetComponent<FollowCamera>();
        camFollow.CanFollow = true;
        camFollow.transform.position = levels[index].posCamera;
        
        curPlayer.transform.position = levels[index].posPlayer;
        camFollow.player = curPlayer.transform;


    }

}
