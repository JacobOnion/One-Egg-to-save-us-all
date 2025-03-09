using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

public class GameLoop : MonoBehaviour
{
    private int waveIndex = 0;
    private bool waveComplete = true;
    private GameObject currentWave;
    [SerializeField] private GameObject[] waves;
    private List<GameObject> enemies = new List<GameObject>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (waveComplete)
        {
            waveComplete = false;
            currentWave = Instantiate(waves[waveIndex], this.transform);
            foreach (Transform tr in currentWave.transform)
            {
                if (tr.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    enemies.Add(tr.gameObject);
                }
            }
        }
        
        else if (enemies.Count == 0)  // All enemies purged in the holy light
        {
            if (waveIndex < waves.Length - 1)
            {
                waveIndex += 1;
                Destroy(currentWave);
                waveComplete = true;
            }
            else
            {
                Debug.Log("Winner");
            }
        }
        
        
    }
}
