using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bee : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;
    
    public GameObject bullet;
    private int i;
    private void Start()
    {
        transform.position = points[startingPoint].position;
        StartCoroutine(Delay());
        
    }


    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        
    }
    IEnumerator Delay()
    {
        while (true)
        {

            GameObject clone = Instantiate(bullet, transform.position, Quaternion.identity);
            Destroy(clone, 3);
            yield return new WaitForSeconds(0.5f);
        }
    }


}
