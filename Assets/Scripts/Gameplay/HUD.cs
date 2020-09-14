using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Text ballsLeftText;
    int score;
    int ballsLeft;
    const string ScorePrefix = "Score: ";
    const string BallsLeftPrefix = "Balls: ";

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = ScorePrefix + score.ToString();
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
    }

    public void AddPoints(int points)
    {
        score += points;
        scoreText.text = ScorePrefix + score.ToString();
    }

    public void LooseBall()
    {
        ballsLeft -= 1;
        ballsLeftText.text = BallsLeftPrefix + ballsLeft.ToString();
    }
}
