using UnityEditor.SceneManagement;
using UnityEngine;

public class TurretEnemy : Enemy
{
    public GameObject[] guns;
    public float fireRate;
    protected float coolDown;

    private SpriteRenderer _spriteRenderer;
    public bool animated;
    public Sprite idle;
    public Sprite shooting;
    public float shootAnimTime;
    public TurretEnemy(float newHealth, float newEnemyDamage, float newFireRate, GameObject[] newGuns) : base(newHealth, newEnemyDamage)
    {
        fireRate = newFireRate;
        guns = newGuns;

    }

    private void Awake()
    {
        coolDown = fireRate;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    protected void CoolDownTimer(string shoot) //adds a delay in between shots equal to fireRate
    {
        coolDown -= Time.deltaTime;
        if (animated)
        {
            if (coolDown <= shootAnimTime)
            {
                _spriteRenderer.sprite = shooting;
            }
            else if (coolDown <= fireRate - 0.5)
            {
                _spriteRenderer.sprite = idle;
            }
        }
        if (coolDown <= 0f)
        {
            coolDown = fireRate;
            Invoke(shoot, 0f); //calls the procedure with the identifier of the string passed in as a parameter
        }
    }

}
