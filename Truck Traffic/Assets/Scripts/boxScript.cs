using UnityEngine;

public class boxScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D myRigidBody;
    public roadScript roadScript;
    public logicScript logic;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        roadScript = GameObject.FindGameObjectWithTag("roadLogic").GetComponent<roadScript>();
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.linearVelocity = new Vector2(logic.velocity, myRigidBody.linearVelocity.y);

        if (transform.position.x < -10)
        {
            Debug.Log("box Deleted");
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "truck")
        {
            Destroy(gameObject);
        }
    }
}
