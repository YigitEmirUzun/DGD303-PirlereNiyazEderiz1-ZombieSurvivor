using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public GameObject player;
    bool right;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > transform.position.x)
        {
            transform.Translate(new Vector2(0.2f * Time.deltaTime, 0));
            right = true;
        }
        else if(player.transform.position.x < transform.position.x)
        {
            transform.Translate(new Vector2(-0.2f * Time.deltaTime, 0));
            right = false;
        }

        if(player.transform.position.y > transform.position.y)
        {
            transform.Translate(new Vector2(0, 0.2f * Time.deltaTime));
        }
        else if(player.transform.position.y < transform.position.y)
        {
            transform.Translate(new Vector2(0, -0.2f * Time.deltaTime));
        }

        if(right)
        {
            transform.localScale = new Vector2(1,1);
        }
        else
        {
            transform.localScale = new Vector2 (-1,1);
        }
    }
}
