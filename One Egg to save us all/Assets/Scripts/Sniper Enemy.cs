using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : TurretEnemy
{
    private LineRenderer laser;
    private GameObject gun;
    public GameObject bulletTrail;
    private AimingEnemy rotate;
    private Transform pos;
    private bool scope;
    private PlayerDeath playerDeath;
    public SniperEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {

    }

    void Start()
    {
        playerDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
        coolDown = 1.5f;
        gun = guns[0]; // only one gun in the list for this enemy
        laser = gun.transform.Find("Laser").gameObject.GetComponent<LineRenderer>();
        rotate = GetComponent<AimingEnemy>();
        pos = gun.GetComponent<Transform>();
        scope = true; //Used to check if the enemy is currently aiming
    }

    private void Update()
    {
        Die();
    }

    void FixedUpdate()
    {
        CoolDownTimer("FreezeLaser"); //controls how long the aiming phase lasts

        if (scope)
        {
            SetLaserPos();
        } 
    }
    void SetLaserPos() //draws the aiming laser
    {
        laser.SetPosition(0, gun.transform.position);
        if (Physics2D.Raycast(gun.transform.position, gun.transform.up))
        {
            RaycastHit2D hit = Physics2D.Raycast(gun.transform.position, gun.transform.up, Mathf.Infinity, LayerMask.GetMask("Geometry", "Player"));
            laser.SetPosition(1, hit.point);
        }
    }

    void FreezeLaser()
    {
        Invoke("ShootGun", 0.35f);
        laser.SetPosition(1, pos.position); //end point of laser is now equal to start point, effectively deleting it
        rotate.aiming = false;
        scope = false;
    }

    void ShootGun()
    {
        RaycastHit2D shot = Physics2D.Raycast(gun.transform.position, gun.transform.up, Mathf.Infinity, LayerMask.GetMask("Geometry", "Player"));

        if (shot.transform.gameObject.CompareTag("Player"))
        {
            playerDeath.DamagePlayer(gameObject);
        }

        GameObject trail = Instantiate(bulletTrail, pos.position, pos.rotation);
        trail.GetComponent<BulletTrail>().endPos = shot.point; //passes end goal of trail into it.
        rotate.aiming = true;
        Invoke("CoolDown", 1f);
    }

    void CoolDown()
    {
        scope = true;
    }
}
