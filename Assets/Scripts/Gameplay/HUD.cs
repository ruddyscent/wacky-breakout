using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText = null;
    [SerializeField]
    Text ballsLeftText = null;
    int score = 0;
    int ballsLeft;
    const string scorePrefix = "Score: ";
    const string ballsLeftPrefix = "Balls: ";

    #region Properties
    
    public int BallsLeft
    {
        get { return ballsLeft; }
    }

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ballsLeft = ConfigurationUtils.GivenNumberOfBalls;
        scoreText.text = scorePrefix + score.ToString();
        ballsLeftText.text = ballsLeftPrefix + ballsLeft.ToString();
        EventManager.AddAddPointsListener(AddPoints);
        EventManager.AddLooseBallListener(ReduceBallsLeft);
        EventManager.AddBlockDestroyedListener(GameOver);
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = scorePrefix + score.ToString();
    }

    public void ReduceBallsLeft()
    {
        ballsLeft -= 1;
        ballsLeftText.text = ballsLeftPrefix + ballsLeft.ToString();
    }

    void GameOver()
    {
        GameObject[] blocks = GameObject.FindGameObjectsWithTag("Block");
        if (blocks.Length == 1)
        {
            Object.Instantiate(Resources.Load("GameOverMenu"));
        }
    }
}
