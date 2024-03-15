using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDungeonVizualizer : MonoBehaviour
{
    [SerializeField] private Transform _floorTemplate;

    private List<Transform> _floorsList = new List<Transform>();

    public void CreateFloorObjects(IEnumerable<Vector3Int> floorPosition)
    {
        CreateObjects(floorPosition, _floorTemplate);
    }

    public void DeleteFloorObjects()
    {
        foreach (Transform floor in _floorsList) 
        {
            DestroyImmediate(floor.gameObject);
        }

        _floorsList.Clear();
    }

    private void CreateObjects(IEnumerable<Vector3Int> Positions, Transform Template)
    {
        foreach (var position in Positions)
        {
            CreateObject(Template, position);
        }
    }

    private void CreateObject(Transform template, Vector3Int position)
    {
        Vector3 newPosition = position;
        newPosition.y = template.transform.localScale.y / 2;
        Transform floor = Instantiate(template, newPosition, Quaternion.identity, transform);
        _floorsList.Add(floor);
    }
}
