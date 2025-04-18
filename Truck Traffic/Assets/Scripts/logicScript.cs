using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class logicScript : MonoBehaviour
{
    public double lane1pos = 3;
    public double lane2pos = -0.5;
    public double lane3pos = -4;
    public int score = 0;
    public TMP_Text scoreText;
    public roadScript roadScript;
    public truckScript truckScript;
    public static int difficultyGame = 0;
    public int scoreStage = 5;
    public int increment = 1;
    public float velocity = -5;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roadScript = GameObject.FindGameObjectWithTag("roadLogic").GetComponent<roadScript>();
        truckScript = GameObject.FindGameObjectWithTag("truck").GetComponent<truckScript>();
        if (difficultyGame == 1)
        {
            velocity = -5;
            scoreStage = 8;
            increment = 1;
        }
        else if (difficultyGame == 2)
        {
            velocity = -10;
            scoreStage = 5;
            increment = 2;
        }
        else if (difficultyGame == 3)
        {
            velocity = -15;
            scoreStage = 2;
            increment = 5;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (score == scoreStage)
        {
            velocity -= increment;
            scoreStage += scoreStage;
        }
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void startGame(int difficulty)
    {
        difficultyGame = difficulty;
        SceneManager.LoadScene("GameScene");
    }

    public void gameOver()
    {
        //SceneManager.LoadScene("EndScene");
        truckScript.StopMoving();
        StartCoroutine(ChangeVelocityUntil());
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = $"Score: {score}";
    }

    private IEnumerator ChangeVelocityUntil()
    {
       
        yield return new WaitForSeconds((float)0.5);
        velocity = 0;
    }
}
