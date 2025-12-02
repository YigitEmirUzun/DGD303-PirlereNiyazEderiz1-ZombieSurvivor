using JetBrains.Annotations;
using UnityEngine;

public class BulletBoxInRange : MonoBehaviour
{
    public GameObject player;
    public delegate void BoxCollectAction();
    public static BoxCollectAction onBoxCollected;
    void Start()
    {
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CollectHitbox"))
        {
            MoveToPlayer();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerHitbox"))
        {
            onBoxCollected?.Invoke();
            Destroy(gameObject);
        }
    }

    public void MoveToPlayer()
    {
        if (player.transform.position.x > transform.position.x)
        {
            transform.Translate(new Vector2(3 * Time.deltaTime, 0));
        }
        else if(player.transform.position.x < transform.position.x)
        {
            transform.Translate(new Vector2(-3 * Time.deltaTime, 0));
        }

        if (player.transform.position.y > transform.position.y)
        {
            transform.Translate(new Vector2(0, 3 * Time.deltaTime));
        }
        else if (player.transform.position.y < transform.position.y)
        {
            transform.Translate(new Vector2(0, -3 * Time.deltaTime));
        }
    }
}
