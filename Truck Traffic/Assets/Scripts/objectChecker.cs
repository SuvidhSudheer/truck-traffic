using System;
using UnityEngine;

public class objectChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int move = 0;
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

        if (collision.tag == "cone" || collision.tag == "car" || collision.tag == "barricade")
        {
            Debug.Log("cone in range");
            move = 1;
        }
    }
}
