using Unity.VisualScripting;
using UnityEngine;

public class barricadeScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Rigidbody2D myRigidBody;
    public roadScript roadScript;
    public objectChecker objectChecker;
    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        roadScript = GameObject.FindGameObjectWithTag("roadLogic").GetComponent<roadScript>();
        objectChecker = GameObject.FindGameObjectWithTag("objectChecker").GetComponent<objectChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        myRigidBody.linearVelocity = new Vector2(roadScript.velocity, myRigidBody.linearVelocity.y);

        if (transform.position.x < -10)
        {
            Debug.Log("barricade Deleted");
            Destroy(gameObject);
        }

        if (objectChecker.move == 1)
        {
            transform.position = new Vector3(transform.position.x + 40, transform.position.y, transform.position.z);
            objectChecker.move = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "truck")
        {
            Debug.Log("game over");
        }
        else if (collision.collider.tag == "box" || collision.collider.tag == "cone")
        {
            transform.position = new Vector3(transform.position.x + 20, transform.position.y, transform.position.z);
        }
    }

    public void destroyBarricade()
    {
        Destroy(gameObject);
    }


}

