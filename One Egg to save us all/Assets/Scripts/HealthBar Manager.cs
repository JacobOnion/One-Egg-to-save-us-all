using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    private PlayerDeath _playerDeath;
    private int currentHealth;
    [SerializeField] private GameObject[] bars;
    void Start()
    {
        _playerDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerDeath>();
        currentHealth = _playerDeath.health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth != _playerDeath.health && currentHealth >= 0)
        {
            Debug.Log("ow!");
            currentHealth = _playerDeath.health;
            Destroy(transform.GetChild(0).gameObject);
            if (currentHealth >= 0)
            {
                Instantiate(bars[currentHealth], this.transform);
            }
        }
    }
}
