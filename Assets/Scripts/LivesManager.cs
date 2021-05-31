using UnityEngine;

public class LivesManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject[] lives;

    private int livesCounter;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        OnGameOver_UpdateLives();
    }

    private void OnEnable()
    {
        GameOver.OnGameOver += OnGameOver_UpdateLives;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= OnGameOver_UpdateLives;
    }

    #endregion


    #region Public methods

    public void LoseLife()
    {
        if (livesCounter > 0)
        {
            lives[livesCounter].SetActive(false);
            livesCounter--;
        }
        else
        {
            GameOver.GameOverSequence();
        }
    }

    public void AddLife()
    {
        if (livesCounter != lives.Length - 1)
        {
            livesCounter++;
            lives[livesCounter].SetActive(true);
        }
    }

    #endregion


    #region Eventhandlers

    private void OnGameOver_UpdateLives()
    {
        livesCounter = lives.Length - 1;

        foreach (var live in lives)
        {
            live.SetActive(true);
        }
    }

    #endregion
}
