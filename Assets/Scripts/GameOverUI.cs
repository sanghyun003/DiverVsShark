using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour 
{
    public static GameOverUI instance = null;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI textGameScore;
    [SerializeField] TextMeshProUGUI textTotalScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void SetGameOver()
    {
        SharkSpawner sharkSpawner = FindAnyObjectByType<SharkSpawner>();
        if (sharkSpawner != null)
        {
            sharkSpawner.StopSpawnEnemies();
        }

        // totalScore PlayerPrefs에 저장
        GameManager.instance.totalScore = PlayerPrefs.GetInt("TotalScore", 0);
        GameManager.instance.totalScore += GameManager.instance.score;
        PlayerPrefs.SetInt("TotalScore", GameManager.instance.totalScore);
        PlayerPrefs.Save();

        textTotalScore.SetText("Total Score : " + GameManager.instance.totalScore.ToString());
        textGameScore.SetText("Game Score : " + GameManager.instance.score.ToString());

        Invoke("ShowGameOverPanel", 0.5f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
