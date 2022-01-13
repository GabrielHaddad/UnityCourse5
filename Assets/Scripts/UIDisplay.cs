using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] HealthScript playerHealth;
    [SerializeField] Slider healthBar;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    int maxHealth;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthBar.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        ShowScore();
        ShowHealth();
    }

    void ShowScore()
    {
        scoreText.text = scoreKeeper.GetCurrentScore().ToString("000000000");
    }

    void ShowHealth()
    {
        healthBar.value = playerHealth.GetHealth();
    }
}
