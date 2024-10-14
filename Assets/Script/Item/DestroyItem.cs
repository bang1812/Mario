using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItem : MonoBehaviour
{
    public GameObject hitpoint;
    
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            GameObject clone = Instantiate(hitpoint, transform.position, Quaternion.identity);
            clone.GetComponent<BonusPoint>().scorenumber = 10;
            UIManager.instance.score += 10;
            UIManager.instance.SetScore();
            Destroy(clone, 1);

            int LayerDead = LayerMask.NameToLayer("Dead");
            gameObject.layer = LayerDead;
            Destroy(gameObject);
        }
        if (col.gameObject.CompareTag("DeathZone"))
        {
            int LayerDead = LayerMask.NameToLayer("Dead");
            gameObject.layer = LayerDead;
            Destroy(gameObject);
        }
    }
}
