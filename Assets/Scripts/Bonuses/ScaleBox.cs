using UnityEngine;

public class ScaleBox : BaseItem
{
    #region Variables

    [SerializeField] private float scaleModifier;
    [SerializeField] private float borderDifference;

    private float baseScale = 1.3f;

    #endregion


    #region Private methods

    protected override void ApplyEffect()
    {
        var box = FindObjectOfType<Box>();

        if (box.transform.localScale.x < baseScale && scaleModifier > 1.3f)
        {
            box.ReloadBox();
        }
        else if (box.transform.localScale.x > baseScale && scaleModifier < 1.3f)
        {
            box.ReloadBox();
        }
        else if (box.transform.localScale.x > baseScale && scaleModifier > 1.3f)
        {
            return;
        }
        else if (box.transform.localScale.x < baseScale && scaleModifier < 1.3f)
        {
            return;
        }
        else
        {
            box.ScaleBox(scaleModifier, borderDifference);
        }
    }

    #endregion
}
