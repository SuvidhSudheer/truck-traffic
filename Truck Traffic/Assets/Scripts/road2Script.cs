using UnityEngine;

public class road2Script : MonoBehaviour
{
    private Rigidbody2D myRigidBody;
    public float road2Position = 0;
    public roadScript roadScript;
    public logicScript logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        roadScript = GameObject.FindGameObjectWithTag("roadLogic").GetComponent<roadScript>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.linearVelocity = new Vector2(roadScript.velocity, myRigidBody.linearVelocity.y);
        road2Position = transform.position.x;
        if (transform.position.x <= -26)
        {
            transform.position = new Vector2(25, transform.position.y);
            Debug.Log("change position road 2");
        }
    } 
}
