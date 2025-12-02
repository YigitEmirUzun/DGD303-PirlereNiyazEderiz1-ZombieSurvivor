using System;
using UnityEngine;
using UnityEngine.UI;



public class PlayerScore : MonoBehaviour
{
    public float maxPoint;
    public float currentPoint;
    public Image pointbar;
    public static Action onLevelUp;

    void Awake()
    {
        maxPoint = 20;
        currentPoint = 0;

        onLevelUp += LevelUp;
        
    }

    // Update is called once per frame
    void Update()
    {
        pointbar.fillAmount = currentPoint / maxPoint;

        if(pointbar.fillAmount >= 1)
        {
            onLevelUp?.Invoke();
        }
    }

    public void addPoint()
    {
        currentPoint += 1;
    }

    public void LevelUp()
    {
        maxPoint += 10;
        currentPoint = 0;
    }

    private void OnBecameVisible()
    {
        BulletBoxInRange.onBoxCollected += addPoint;
    }
    private void OnBecameInvisible()
    {
        BulletBoxInRange.onBoxCollected -= addPoint;
    }
}
