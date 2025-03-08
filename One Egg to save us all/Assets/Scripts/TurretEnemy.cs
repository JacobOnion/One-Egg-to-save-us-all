using UnityEngine;

public class TurretEnemy : Enemy
{
    public GameObject[] guns;
    public float fireRate;
    protected float coolDown;
    public TurretEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage)
    {
        fireRate = newFireRate;
        guns = newGuns;

    }

    private void Start()
    {
        coolDown = fireRate;
    }


    protected void CoolDownTimer(string shoot) //adds a delay in between shots equal to fireRate
    {
        coolDown -= Time.deltaTime;
        if (coolDown <= 0f)
        {
            coolDown = fireRate;
            Invoke(shoot, 0f); //calls the procedure with the identifier of the string passed in as a parameter
        }
    }

}
