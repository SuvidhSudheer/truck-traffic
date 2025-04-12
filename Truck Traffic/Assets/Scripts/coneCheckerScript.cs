using UnityEngine;

public class coneCheckerScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public barricadeScript barricadeScript;
    void Start()
    {
        barricadeScript = GameObject.FindGameObjectWithTag("barricade").GetComponent<barricadeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "cone")
        {
            barricadeScript.destroyBarricade();
        }
    }
}
