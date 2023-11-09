using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] obstacles;
    Vector3 spawnPos;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine("SpawnObstacles");
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameOver)
        {
            StopCoroutine("SpawnObstacles");
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (true)
        {
            Spawn();

            yield return new WaitForSeconds(spawnRate);
        }
    }

    void Spawn()
    {
        int randObstacle = Random.Range(0, obstacles.Length);

        spawnPos = transform.position;

        int randSpot = Random.Range(0, 2);

        if (randSpot < 1)
        {
            Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
        }
        else
        {
            spawnPos.y = -transform.position.y;

            GameObject obs = Instantiate(obstacles[randObstacle], spawnPos, transform.rotation);
            obs.transform.eulerAngles = new Vector3(0, 180, 180);
        }

        
    }


}
