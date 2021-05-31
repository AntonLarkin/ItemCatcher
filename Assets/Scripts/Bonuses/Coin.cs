using UnityEngine;

public class Coin : BaseItem
{
    #region Variables

    [SerializeField] private int bonus;

    #endregion


    #region Private methods

    protected override void ApplyEffect()
    {
        var score = FindObjectOfType<ScoreManager>();
        score.AddScoreBonus(bonus);
    }

    #endregion
}
