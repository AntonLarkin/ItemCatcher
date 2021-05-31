using UnityEngine;

public class UiManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject scoreView;
    [SerializeField] private GameObject livesView;
    [SerializeField] private GameObject gameOverView;

    #endregion


    #region UnityLifecycel

    private void OnEnable()
    {
        GameOver.OnGameOver += OnGameOver_ShowGameOverView;
        SceneLoader.OnRestartButtonClicked += OnRestartButtonClicked_ShowGameUi;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= OnGameOver_ShowGameOverView;
    }

    #endregion


    #region Event handlers

    private void OnGameOver_ShowGameOverView()
    {
        gameOverView.SetActive(true);
        livesView.SetActive(false);
        scoreView.SetActive(false);
    }

    private void OnRestartButtonClicked_ShowGameUi()
    {
        gameOverView.SetActive(false);
        livesView.SetActive(true);
        scoreView.SetActive(true);
    }

    #endregion

}
