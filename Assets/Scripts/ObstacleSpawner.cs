using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Transform obstacleParent;
    public SpawnObstacle[] Obstacles;
    public Vector3 Size;
    public Vector3 center;
    public float spawnTime;
    public float rampTime;
    public float minSpawnTime;


    private float spawnTimer = 0f;
    private float rampTimer = 0f;
    private int[] weights;

    private void Start()
    {
        weights = new int[Obstacles.Length];
        for (int i = 0; i < Obstacles.Length; i++)
        {
            weights[i] = Obstacles[i].weight;
        }
    }

    private void Update()
    {
        center = this.transform.position;

        spawnTimer += Time.deltaTime;
        rampTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            spawnTimer = 0f;
            SpawnObstacle();
        }
        if (rampTimer >= 1f)
        {
            if (spawnTime-rampTime > minSpawnTime)
            {
                spawnTime -= rampTime;
            } else
            {
                spawnTime = minSpawnTime;
            }
            rampTimer = 0f;
        }

    }

    public void SpawnObstacle()
    {
        Vector3 spawnPos = center + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), 0, Random.Range(-Size.z / 2, Size.z / 2));
        
        GameObject spawn = Instantiate(Obstacles[GetRandomWeightedIndex(weights)].obstacle);
        spawn.transform.position = spawnPos;
        spawn.transform.SetParent(obstacleParent);

        if (spawn.CompareTag("Cloud"))
        {
            spawn.transform.eulerAngles = new Vector3(0, Random.Range(0, 360), 0);

            // spawn 2 more, dont kill me mark for what i have done
            for (int i = 0; i < 10; i++)
            {

            }
           
        } else { 
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(this.transform.position, Size);
    }

    public int GetRandomWeightedIndex(int[] weights)
    {
        // Get the total sum of all the weights.
        int weightSum = 0;
        for (int i = 0; i < weights.Length; ++i)
        {
            weightSum += weights[i];
        }

        // Step through all the possibilities, one by one, checking to see if each one is selected.
        int index = 0;
        int lastIndex = weights.Length - 1;
        while (index < lastIndex)
        {
            // Do a probability check with a likelihood of weights[index] / weightSum.
            if (Random.Range(0, weightSum) < weights[index])
            {
                return index;
            }

            // Remove the last item from the sum of total untested weights and try again.
            weightSum -= weights[index++];
        }

        // No other item was selected, so return very last index.
        return index;
    }
}

[System.Serializable]
public struct SpawnObstacle
{
    [Range(1,100)]
    public int weight;
    public GameObject obstacle;

    public SpawnObstacle(int weight, GameObject obstacle)
    {
        this.weight = weight;
        this.obstacle = obstacle;
    }
}
