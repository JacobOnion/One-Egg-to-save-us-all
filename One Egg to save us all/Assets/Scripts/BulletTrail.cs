using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletTrail : MonoBehaviour
{
    private Vector2 startPos;
    public Vector2 endPos; //passed into this script on object instantiation
    public float speed;
    private float progress = 0;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        progress += speed;
        transform.position = Vector2.Lerp(startPos, endPos, progress);

        if (new Vector2(transform.position.x, transform.position.y) == endPos)
        {
            Destroy(gameObject); //Destroy gameobject when it has reached the goal
        }
    }
}