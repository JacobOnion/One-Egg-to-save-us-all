using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public float health;

    public Canvas deathScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0) //player dies
        {
            Death();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        DamagePlayer(other.gameObject);
    }
    
    public void DamagePlayer(GameObject other)
    {
        if (other.CompareTag("enemy bullet"))
        {
            health -= other.GetComponent<EnemyDestroyBullet>().damage; //Gets the damage value from the enemy class and subtracts that from health
        }
        else if (other.CompareTag("melee enemy") || other.CompareTag("laser enemy"))
        {
            health -= other.GetComponent<Enemy>().enemyDamage;
        }
    }
    
    private void Death()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("laser enemy");
        foreach (var enemy in enemies)
        {
            Destroy(enemy);
        }
        deathScreen.enabled = true;
    }
    
}
