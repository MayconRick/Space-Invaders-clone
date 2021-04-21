using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour, IEndGameOverObserver
{
	#region Field Declarations

	[Header("UI Components")]
    [Space]
	public Text scoreText;
    public StatusText statusText;
    public Button restartButton;

    [Header("Ship Counter")]
    [SerializeField]
    [Space]
    private Image[] shipImages;

    private GameSceneController gameSceneController;

    #endregion

    #region Startup

    private void Awake()
    {
        statusText.gameObject.SetActive(false);
    }

    private void Start()
    {
        gameSceneController = FindObjectOfType<GameSceneController>();

        gameSceneController.AddObserver(this);

        gameSceneController.ScoreUpdatedOnKill += GameSceneController_ScoreUpdatedOnKill;
        gameSceneController.LifeLost += HideShip;

    }

    private void GameSceneController_ScoreUpdatedOnKill(int pointValue)
    {
        UpdateScore(pointValue);
    }

    #endregion

    #region Public methods

    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString("D5");
    }

    public void ShowStatus(string newStatus)
    {
        statusText.gameObject.SetActive(true);
        StartCoroutine(statusText.ChangeStatus(newStatus));
    }

    public void HideShip(int imageIndex)
    {
        shipImages[imageIndex].gameObject.SetActive(false);
    }

    public void ResetShips()
    {
        foreach (Image ship in shipImages)
            ship.gameObject.SetActive(true);
    }

    public void Notify()
    {
        restartButton.gameObject.SetActive(true);

        if (gameSceneController.isGameOver)
        {
            ShowStatus("Game Over");

        } else
        {
            ShowStatus("You Win!");
        }
       
    }

    #endregion
}
