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



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roadScript = GameObject.FindGameObjectWithTag("roadLogic").GetComponent<roadScript>();
        truckScript = GameObject.FindGameObjectWithTag("truck").GetComponent<truckScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartGame()
    {
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
        roadScript.velocity = 0;
    }
}
