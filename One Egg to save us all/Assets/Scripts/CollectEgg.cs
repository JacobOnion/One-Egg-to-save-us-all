using System;
using UnityEngine;

public class CollectEgg : MonoBehaviour
{
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<EggManager>().EggCollected();
            Destroy(gameObject);
        }
    }
}
