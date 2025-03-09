using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LaserEnemy : TurretEnemy
{
    protected List<LineRenderer> lineRenderers = new List<LineRenderer>();
    public Volume volume;
    private Volume laserEffect;
    public float maxDistance;
    private PlayerDeath playerDeath;

    public LaserEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage, newFireRate, newGuns)
    {
    }

    private void Awake()
    {
        playerDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
        laserEffect = Instantiate(volume); //used to add a glow effect to the lasers
        lineRenderers = new List<LineRenderer>();
        volume.enabled = false;
        coolDown = 1.8f;
    }

    void Start()
    {
        foreach (GameObject gun in guns)
        {
            LineRenderer lineRenderer = gun.transform.Find("Laser").gameObject.GetComponent<LineRenderer>();
            //Debug.Log(lineRenderer, lineRenderer);
            lineRenderers.Add(lineRenderer);
            lineRenderer.enabled = false; //deactivates all the line renderers when the enemy spawns in
        }
    }
    void OnDestroy()
    {
        laserEffect.enabled = false; //If the enemy is dead, the glow effect should turn off as well
    }

    void Update()
    {
        Die();
    }

    private void FixedUpdate() //laser activated in FixedUpdate so the position and length of the laser are constantly updated
    {                          //in case the player or an enemy move in front of it or the laser enemy is pushed.
        CoolDownTimer("EnableLaser");
        if (laserEffect.enabled)
        {
            for (int i = 0; i < guns.Length; i++)
            {
                lineRenderers[i].enabled = true;
                if (Physics2D.Raycast(guns[i].transform.position, guns[i].transform.up)) //if the raycast hits something, draw the laser at that length
                {
                    RaycastHit2D hit = Physics2D.Raycast(guns[i].transform.position, guns[i].transform.up, Mathf.Infinity, ~LayerMask.GetMask("spawns")); //LayerMask used so the raycast doesnt collide with the door or enemy spawner colliders
                    DrawRay(guns[i].transform.position, hit.point, i);
                    if (hit.transform.gameObject.CompareTag("Player"))
                    {
                        playerDeath.DamagePlayer(gameObject);
                    }
                }
                else //In case raycast collides with nothing (should be impossible), draw the laser anyway at a set length
                {
                    DrawRay(guns[i].transform.position, guns[i].transform.up * maxDistance, i);
                }
            }
        }
    }

    protected void DrawRay(Vector2 startPos, Vector2 endPos, int num)
    {
        lineRenderers[num].SetPosition(0, startPos); //always set the start of the laser to the fire point's position
        lineRenderers[num].SetPosition(1, endPos);
    }

    protected void EnableLaser()
    {
        laserEffect.enabled = true;
        Invoke("DisableLaser", 2.2f); //sets the duration of the laser
    }

    protected void DisableLaser()
    {
        foreach (LineRenderer laser in lineRenderers)
        {
            laser.enabled = false;
        }
        laserEffect.enabled = false;
    }
}
