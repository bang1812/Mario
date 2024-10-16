using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shalf : MonoBehaviour
{
    
    public float speed;
    public int startingPoint;
    public Transform[] points;
    private int i;
    private void Start()
    {
        transform.position = points[startingPoint].position;
    }


    void Update()
    {
        if(Vector2.Distance(transform.position, points[i].position) < 0.02)
        {
            i++;
            if(i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.transform.SetParent(null);
        }
    }
}
