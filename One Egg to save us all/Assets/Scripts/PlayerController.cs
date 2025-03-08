using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 input;
    public float maxSpeed;
    public float accelRate;
    public float deccelRate;
    private Rigidbody2D rb;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized; //takes in the direction the player wants to move in
    }

    void FixedUpdate()
    {
        Run(); //All physics-based operations should be done in FixedUpdate
    }

    private void Run()
    {
        Vector2 targetSpeed = input * maxSpeed; //calculates the speed the player wants to reach

        float acceleration;
        if (Mathf.Abs(targetSpeed.x) > 0.1f || Mathf.Abs(targetSpeed.y) > 0.1f) //the player will stop slower if they don't try to move
        {
            acceleration = accelRate;
        }
        else
        {
            acceleration = deccelRate;
        }

        Vector2 speedDif = targetSpeed - rb.linearVelocity; //finds how far the player is from their target speed
        Vector2 movement = speedDif * acceleration;
        rb.AddForce(movement, ForceMode2D.Force); //Adds a force to the player that decreases as the player gets closer to their target speed
    }
}
