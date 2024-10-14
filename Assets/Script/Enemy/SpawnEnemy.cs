using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject bluebird;
    public float min, max;
    public float direct;
    
    IEnumerator Delay()
    {
        while (true)
        {
            
            GameObject enemy = Instantiate(bluebird, new Vector3(direct, Random.Range(min, max), 0), Quaternion.identity);
            
            enemy.transform.SetParent(LevelManager.instance.curLevel.transform);
            yield return new WaitForSeconds(5);
        }
    }
    private void Start()
    {
        StartCoroutine(Delay());
    }
}
