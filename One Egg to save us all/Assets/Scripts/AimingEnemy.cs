using UnityEngine;
using System.Collections.Generic;

public class AimingEnemy : MonoBehaviour
{
    public float accuracy;
    public float angle;
    public bool aiming = true;
    public Vector2 lookDirection;
    public Queue<Vector2> lateRot = new Queue<Vector2>(); //Used to add a delay to the enemy aiming
    private Rigidbody2D player;
    private Rigidbody2D self;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        self = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        lookDirection = player.position - self.position; //Prevents null errors when other scripts reference lookDirection on creation
        lateRot.Enqueue(lookDirection);
    }

    private void FixedUpdate() //Done in FixedUpdate because physics-based operations are used
    {
        if (aiming == true)
        {
            Rotator();
        }

    }

    protected void Rotator()
    {
        lookDirection = player.position - self.position; //Gives the direction of the player from the enemy as a vector

        lateRot.Enqueue(lookDirection);
        if (lateRot.Count > accuracy) //Since an item is added to lateRot every frame, accuracy adds a frame delay equal to its value to the aiming
        {
            angle = Vector2.Angle(new Vector2(0f, 1f), lateRot.Peek()); //takes the angle of the first vector in the list without removing it
            if (lateRot.Peek().x > 0)
            {
                angle *= -1;
                angle += 360; //turns the angle into a bearing
            }
            self.rotation = angle;
            lateRot.Dequeue();
        }

    }

}