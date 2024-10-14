using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoxType
{
    Star,
    Empty
}
public class BoxRaw : MonoBehaviour, IBoxRespond
{

    public Animator animator;
    public GameObject star;
    public int countstar;
    public BoxType type = BoxType.Empty;
    public void Respond()
    {
        switch (type)
        {
            case BoxType.Empty:
                animator.Play("Hit", 0, 0);
                break;
            case BoxType.Star:
                if (countstar == 0)
                    return;
                animator.Play("Hit", 0, 0);
                Vector3 position = transform.position;
                position.y++;

                Instantiate(star, position, Quaternion.identity);
                if (--countstar <= 0)
                {
                    animator.Play("Empty", 0, 0);
                    return;
                }
                break;
        }
        
    }
    
}
