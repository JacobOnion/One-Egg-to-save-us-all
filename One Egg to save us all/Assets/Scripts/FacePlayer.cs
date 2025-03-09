using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class FacePlayer : MonoBehaviour
{
    private Rigidbody2D player;
    private Rigidbody2D self;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        self = gameObject.GetComponent<Rigidbody2D>();
    }    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = player.position.x - self.position.x;
        if (xPos > 0 && this.gameObject.transform.localScale.x == 1f)
        {
            this.gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (xPos < 0 && this.gameObject.transform.localScale.x == -1f)
        {
            this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
