using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public Animator ani;
    public GameObject hitpoint;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            ani.Play("flag");
            GameObject clone = Instantiate(hitpoint, transform.position, Quaternion.identity);
            clone.GetComponent<BonusPoint>().scorenumber = 20;
            UIManager.instance.score += 20;
            UIManager.instance.SetScore();
            Destroy(clone, 1);
        }
    }

}
