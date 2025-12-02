using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class SkillManager : MonoBehaviour
{
    [Header("UI")]
    public GameObject UIBackGround;
    public Button button1;
    public Button button2;
    public Button button3;

    [Header("Player")]
    public GameObject player;
    public PlayerMovement playerMovement;
    public GameObject CollectCollider;

    private TextMeshProUGUI text1;
    private TextMeshProUGUI text2;
    private TextMeshProUGUI text3;

    [Header("Skills")]
    public List<string> skills = new List<string>();

    public Skills playerSkills;

    private void Awake()
    {
        // Baþlangýçta skill UI kapalý
        UIBackGround.SetActive(false);

        playerMovement = player.GetComponent<PlayerMovement>();
        playerSkills = player.GetComponent<Skills>();
    }

    private void Start()
    {
        // LevelUp eventine randomSkills fonksiyonunu baðla
        PlayerScore.onLevelUp += randomSkills;

        // Skill listesini hazýrla
        skills.Add("Speed +");
        skills.Add("Collect Range +");
        skills.Add("Attack Speed +");

        // Buton altýndaki TextMeshPro componentlerini al
        text1 = button1.GetComponentInChildren<TextMeshProUGUI>();
        text2 = button2.GetComponentInChildren<TextMeshProUGUI>();
        text3 = button3.GetComponentInChildren<TextMeshProUGUI>();

        // Baþlangýçta listenerlarý temizle
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();
    }

    // Rastgele skill seç ve butonlara ata
    public void randomSkills()
    {
        // Buton listenerlarýný temizle
        button1.onClick.RemoveAllListeners();
        button2.onClick.RemoveAllListeners();
        button3.onClick.RemoveAllListeners();

        // 1. Button
        int index1 = Random.Range(0, skills.Count);
        string skill1 = skills[index1];
        text1.text = skill1;
        button1.onClick.AddListener(() => UseSkill(skill1));

        // 2. Button
        int index2 = Random.Range(0, skills.Count);
        string skill2 = skills[index2];
        text2.text = skill2;
        button2.onClick.AddListener(() => UseSkill(skill2));

        // 3. Button
        int index3 = Random.Range(0, skills.Count);
        string skill3 = skills[index3];
        text3.text = skill3;
        button3.onClick.AddListener(() => UseSkill(skill3));

        UIBackGround.SetActive(true);
        Time.timeScale = 0f;
    }

    // Skill kullanma fonksiyonu
    private void UseSkill(string skillName)
    {

        switch (skillName)
        {
            case "Speed +":
                if (playerMovement != null)
                {
                    playerMovement.speed += 0.1f;
                    if (playerMovement.speed >= 1)
                    {
                        skills.Remove("Speed +");
                    }
                }
                break;

            case "Collect Range +":
                if (CollectCollider != null)
                {
                    CircleCollider2D col = CollectCollider.GetComponent<CircleCollider2D>();
                    if (col != null)
                        col.radius += 0.1f;
                    if(col.radius >= 0.8)
                    {
                        skills.Remove("Collect Range +");
                    }
                }
                break;
            case "Attack Speed +":
                if (playerSkills != null)
                {
                    playerSkills.AttackDelay -= 0.2f;
                    if(playerSkills.AttackDelay <= 0.6f)
                    {
                        skills.Remove("Attack Speed +");
                    }
                }
                break;
                

        }

        Time.timeScale = 1f;
        UIBackGround.SetActive(false);
    }
}
