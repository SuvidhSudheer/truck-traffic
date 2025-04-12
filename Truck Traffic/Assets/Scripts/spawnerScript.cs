using JetBrains.Annotations;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    public GameObject box;
    public GameObject cone;
    public GameObject barricade;
    public GameObject car;
    public float boxSpawnRate = 4;
    private float boxTimer = 0;
    public float coneSpawnRate = 4;
    private float coneTimer = 0;
    public float barricadeSpawnRate = 4;
    private float barricadeTimer = 0;
    public float carSpawnRate = 4;
    private float carTimer = 0;
    public float heightOffset = 10;
    public logicScript logic;
    private int barricadeThreshold = 10;
    private int carThreshold = 25;


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

        if (logic.score > barricadeThreshold)
        {
            if (barricadeTimer < barricadeSpawnRate)
            {
                barricadeTimer += Time.deltaTime;
            }
            else
            {
                barricadeSpawnRate = Random.Range(5, 8);
                spawnBarricade();
                barricadeTimer = 0;
            }
        }

        if (logic.score > carThreshold)
        {
            if (carTimer < carSpawnRate)
            {
                carTimer += Time.deltaTime;
            }
            else
            {
                carSpawnRate = Random.Range(5, 8);
                spawnCar();
                carTimer = 0;
            }
        }



    }

    void spawnBox()
    {
        double boxPos = 0;
        //picks which lane it will spawn on
        int boxLane = Random.Range(1, 4);
        Debug.Log($"{boxLane}");
        if (boxLane == 1)
        {
            boxPos = logic.lane1pos;
        }
        else if (boxLane == 2)
        {
            boxPos = logic.lane2pos;
        }
        else if (boxLane == 3 || boxLane == 4)
        {
            boxPos = logic.lane3pos;
        }
            Instantiate(box, new Vector3(transform.position.x, (float)boxPos, -1), transform.rotation);
            
    }

    void spawnCone()
    {
        double conePos = 0;
        //picks which lane it will spawn on
        int coneLane = Random.Range(1, 4);
        if (coneLane == 1)
        {
            conePos = 2.16;
        }
        else if (coneLane == 2)
        {
            conePos = -1.32;
        }
        else if (coneLane == 3 || coneLane == 3)
        {
            conePos = -4.86;
        }
        Instantiate(cone, new Vector3(transform.position.x, (float)conePos, -1), transform.rotation);
        
    }

    void spawnBarricade()
    {
        double barricadePos = 0;
        //picks which lane it will spawn on
        int barricadeLane = Random.Range(1, 2);
        if (barricadeLane == 1)
        {
            barricadePos = -1.02;
        }
        else if (barricadeLane == 2)
        {
            barricadePos = -4.62;
        }
    
        Instantiate(barricade, new Vector3(transform.position.x, (float)barricadePos, -1), transform.rotation);

    }
    void spawnCar()
    {
        double carPos = 0;
        //picks which lane it will spawn on
        int carLane = Random.Range(1, 2);
        if (carLane == 1)
        {
            carPos = 2.8;
        }
        else if (carLane == 2)
        {
            carPos = -4.21;
        }

            Instantiate(car, new Vector3(transform.position.x, (float)carPos, -1), transform.rotation);

    }
}
