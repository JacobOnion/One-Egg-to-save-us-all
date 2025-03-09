using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class EggManager : MonoBehaviour
{
    [SerializeField] private int eggCount;
    [SerializeField] private Vector2 upper; // top right of level
    [SerializeField] private Vector2 lower; // bottom left of level
    [SerializeField] private float eggMercy;
    private int eggsCollected = -1;
    public bool eggsecution;
    public GameObject egg;
    private Vector3 newPos;

    private void Start()
    {
        EggCollected();
    }

    public void EggCollected()
    {
        eggsCollected += 1;
        if (eggsCollected == eggCount)
        {
            eggsecution = true;
        }
        else
        {
            Vector3 lastPos = newPos;
            newPos = new Vector3(Random.Range(lower.X, upper.X), Random.Range(lower.Y, upper.Y), 0);
            while ((newPos - lastPos).magnitude < eggMercy)
            {
                newPos = new Vector3(Random.Range(lower.X, upper.X), Random.Range(lower.Y, upper.Y), 0);
                Debug.Log("Regening");
            }
            Instantiate(egg, newPos, Quaternion.identity, this.transform);
        }
    }
}
