using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using DG.Tweening;

public class truckScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int lane = 2;
    private double lane1 = 2.21;
    private double lane2 = -1.22;
    private double lane3 = -4.79;
    private double duration = 0.8;
    public logicScript logic;
    public Animator animator;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        DOTween.SetTweensCapacity(2500, 50);
        animator.SetInteger("moving", 1);
        if (logicScript.difficultyGame == 3)
        {
            duration = 0.5;
        }
        else
        {
            duration = 0.8;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //allows player to change lanes
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (lane > 1)
            {
                lane -= 1;
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (lane < 3)
            {
                lane += 1;
            }
        }

        if (lane == 1)
        {
            //transform.position = new Vector3(transform.position.x, (float)lane1, transform.position.z);
            transform.DOLocalMoveY((float)lane1, (float)duration);
        }
        else if (lane == 2)
        {
            //transform.position = new Vector3(transform.position.x, (float)lane2, transform.position.z);
            transform.DOLocalMoveY((float)lane2, (float)duration);
        }
        else if (lane == 3)
        {
            //transform.position = new Vector3(transform.position.x, (float)lane3, transform.position.z);
            transform.DOLocalMoveY((float)lane3, (float)duration);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "box")
        {
            logic.addScore(1);
        }

        if (collision.collider.tag == "cone" || collision.collider.tag == "barricade" || collision.collider.tag == "person")
        {
            logic.gameOver();
        }
    }

    public void StopMoving()
    {
        animator.SetInteger("moving", 0);
    }
}
