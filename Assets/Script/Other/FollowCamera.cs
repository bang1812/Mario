using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;
    public float width;
    public bool CanFollow = true;

    private void Start()
    {
        width = 2f * Camera.main.orthographicSize * Camera.main.aspect;
        GameManager.instance.Dead += DontFollow;
    }
    void Update()
    {
        if (!CanFollow)
            return;
        if (player != null)
        {
            if (player.position.x > transform.position.x)
            {
                Vector3 newPosition = player.position;
                newPosition.z = -10;
                newPosition.y = transform.position.y;
                transform.position = newPosition;
            }
            if (player.position.x <= transform.position.x - width / 2 + 0.3f)
            {
                Vector3 newPosition = player.position;
                newPosition.x = transform.position.x - width / 2 + 0.3f;
                player.position = newPosition;
            }
        }

        
        
    }
    void DontFollow()
    {
        CanFollow = false;
    }
}
