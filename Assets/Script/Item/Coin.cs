using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject hitpoint;
    
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            GameObject clone = Instantiate(hitpoint, transform.position, Quaternion.identity);
            clone.GetComponent<BonusPoint>().scorenumber = 5;
            UIManager.instance.score += 5;
            UIManager.instance.SetScore();
            Destroy(clone, 1);
            Destroy(gameObject);
        }
    }
}
