using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private Text scoreLabel;
    [SerializeField] private Text finalScoreLabel;

    private int totalScore;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        GameOver.OnGameOver += OnGameOver_UpdateTotalScore;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= OnGameOver_UpdateTotalScore;
    }

    private void Update()
    {
        UpdateScore();
    }

    #endregion


    #region Public methods

    public void AddScoreBonus(int bonus)
    {
        totalScore += bonus;
    }

    public int GetTotalScore(int score)
    {
        if (score < 0 && totalScore < -score)
        {
            return totalScore = 0;
        }
        else
        {
            return totalScore += score;
        }
    }

    #endregion


    #region PrivateMethods

    private void UpdateScore()
    {
        scoreLabel.text = totalScore.ToString();
    }

    #endregion


    #region EventHandlers

    private void OnGameOver_UpdateTotalScore()
    {
        finalScoreLabel.text = totalScore.ToString();
        totalScore = 0;
    }

    #endregion
}
