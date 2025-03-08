using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float enemyDamage;

    public Enemy(float newHealth, float newEnemyDamage)
    {
        health = newHealth;
        enemyDamage = newEnemyDamage;
    }

    protected void Die()
    {
        if (health <= 0f)
        {
            Destroy(gameObject); //kills the enemy
        }
    }

    public void damage(float weaponDmg)
    {
        health -= weaponDmg; //damages the enemy by the value of weaponDmg
    }
}
