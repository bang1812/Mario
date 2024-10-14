using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Player : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public float speedmove;
    public float jumpForce;
    public GroundCheck check;
    public Animator animator;
    public bool die = true;
    public float bounce;
    private bool sizeup;
    public BoxCollider2D boxPlayer;
    public GameObject bullet;
    public SpriteRenderer spriteplayer;
    private bool checkSkill;
    public bool immortal;
    private AudioManager audioManager;

    private void Start()
    {
        audioManager = AudioManager.instance;
        
        speedmove = 8;
        int LayerDead = LayerMask.NameToLayer("Player");
        gameObject.layer = LayerDead;
    }
    private void FixedUpdate()
    {
        
        if (!die)
        {
            Move();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Shootting(); 
        }
        bool jump = Input.GetKeyDown(KeyCode.Space);
        if (jump)
        {
            Jump();
        }
        if (immortal == true)
            StartCoroutine(TimeLimit());
    }

    public void Move()
    {
        Vector2 move = new Vector2(InputPlayer.instance.horizontal * speedmove, rb.velocity.y);
        rb.velocity = move;
    }
    public void Jump()
    {
        
        if(check.groundCheck)
        {
            
            rb.AddForce(Vector2.up * jumpForce);
            check.groundCheck = false;
            audioManager.PlaySound(audioManager.jumpsound);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("finish"))
        {
            speedmove = 0;
        }
        
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Shalf"))
        {
            transform.SetParent(col.transform);
        }
        if (!immortal)
        {
            if ((col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag("SnailShield")) && col.GetContact(0).normal != Vector2.up)
            {

                if (sizeup == true)
                {
                    SizeDown();
                    StartCoroutine(Delay());
                }
                else
                    SetDie();


            }
            
        }
        
        
        if(col.gameObject.CompareTag("SizeUp") && sizeup == false)
        {
            
            SizeUp();
            StartCoroutine(Delay());  
        }
        if (col.gameObject.CompareTag("Skill") && checkSkill == false)
        {
            checkSkill = true;
            
        }
        if (col.gameObject.CompareTag("DeathZone"))
        {
            SetDie();
        }
        if (col.gameObject.CompareTag("Star"))
        {
            immortal = true;
            
        }
        
    }
    private void SetDie()
    {
        die = true;
        rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        int LayerDead = LayerMask.NameToLayer("Dead");
        gameObject.layer = LayerDead;
        audioManager.PlaySound(audioManager.diesound);
        GameManager.instance.Dead?.Invoke();
        Destroy(gameObject, 1.5f);

    }
    private void SizeUp()
    {
        
        sizeup = true;
        rb.transform.localScale *= 1.5f;
        Vector3 curpos = transform.position;
        curpos.y += boxPlayer.size.y / 1.5f;
        transform.position = curpos;
        audioManager.PlaySound(audioManager.sizeupSound);
        
    }
    IEnumerator Delay()
    {
        rb.simulated = false;
        yield return new WaitForSeconds(1);
        rb.simulated = true;
    }
    IEnumerator TimeLimit()
    {
        
        yield return new WaitForSeconds(5);
        immortal = false;
    }
    private void SizeDown()
    {
        sizeup = false;
        rb.transform.localScale /= 1.5f;
        Vector3 curpos = transform.position;
        curpos.y += boxPlayer.size.y / 1.5f;
        transform.position = curpos;
        
    }
    private GameObject SpawnBullet(Vector2 direction)
    {
        GameObject move = Instantiate(bullet, transform.position, Quaternion.identity);

        move.GetComponent<Bullet>().direct = direction;
        move.GetComponent<Bullet>().Move();
        return move;
        
    }
    public void Shootting()
    {
        
        if(checkSkill == true)
        {
            Vector2 direct = new Vector2(0.5f, -0.5f);
            if (spriteplayer.flipX)
            {
                direct = new Vector2(-0.5f, -0.5f);
            }
            SpawnBullet(direct);

            audioManager.PlaySound(audioManager.fireball);
            
        }

        

    }
    
}
