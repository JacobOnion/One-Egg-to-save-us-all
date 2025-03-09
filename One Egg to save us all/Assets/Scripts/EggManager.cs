using System;
using NUnit.Framework.Internal;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class EggManager : MonoBehaviour
{
    [SerializeField] private float upperX;
    [SerializeField] private float lowerX;
    [SerializeField] private float upperY;
    [SerializeField] private float lowerY;
    [SerializeField] private int eggCount;
    [SerializeField] private float eggMercy;
    private int eggsCollected = -1;
    public bool eggsecution = false;
    public GameObject egg;
    private Vector3 newPos;
    private TMP_Text eggUI;

    private void Start()
    {
        eggUI = GameObject.FindGameObjectWithTag("egg UI").GetComponent<TMP_Text>();
        EggCollected();
    }

    public void EggCollected()
    {
        eggsCollected += 1;
        eggUI.text = (eggCount - eggsCollected).ToString();
        if (eggsCollected == eggCount)
        {
            Debug.Log("EGGSECUTION IS COMING");
            eggsecution = true;
        }
        else
        {
            Vector3 lastPos = newPos;
            newPos = new Vector3(Random.Range(lowerX, upperX), Random.Range(lowerY, upperY), 0);
            while ((newPos - lastPos).magnitude < eggMercy)
            {
                newPos = new Vector3(Random.Range(lowerX, upperX), Random.Range(lowerY, upperY), 0);
                Debug.Log("Regening");
            }
            Instantiate(egg, newPos, Quaternion.identity, this.transform);
        }
    }
}
