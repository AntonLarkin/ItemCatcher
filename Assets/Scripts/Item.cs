using UnityEngine;

public class Item : BaseItem
{
    #region Variables

    [SerializeField] private int score;

    #endregion


    #region Private methods

    protected override void ApplyEffect()
    {
        scoreManager.GetTotalScore(score);
    }

    #endregion
}
