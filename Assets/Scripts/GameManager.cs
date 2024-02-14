using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform ball;
    public float startSpeed = 3f;
    public GoalTrigger leftGoalTrigger;
    public GoalTrigger rightGoalTrigger;
    public Paddle leftPaddle;
    public Paddle rightPaddle;

    int leftPlayerScore = -2;
    int rightPlayerScore = -2;
    Vector3 ballStartPos;
    public TextMeshProUGUI ScoreBoard;

    const int scoreToWin = 11;

    //---------------------------------------------------------------------------
    void Start()
    {
        ballStartPos = ball.position;
        Rigidbody ballBody = ball.GetComponent<Rigidbody>();
        ballBody.velocity = new Vector3(1f, 0f, 0f) * startSpeed;
        ScoreBoard.SetText($"{leftPlayerScore}\t{rightPlayerScore}");
        Debug.Log($"{leftPlayerScore}\t{rightPlayerScore}");
        ScoreBoard.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    //---------------------------------------------------------------------------
    public void OnGoalTrigger(GoalTrigger trigger)
    {
        // If the ball entered a goal area, increment the score, check for win, and reset the ball
        Debug.Log($"{leftPlayerScore}\t{rightPlayerScore}");
        if (trigger == leftGoalTrigger)
        {
            rightPlayerScore++;
            Debug.Log($"Right player scored: {rightPlayerScore}");

            if (rightPlayerScore == scoreToWin)
                Debug.Log("Right player wins!");
            else
                ResetBall(-1f);
        }
        else if (trigger == rightGoalTrigger)
        {
            leftPlayerScore++;
            Debug.Log($"Left player scored: {leftPlayerScore}");

            if (rightPlayerScore == scoreToWin)
                Debug.Log("Right player wins!");
            else
                ResetBall(1f);
        }
        ScoreBoard.SetText($"{leftPlayerScore}\t{rightPlayerScore}");
        ScoreBoard.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1);
    }

    //---------------------------------------------------------------------------
    public void OnSpeedTrigger()
    {
        leftPaddle.speed += 0.5f;
        rightPaddle.speed += 0.5f;
    }

    //---------------------------------------------------------------------------
    public void OnSizeTrigger()
    {
        leftPaddle.transform.localScale += new Vector3(0f, 0f, 0.5f);
        rightPaddle.transform.localScale += new Vector3(0f, 0f, 0.5f);
        leftPaddle.maxTravelHeight -= 0.25f;
        leftPaddle.minTravelHeight += 0.25f;
        rightPaddle.maxTravelHeight -= 0.25f;
        rightPaddle.minTravelHeight += 0.25f;
    }

    //---------------------------------------------------------------------------
    void ResetBall(float directionSign)
    {
        ball.position = ballStartPos;

        // Start the ball within 20 degrees off-center toward direction indicated by directionSign
        directionSign = Mathf.Sign(directionSign);
        Vector3 newDirection = new Vector3(directionSign, 0f, 0f) * startSpeed;
        newDirection = Quaternion.Euler(0f, Random.Range(-20f, 20f), 0f) * newDirection;

        var rbody = ball.GetComponent<Rigidbody>();
        rbody.velocity = newDirection;
        rbody.angularVelocity = new Vector3();

        // We are warping the ball to a new location, start the trail over
        ball.GetComponent<TrailRenderer>().Clear();
    }
}