using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (LevelManager.instance.levelnumber == LevelManager.instance.levels.Count - 1)
            {
                UIManager.instance.SetLastPanel();
                return;
            }
            StartCoroutine(Delay());
            
            
        }
    }
    IEnumerator Delay()
    {
        
        yield return new WaitForSeconds(5);
        
        LevelManager.instance.SetLevel(LevelManager.instance.levelnumber + 1);
    }
}
