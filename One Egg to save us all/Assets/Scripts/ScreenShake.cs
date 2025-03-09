using System;
using UnityEngine;
using Random = UnityEngine.Random;
using Vector2 = System.Numerics.Vector2;

public class ScreenShake : MonoBehaviour
{
    public GameObject Camera; // set this via inspector
    public float shake;
    public float shakeAmount;
    public float decreaseFactor;
    private Vector3 originalPos;

    private void Start()
    {
        originalPos = Camera.transform.position;
    }

    private void Update() {
        if (shake > 0) {
            Camera.transform.position = Camera.transform.position + Random.insideUnitSphere * shakeAmount;
            shake -= Time.deltaTime * decreaseFactor;

        } else {
            shake = 0.0f;
            Camera.transform.position = originalPos;
        }
    }
}
