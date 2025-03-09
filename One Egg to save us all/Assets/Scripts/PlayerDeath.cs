using Unity.VisualScripting;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public int health;
    private bool invincible;
    [SerializeField] private float iFrames;

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
        if ((other.CompareTag("enemy bullet") || other.CompareTag("melee enemy") || other.CompareTag("laser enemy")) && !invincible)
        {
            health -= 1;
            invincible = true;
            Invoke("ActivateHitbox", iFrames);
        }
    }

    private void ActivateHitbox()
    {
        invincible = false;
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
