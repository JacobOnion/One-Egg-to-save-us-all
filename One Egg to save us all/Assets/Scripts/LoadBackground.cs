using UnityEngine;

public class LoadBackground : MonoBehaviour
{
    [SerializeField] private GameObject background;
    void Start()
    {
        Instantiate(background);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
