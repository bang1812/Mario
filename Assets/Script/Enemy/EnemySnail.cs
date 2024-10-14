using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemySnail : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public float bounces;
    public EnemyMovement enemy;
    public bool checkmove;
    public GameObject hitpoint;
    
    private GameObject mainCam;
    private float width;
    private void Start()
    {
        mainCam = GameObject.Find("Main Camera");
        width = 2f * Camera.main.orthographicSize * Camera.main.aspect;
        
    }
    private void FixedUpdate()
    {
        if (transform.position.x < mainCam.transform.position.x - width / 2 + 0.3f)
            Destroy(gameObject);
    }
    
    private void Update()
    {
        if (enemy.speed != 0)
        {
            checkmove = true;
        }
        else
        {
            checkmove = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 check = col.GetContact(0).normal;

            if (gameObject.tag == "Snail")
            {
                SpawnPoint();

                enemy.speed = 6;
                if (col.gameObject.transform.position.x < transform.position.x)
                    enemy.direction = Vector2.right;
                else
                    enemy.direction = Vector2.left;

            }
            else if (check == Vector2.down)
            {

                SpawnPoint();              
                col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
                animator.Play("shell_idle");
                enemy.speed = 0;
                gameObject.tag = "Snail";
                StartCoroutine(Delay());
            }
            else
            {
                Player player = col.gameObject.GetComponent<Player>();
                if (player.immortal)
                {
                    SpawnPoint();
                    animator.Play("die");
                    int LayerIgnoreRaycast = LayerMask.NameToLayer("Dead");
                    gameObject.layer = LayerIgnoreRaycast;
                    col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
                    Destroy(gameObject, 1);
                }
            }

        }
        if (col.gameObject.CompareTag("DeathZone"))
        {
            Destroy(gameObject);
        }


        if (col.gameObject.CompareTag("Bullet"))
        {
            SpawnPoint();
            animator.Play("die");
            rb.AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
            int LayerDead = LayerMask.NameToLayer("Dead");
            gameObject.layer = LayerDead;

        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("SnailShield"))
        {
            SpawnPoint();
            animator.Play("die");
            rb.AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
            int LayerDead = LayerMask.NameToLayer("Dead");
            gameObject.layer = LayerDead;

        }
    }
    void SpawnPoint()
    {
        GameObject clone = Instantiate(hitpoint, transform.position, Quaternion.identity);
        clone.GetComponent<BonusPoint>().scorenumber = 2;
        UIManager.instance.score += 2;
        UIManager.instance.SetScore();
        Destroy(clone, 1);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player") && gameObject.tag == "Snail" && checkmove  == true)
        {
            gameObject.tag = "SnailShield";
            int LayerDead = LayerMask.NameToLayer("SnailShield");
            gameObject.layer = LayerDead;
            StopAllCoroutines();
        }
    }
    IEnumerator Delay()
    {
        yield return new WaitForSeconds(5);
        animator.Play("move");
        enemy.speed = 2;
        gameObject.tag = "Enemy";
    }
}
