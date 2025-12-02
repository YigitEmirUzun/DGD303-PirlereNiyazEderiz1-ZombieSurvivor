using System.Collections;
using UnityEngine;

public class ZombieHealth : MonoBehaviour, IDamageable
{
    public float health = 10;
    public SpriteRenderer spriteRenderer;
    private Color originalColor;
    public GameObject BulletBox;
    public GameObject player;
    public Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    public void TakeDamage(float damage)
    {
        if (player.transform.position.x >= transform.position.x)
        {
            transform.Translate(new Vector2(-0.1f, 0));
        }
        else
        {
            transform.Translate(new Vector2(0.1f, 0));
        }
        health -= damage;
        StartCoroutine(hurtRoutine());
        
        if (health <= 0)
        {
            for (int i = 0; i < 5; i++)
            {
                float randomX = Random.Range(transform.position.x - 0.2f, transform.position.x + 0.2f);
                float randomY = Random.Range(transform.position.y, transform.position.y + 0.3f);
                Instantiate(BulletBox, new Vector2(randomX, randomY), Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator hurtRoutine()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = originalColor;
    }
}
