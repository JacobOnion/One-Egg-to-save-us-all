using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameLoop : MonoBehaviour
{
    private int waveIndex = 0;
    private bool waveComplete = false;
    private GameObject currentWave;
    [SerializeField] private GameObject[] waves;
    private List<GameObject> enemies = new List<GameObject>();
    public GameObject waveCompleteText;
    public GameObject gameCompleteText;
    private AudioSource _audioSource;
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        Invoke("SpawnWave", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (waveComplete)
        {
            _audioSource.Play();
            waveComplete = false;
            Debug.Log("Wave Complete!");
            waveCompleteText.SetActive(true);
            Invoke("SpawnWave", 3f);
        }
        
        else if (currentWave != null && currentWave.GetComponent<EggManager>().eggsecution)  // All enemies purged in the holy light
        {
            if (waveIndex < waves.Length - 1)
            {
                waveIndex += 1;
                Destroy(currentWave);
                waveComplete = true;
            }
            else
            {
                _audioSource.Play();
                Destroy(currentWave);
                gameCompleteText.SetActive(true);
                Invoke("ReturnToMenu", 4f);

            }
        }
        
        
    }

    void SpawnWave()
    {
        waveCompleteText.SetActive(false);
        waveComplete = false;
        currentWave = Instantiate(waves[waveIndex], this.transform);
        /*foreach (Transform tr in currentWave.transform)
        {
            if (tr.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                enemies.Add(tr.gameObject);
            }
        }*/
    }

    void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
