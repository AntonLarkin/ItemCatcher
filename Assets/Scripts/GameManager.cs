using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("Audio")]
    [SerializeField] private AudioSource audioSource;

    [Header("Items")]
    [SerializeField] private GameObject[] items;
    [SerializeField] private float startSpawningItemTime;
    [SerializeField] private float spawningRangeItemTime;

    [Header("Bonus Items")]
    [SerializeField] private GameObject[] bonusItems;
    [SerializeField] private float startSpawningBonusTime;
    [SerializeField] private float spawningRangeBonusTime;

    [SerializeField] private float spawnPositionX;
    [SerializeField] private float spawnpositionY;

    private bool isGameOver;

    [Header("Speed")]
    private float gravityScale = 0.8f;
    [SerializeField] private float speedModifier;

    #endregion


    #region Unity lifecycle

    private void OnEnable()
    {
        GameOver.OnGameOver += OnGameOver_StopSpawning;
        GameOver.OnGameOver += OnGameOver_MainThemeStop;
        SceneLoader.OnRestartButtonClicked += OnRestartButtonClicked_StartSpawnItem;
        SceneLoader.OnRestartButtonClicked += OnRestartButtonClicked_ReloadSpeed;
        SceneLoader.OnRestartButtonClicked += OnRestartButtonClicked_PlayMainTheme;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= OnGameOver_StopSpawning;
        GameOver.OnGameOver -= OnGameOver_MainThemeStop;
        SceneLoader.OnRestartButtonClicked -= OnRestartButtonClicked_StartSpawnItem;
        SceneLoader.OnRestartButtonClicked -= OnRestartButtonClicked_ReloadSpeed;
        SceneLoader.OnRestartButtonClicked -= OnRestartButtonClicked_PlayMainTheme;
    }

    private void Start()
    {
        SpawnItems();
    }

    #endregion


    #region Private methods

    private void SpawnItems()
    {
        InvokeRepeating(nameof(RiseFallingSpeed), startSpawningItemTime, spawningRangeItemTime);

        InvokeRepeating(nameof(SpawnItem), startSpawningItemTime, spawningRangeItemTime);
        InvokeRepeating(nameof(SpawnBonus), startSpawningBonusTime, spawningRangeBonusTime);
    }

    private void SpawnItem()
    {
        if (!isGameOver)
        {
            Instantiate(DefineCurrentItem(), DefineSpawnPosition(), Quaternion.identity);
        }
    }

    private void SpawnBonus()
    {
        if (!isGameOver)
        {
            Instantiate(DefineBonusItem(), DefineSpawnPosition(), Quaternion.identity);
        }
    }

    private Vector3 DefineSpawnPosition()
    {
        var finalSpawnPositionX = Random.Range(-spawnPositionX, spawnPositionX);

        Vector3 spawnPosition = new Vector2(finalSpawnPositionX, spawnpositionY);
        return spawnPosition;

    }

    private GameObject DefineCurrentItem()
    {
        int position = Random.Range(0, items.Length);
        ChangeSpeed(items[position]);

        return items[position];
    }

    private GameObject DefineBonusItem()
    {
        int position = Random.Range(0, bonusItems.Length);
        ChangeSpeed(bonusItems[position]);

        return bonusItems[position];
    }

    private void RiseFallingSpeed()
    {
        gravityScale += speedModifier;
    }

    private void ChangeSpeed(GameObject item)
    {
        item.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
    }

    #endregion


    #region Event handlers

    private void OnGameOver_StopSpawning()
    {
        isGameOver = true;
        var remainingObjects = FindObjectsOfType<Item>();

        for (int i = 0; i < remainingObjects.Length; i++)
        {
            Destroy(remainingObjects[i].gameObject);
        }

    }

    private void OnGameOver_MainThemeStop()
    {
        audioSource.Stop();
    }

    private void OnRestartButtonClicked_StartSpawnItem()
    {
        isGameOver = false;
    }

    private void OnRestartButtonClicked_ReloadSpeed()
    {
        gravityScale = 0.8f;
    }

    private void OnRestartButtonClicked_PlayMainTheme()
    {
        audioSource.Play();
    }

    #endregion

}
