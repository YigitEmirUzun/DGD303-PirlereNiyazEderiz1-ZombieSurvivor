using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject camera;
    float timer = 0;
    public GameObject enemy1;
    public float spawnTime = 3; 
    public int spawnnumber = 3;
    public float hardTimer = 0;
    void Start()
    {
        
    }

    void Update()
    {
        hardTimer += Time.deltaTime;
        if(hardTimer > 35)
        {
            hardTimer = 0;
            spawnTime -= 0.2f;
            spawnnumber += 1; 
        }

        SpawnEnemy(spawnTime,spawnnumber);
    }

    public void SpawnEnemy(float spawnTime, int spawnnumber)
    {
        timer += Time.deltaTime;

        if(timer >= spawnTime)
        {
            timer = 0;
            int spawnplace = Random.Range(0, 4);
            for (int i = 0; i < spawnnumber; i++)
            {
                

                if(spawnplace == 0)
                {
                    float randomX = Random.RandomRange(camera.transform.position.x - 5, camera.transform.position.x - 4);
                    float randomY = Random.RandomRange(camera.transform.position.y - 1, camera.transform.position.y + 1);
                    Instantiate(enemy1, new Vector2(randomX, randomY), Quaternion.identity);
                }
                else if(spawnplace == 1)
                {
                    float randomX = Random.RandomRange(camera.transform.position.x + 4, camera.transform.position.x + 5);
                    float randomY = Random.RandomRange(camera.transform.position.y - 1, camera.transform.position.y + 1);
                    Instantiate(enemy1, new Vector2(randomX, randomY), Quaternion.identity);
                }
                else if (spawnplace == 2)
                {
                    float randomX = Random.RandomRange(camera.transform.position.x - 4, camera.transform.position.x + 5);
                    float randomY = Random.RandomRange(camera.transform.position.y - 2, camera.transform.position.y - 3);
                    Instantiate(enemy1, new Vector2(randomX, randomY), Quaternion.identity);
                }
                else if (spawnplace == 3)
                {
                    float randomX = Random.RandomRange(camera.transform.position.x - 4, camera.transform.position.x + 5);
                    float randomY = Random.RandomRange(camera.transform.position.y + 2, camera.transform.position.y + 3);
                    Instantiate(enemy1, new Vector2(randomX, randomY), Quaternion.identity);
                }

            }
        }
    }
}
