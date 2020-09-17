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

    // Start is called before the first frame update
    void Start()
    {
        ballsLeft = ConfigurationUtils.GivenNumberOfBalls;
        scoreText.text = scorePrefix + score.ToString();
        ballsLeftText.text = ballsLeftPrefix + ballsLeft.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = scorePrefix + score.ToString();
    }

    public void LooseBall()
    {
        ballsLeft -= 1;
        ballsLeftText.text = ballsLeftPrefix + ballsLeft.ToString();
    }
}
