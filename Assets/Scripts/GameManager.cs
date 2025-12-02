using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float bulletTimer;
    public GameObject bulletBox;
    public float bulletNumber = 0;
    public float GameTime;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameTime += Time.deltaTime;
        if (bulletNumber < 400)
        {
            BulletSpawn();
            bulletNumber += 1;

        }
    }


    public void BulletSpawn()
    {
        float randomX = Random.RandomRange(-18f, 3f);
        float randomY = Random.RandomRange(6f, -7);

        Instantiate(bulletBox,new Vector2(randomX,randomY), Quaternion.identity);
    }
}
