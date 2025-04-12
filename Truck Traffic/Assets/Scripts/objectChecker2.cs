using UnityEngine;

public class objectChecker2 : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int move = 0;
    public carScript carScript;
    void Start()
    {
        carScript = GameObject.FindGameObjectWithTag("car").GetComponent<carScript>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "cone" || collision.tag == "car" || collision.tag == "barricade")
        {
            move = 1;
        }
    }
}
