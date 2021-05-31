using UnityEngine;

public class SfxAudioSource : MonoBehaviour
{
    #region Variables

    [SerializeField] private AudioClip gameOverClip;

    private AudioSource audioSource;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        GameOver.OnGameOver += OnGameOver_PlayGameOverClip;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= OnGameOver_PlayGameOverClip;

    }
    #endregion


    #region Public methods

    public void PlaySfx(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    #endregion


    #region Event handlers

    private void OnGameOver_PlayGameOverClip()
    {
        audioSource.PlayOneShot(gameOverClip);
    }

    #endregion
}

