using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float bounces;
    public Animator animator;
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
        if(transform.position.x<mainCam.transform.position.x - width / 2 + 0.3f)
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Vector2 check = col.GetContact(0).normal;
            if(check == Vector2.down)
            {
                SpawnPoint();
                animator.Play("Hit");
                int LayerIgnoreRaycast = LayerMask.NameToLayer("Dead");
                gameObject.layer = LayerIgnoreRaycast;
                col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
                Destroy(gameObject, 1);
            }
            else
            {
                Player player = col.gameObject.GetComponent<Player>();
                if (player.immortal)
                {
                    SpawnPoint();
                    animator.Play("Hit");
                    int LayerIgnoreRaycast = LayerMask.NameToLayer("Dead");
                    gameObject.layer = LayerIgnoreRaycast;
                    col.gameObject.GetComponentInParent<Rigidbody2D>().AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
                    Destroy(gameObject, 1);
                }
            }
            
        }
        if (col.gameObject.CompareTag("Bullet") || col.gameObject.CompareTag("SnailShield"))
        {
            SpawnPoint();
            animator.Play("Hit");
            rb.AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
            int LayerDead = LayerMask.NameToLayer("Dead");
            gameObject.layer = LayerDead;
            Destroy(gameObject, 1);

        }
        if (col.gameObject.CompareTag("DeathZone"))
        {
            animator.Play("Hit");
            rb.AddForce(Vector2.up * bounces, ForceMode2D.Impulse);
            int LayerDead = LayerMask.NameToLayer("Dead");
            gameObject.layer = LayerDead;
            Destroy(gameObject, 1);
        }
    }
    void SpawnPoint()
    {
        GameObject clone = Instantiate(hitpoint, transform.position, Quaternion.identity);
        clone.GetComponent<BonusPoint>().scorenumber = 1;
        UIManager.instance.score += 1;
        UIManager.instance.SetScore();
        Destroy(clone, 1);
    }



}
