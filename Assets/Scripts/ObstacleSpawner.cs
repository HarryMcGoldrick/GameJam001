using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject[] Obstacles;
    public Vector3 Size;
    public Vector3 center;
    public float spawnTime;


    private float timer = 0f;

    private void Update()
    {
        center = this.transform.position;

        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
            timer = 0f;
            SpawnObstacle();
        }
    }

    public void SpawnObstacle()
    {
        Vector3 spawnPos = center + new Vector3(Random.Range(-Size.x / 2, Size.x / 2), 0, Random.Range(-Size.z / 2, Size.z / 2));
        GameObject spawn = Instantiate(Obstacles[Random.Range(0, Obstacles.Length)]);
        spawn.transform.position = spawnPos;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(this.transform.position, Size);
    }
}
