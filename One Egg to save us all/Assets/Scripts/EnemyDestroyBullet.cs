using UnityEngine;

public class EnemyDestroyBullet : MonoBehaviour
{
    public float damage; //Used as an intermediary variable between the enemy and player
    void Start()
    {
        Invoke("BulletTimer", 10f); //Destroys bullet after a set time with no collision
    }

    private void OnCollisionEnter2D(Collision2D other)
    {   
        Destroy(gameObject); //Destroys bullet on collision
    }

    void BulletTimer()
    {
        Destroy(gameObject);
    }
}
