using UnityEngine;

public class HoveringText : MonoBehaviour
{
    [SerializeField]
    public float distance, speed;
    private float progress;
    void FixedUpdate()
    {
        if (progress >= distance)
        {
            progress = 0;
            speed *= -1;
        }

        transform.Translate(new Vector2(0, speed));
        progress += 1;
    }
}
