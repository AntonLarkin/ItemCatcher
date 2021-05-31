using UnityEngine;

public abstract class BaseItem : MonoBehaviour
{
    #region Variables

    [SerializeField] private bool isGoodItem;
    protected ScoreManager scoreManager;
    private LivesManager livesManager;

    [Header("Audio")]
    [SerializeField] private AudioClip audioClipSuccess;
    [SerializeField] private AudioClip audioClipFail;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        livesManager = FindObjectOfType<LivesManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tags.Box))
        {
            PlaySound(audioClipSuccess);

            ApplyEffect();
            Destroy(gameObject);
        }

        if (isGoodItem && collision.gameObject.CompareTag(Tags.Ground))
        {
            PlaySound(audioClipFail);

            livesManager.LoseLife();
        }

        Destroy(gameObject);
    }

    #endregion


    #region Private methods

    protected abstract void ApplyEffect();

    private void PlaySound(AudioClip audioClip)
    {
        var audioSource = FindObjectOfType<SfxAudioSource>();
        audioSource.PlaySfx(audioClip);
    }

    #endregion
}
