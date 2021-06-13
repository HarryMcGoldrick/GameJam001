using System.Collections.Generic;
using UnityEngine;

public class CenterRing : MonoBehaviour
{
    public float radiusMultiplier = 0.1f;
    public float initialRadius = 1f;
    public float maxSize = 100;


    public float radius = 1;
    public List<GameObject> points;
    public GameObject pointPrefab;


    void Start()
    {
        points = new List<GameObject>(GameObject.FindGameObjectsWithTag("Points"));

        UpdateCirclePositions();
    }

    private void Update()
    {
        if (points.Count <= 0)
        {
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
    }


    public void AddPoint()
    {
        if (1 + points.Count > maxSize)
        {
            return;
        }

        GameObject point = Instantiate(pointPrefab);
        point.transform.SetParent(this.transform);
        points.Add(point);
        UpdateCirclePositions();
        int rand = Random.Range(1, 3);
        FindObjectOfType<SoundManager>().Play("OnRingAdd" + rand);
    }

    public void AddManyPoints(int count)
    {
        if (points.Count > maxSize)
        {
            return;
        }

        for (int i = 0; i < count; i++)
        {
            GameObject point = Instantiate(pointPrefab);
            point.transform.SetParent(this.transform);
            points.Add(point);
        }
        int rand = Random.Range(1, 3);
        FindObjectOfType<SoundManager>().Play("OnRingAdd" + rand);
        UpdateCirclePositions();
    }

    public void RemovePoint()
    {
        if (Application.isEditor)
        {
            DestroyImmediate(points[points.Count - 1]);

        }
        else
        {
            Destroy(points[points.Count - 1]);
        }
        points.RemoveAt(points.Count - 1);
        UpdateCirclePositions();

        if (points.Count == 0)
        {
            GameManager.Instance.SetGameState(GameState.GameOver);
        }
    }

    public void RemovePoint(GameObject pointToRemove)
    {
        points.Remove(pointToRemove);
        UpdateCirclePositions();
    }


    void UpdateCirclePositions()
    {
        if (points.Count == 0)
            return;
        radius = (radiusMultiplier * points.Count) + initialRadius;
        GetComponent<SphereCollider>().radius = radius;
        for (int i = 0; i < points.Count; i++)
        {
            float alpha = (2 * Mathf.PI) / points.Count;
            float x = radius * Mathf.Cos(i * alpha);
            float z = radius * Mathf.Sin(i * alpha);
            points[i].transform.position = new Vector3(this.transform.position.x + x, this.transform.position.y, this.transform.position.z + z);
            points[i].transform.rotation = Quaternion.LookRotation(this.transform.position - points[i].transform.position);
            points[i].transform.eulerAngles = new Vector3(points[i].transform.eulerAngles.x + 90, points[i].transform.eulerAngles.y, points[i].transform.eulerAngles.z);
        }

    }
}
