using System.Collections;
using UnityEngine;

public class Skills : MonoBehaviour
{
    public GameObject RightSlash;
    public GameObject LeftSlash;
    public float AttackDelay;
    public float slashTimer = 0;

    private void Awake()
    {
        AttackDelay = 2f;
        
    }
    void Start()
    {
        StartCoroutine(AttackRoutine());
    }


    // Update is called once per frame
    void Update()
    {
        slashTimer += Time.deltaTime;
        LeftSlash.transform.position = new Vector2(transform.position.x - 0.1f, transform.position.y + 0.124f);
        RightSlash.transform.position = new Vector2(transform.position.x + 0.1f, transform.position.y + 0.124f);

        if (slashTimer >= AttackDelay)
        {
            slashTimer = 0f;
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator RightAttack()
    {
        RightSlash?.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        RightSlash?.SetActive(false);
    }

    IEnumerator LeftAttack()
    {
        LeftSlash?.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        LeftSlash?.SetActive(false);
    }

    IEnumerator AttackRoutine()
    {
        StartCoroutine(RightAttack());
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(LeftAttack());
    }

}
