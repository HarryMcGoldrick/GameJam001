using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObstacleSpawner))]
public class ObstacleSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Spawn Obstacle"))
        {
            ObstacleSpawner spawner = FindObjectsOfType<ObstacleSpawner>()[0];
            spawner.SpawnObstacle();
        }

        if (GUILayout.Button("Fill Array"))
        {
            MovingObstacle[] movingObstacles = Resources.LoadAll<MovingObstacle>("Prefabs");
            SpawnObstacle[] spawnObstacles = new SpawnObstacle[movingObstacles.Length];
            for (int i = 0; i < movingObstacles.Length; i++)
            {
                spawnObstacles[i] = new SpawnObstacle(3, movingObstacles[i].gameObject);
            }
            
            ObstacleSpawner spawner = FindObjectsOfType<ObstacleSpawner>()[0];
            spawner.Obstacles = spawnObstacles;
        }
    }
}
