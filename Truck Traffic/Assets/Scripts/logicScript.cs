using UnityEngine;
using UnityEngine.SceneManagement;

public class logicScript : MonoBehaviour
{
    public double lane1pos = 3;
    public double lane2pos = -0.5;
    public double lane3pos = -4;
    public int score = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
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
        SceneManager.LoadScene("EndScene");
    }
}
