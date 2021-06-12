using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterRing : MonoBehaviour
{
    public float radiusMultiplier = 0.1f;
    public float initialRadius = 1f;

    private float radius = 1;
    public List<GameObject> points;
    public GameObject pointPrefab;


    void Start()
    {
        points = new List<GameObject>(GameObject.FindGameObjectsWithTag("Points"));

        UpdateCirclePositions();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPoint()
    {
        GameObject point = Instantiate(pointPrefab);
        point.transform.SetParent(this.transform);
        // Remove later
        point.transform.localScale = new Vector3(1, 100, 1);
        points.Add(point);
        UpdateCirclePositions();

    }

    public void RemovePoint()
    {
        Destroy(points[points.Count - 1]);
        points.RemoveAt(points.Count - 1);
        UpdateCirclePositions();
    }


    void UpdateCirclePositions()
    {
        radius = radiusMultiplier * points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            float alpha = (2 * Mathf.PI) / points.Count;
            float x = radius * Mathf.Cos(i * alpha);
            float z = radius * Mathf.Sin(i * alpha);
            points[i].transform.position = new Vector3(this.transform.position.x + x, points[i].transform.position.y, this.transform.position.z + z);
        }
    }
}
