using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public GameObject[] grass;
    void Start()
    {
        for (int i = -10; i < 10; i++)
        {
            for (int j = -10; j < 10; j++)
            {
                int rand = Random.Range(0, 3);
                Instantiate(grass[rand], new Vector2(i, j), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
