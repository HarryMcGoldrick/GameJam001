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
            ObstacleSpawner spawner = FindObjectOfType<ObstacleSpawner>();
            spawner.SpawnObstacle();
        }
    }
}
