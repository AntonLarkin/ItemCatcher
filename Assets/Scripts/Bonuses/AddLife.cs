public class AddLife : BaseItem
{
    #region Private methods

    protected override void ApplyEffect()
    {
        var livesManager = FindObjectOfType<LivesManager>();
        livesManager.AddLife();
    }

    #endregion



}
