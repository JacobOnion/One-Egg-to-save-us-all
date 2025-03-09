using System;
using UnityEngine;

public class CollectEgg : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<EggManager>().EggCollected();
            Destroy(gameObject);
        }
    }
}
