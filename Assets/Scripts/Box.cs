using UnityEngine;

public class Box : MonoBehaviour
{
    #region Variables

    [SerializeField] private float XRange;

    private float leftBorder;
    private float rightBorder;
    private bool isGameOver;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        leftBorder = -XRange;
        rightBorder = XRange;

        Debug.Log(leftBorder);
    }

    private void OnEnable()
    {
        GameOver.OnGameOver += OnGameOver_StopBoxMoving;
        SceneLoader.OnRestartButtonClicked += OnRestartButtonClicked_StartBoxMoving;
    }

    private void OnDisable()
    {
        GameOver.OnGameOver -= OnGameOver_StopBoxMoving;
        SceneLoader.OnRestartButtonClicked -= OnRestartButtonClicked_StartBoxMoving;
    }

    private void Update()
    {
        if (isGameOver)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            MoveBox();
        }
    }

    #endregion


    #region Public methods

    public void ScaleBox(float scaleModifier, float borderDifference)
    {
        Vector3 scaleBox = new Vector3(scaleModifier, scaleModifier, scaleModifier);
        transform.localScale = scaleBox;

        leftBorder -= borderDifference;
        rightBorder += borderDifference;
    }

    public void ReloadBox()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        leftBorder = -XRange;
        rightBorder = XRange;
    }

    #endregion


    #region Private methods

    private void MoveBox()
    {
        Vector3 boxPosition = Vector3.zero;

        Vector3 positionInPixels = Input.mousePosition;
        Vector3 positionInWorld = Camera.main.ScreenToWorldPoint(positionInPixels);

        boxPosition = positionInWorld;
        boxPosition.y = transform.position.y;
        boxPosition.z = transform.position.z;

        boxPosition.x = Mathf.Clamp(boxPosition.x, leftBorder, rightBorder);
        transform.position = boxPosition;
    }

    #endregion


    #region Event handlers

    private void OnGameOver_StopBoxMoving()
    {
        isGameOver = true;
    }

    private void OnRestartButtonClicked_StartBoxMoving()
    {
        isGameOver = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ReloadBox();
    }

    #endregion

}
