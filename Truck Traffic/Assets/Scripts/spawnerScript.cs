using JetBrains.Annotations;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject box;
    public GameObject cone;
    public float boxSpawnRate = 4;
    private float boxTimer = 0;
    public float coneSpawnRate = 4;
    private float coneTimer = 0;
    public float heightOffset = 10;
    public logicScript logic;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        if (boxTimer < boxSpawnRate)
        {
            boxTimer += Time.deltaTime;
        }
        else
        {
            boxSpawnRate = Random.Range(4, 6);
            spawnBox();
            boxTimer = 0;
        }

        if (coneTimer < coneSpawnRate)
        {
            coneTimer += Time.deltaTime;
        }
        else
        {
            coneSpawnRate = Random.Range(4, 7);
            spawnCone();
            coneTimer = 0;
        }

    }

    void spawnBox()
    {
        double boxPos = 0;
        //picks which lane it will spawn on
        int boxLane = Random.Range(1, 3);
        if (boxLane == 1)
        {
            boxPos = logic.lane1pos;
        }
        else if (boxLane == 2)
        {
            boxPos = logic.lane2pos;
        }
        else if (boxLane == 3)
        {
            boxPos = logic.lane3pos;
        }
            Instantiate(box, new Vector3(transform.position.x, (float)boxPos, -1), transform.rotation);
            
    }

    void spawnCone()
    {
        double conePos = 0;
        //picks which lane it will spawn on
        int coneLane = Random.Range(1, 3);
        if (coneLane == 1)
        {
            conePos = 2.16;
        }
        else if (coneLane == 2)
        {
            conePos = -1.32;
        }
        else if (coneLane == 3)
        {
            conePos = -4.86;
        }
        Instantiate(cone, new Vector3(transform.position.x, (float)conePos, -1), transform.rotation);
        
    }
}
