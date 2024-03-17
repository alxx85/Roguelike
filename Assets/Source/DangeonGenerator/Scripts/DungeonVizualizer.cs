using System.Collections.Generic;
using UnityEngine;

public class DungeonVizualizer : MonoBehaviour
{
    [SerializeField] private Transform _floorTemplate;
    [SerializeField] private Transform _wallTemplate;

    private List<Transform> _dungeonObjectsList = new List<Transform>();

    public void CreateFloorObjects(IEnumerable<Vector3Int> floorPosition)
    {
        CreateObjects(floorPosition, _floorTemplate);
    }

    public void DeleteFloorObjects()
    {
        foreach (Transform floor in _dungeonObjectsList) 
        {
            DestroyImmediate(floor.gameObject);
        }

        _dungeonObjectsList.Clear();
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
        _dungeonObjectsList.Add(floor);
    }

    public void CreateWallsObject(HashSet<Vector3Int> floorPosition)
    {
        foreach (Vector3Int direction in Direction3D.GetDirectionList())
        {
            var directionWallsPosition = WallsGenerator.GetWallsPositions(floorPosition, direction);
            float WallAngle = GetAngleOfDirection(direction);
            CreatWalls(_wallTemplate, directionWallsPosition, WallAngle);
        }
    }

    private void CreatWalls(Transform Template, IEnumerable<Vector3Int> Positions, float Angle)
    {
        foreach (var position in Positions)
        {
            CreateWall(Template, position, Angle);
        }
    }

    private void CreateWall(Transform template, Vector3Int position, float angle)
    {
        var wall = Instantiate(template, position, Quaternion.identity, transform);
        wall.rotation = Quaternion.Euler(0f, angle, 0f);
        _dungeonObjectsList.Add(wall);
    }

    private float GetAngleOfDirection(Vector3Int direction)
    {
        if (direction == Vector3Int.back)
            return 180;

        if (direction == Vector3Int.left)
            return -90;

        if (direction == Vector3Int.right)
            return 90;

        return 0;
    }
}
