using UnityEngine;

//start pos road1: -25
//start pos road2: 42
//when its fully off screen -43

public class roadScript : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    public road2Script road2Script;
    public float road1Position = 0;
    public logicScript logic;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
        road2Script = GameObject.FindGameObjectWithTag("roadLogic2").GetComponent<road2Script>();
        
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.linearVelocity = new Vector2(logic.velocity, myRigidBody.linearVelocity.y);
        road1Position = transform.position.x;
        if (transform.position.x <= -26)
        {
            transform.position = new Vector2(25, transform.position.y);
            Debug.Log("change position road 1");
        }

       
    }
}
