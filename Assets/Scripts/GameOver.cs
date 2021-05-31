using System;

public static class GameOver
{
    #region Events

    public static event Action OnGameOver;

    #endregion


    #region Public methods

    public static void GameOverSequence()
    {
        OnGameOver?.Invoke();
    }

    #endregion
}
