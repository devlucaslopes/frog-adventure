using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int Health;
    
    [Header("Health")]
    [SerializeField] private Image[] HealthIcons;
    
    [Header("Game Over")]
    [SerializeField] private GameObject GameOverPanel;

    [Header("Score")]
    [SerializeField] private TextMeshProUGUI ScoreText;

    [Header("Level Completed")]
    [SerializeField] private GameObject LevelCompletedPanel;
    [SerializeField] private TextMeshProUGUI FinalScore;

    public static GameManager Instance;

    private int _totalScore = 0;

    private void Start() {
        Time.timeScale = 1;

        Instance = this;
    }
    
    private void OnEnable()
    {
        PlayerHealth.OnHit += HandleHealth;
        PlayerRespawn.OnFalling += HandleHealth;
    }

    private void OnDisable()
    {
        PlayerHealth.OnHit -= HandleHealth;
        PlayerRespawn.OnFalling -= HandleHealth;
    }

    public void UpdateScore(int value) {
        _totalScore += value;
        ScoreText.text = _totalScore.ToString();
    }

    private void HandleHealth() {
        Health--;

        HealthIcons[Health].color = Color.black;

        if (Health <= 0) {
            ShowGameOver();
        }
    }

    private void ShowGameOver() {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ShowLevelCompleted() {
        FinalScore.text = _totalScore.ToString();
        LevelCompletedPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }
}
