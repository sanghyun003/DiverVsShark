using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public static GameOverUI instance = null;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TextMeshProUGUI textGameScore;

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
        textGameScore.SetText("Game Score : " + GameManager.instance.score.ToString());
        Invoke("ShowGameOverPanel", 0.5f);
    }

    void ShowGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }
}
