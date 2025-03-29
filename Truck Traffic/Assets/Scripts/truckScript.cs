using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class truckScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int lane = 2;
    private double lane1 = 2.21;
    private double lane2 = -1.22;
    private double lane3 = -4.79;
    public logicScript logic;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
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
            transform.position = new Vector3(transform.position.x, (float)lane1, transform.position.z);
        }
        else if (lane == 2)
        {
            transform.position = new Vector3(transform.position.x, (float)lane2, transform.position.z);
        }
        else if (lane == 3)
        {
            transform.position = new Vector3(transform.position.x, (float)lane3, transform.position.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "box")
        {
            logic.score += 1;
        }

        if (collision.collider.tag == "cone")
        {
            logic.gameOver();
        }
    }
}
