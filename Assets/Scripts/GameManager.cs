using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    [SerializeField] private TextMeshProUGUI textScore;
    [HideInInspector] public int score = 0;
    [HideInInspector] public int totalScore = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void IncreaseScore()
    {
        score += 1;
        textScore.SetText("Score : " + score.ToString());
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void GameStart()
    {
        SceneManager.LoadScene("InGameScene");
    }
}
