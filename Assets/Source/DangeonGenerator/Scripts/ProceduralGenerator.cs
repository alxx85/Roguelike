using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralGenerator
{
    public static HashSet<Vector3Int> SimpleRandomWalk(Vector3Int startPosition, int walkLength)
    {
        HashSet<Vector3Int> path = new HashSet<Vector3Int>();
        path.Add(startPosition);
        var previousPosition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousPosition + Direction3D.GetRandomDirection();
            path.Add(newPosition);
            previousPosition = newPosition;
        }
        return path;
    }
}

public static class Direction3D
{
    private static List<Vector3Int> DirectionList = new List<Vector3Int>
    {
        new Vector3Int(0, 0, 1), // forward
        new Vector3Int(0, 0, -1), // backward
        new Vector3Int(-1, 0, 0), // left
        new Vector3Int(1, 0, 0) // right
    };

    public static Vector3Int GetRandomDirection()
    {
        return DirectionList[Random.Range(0, DirectionList.Count)];
    }

    public static IEnumerable<Vector3Int> GetDirectionList()
    {
        return DirectionList;
    }
}