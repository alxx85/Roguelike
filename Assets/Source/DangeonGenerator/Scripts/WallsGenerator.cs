using System.Collections.Generic;
using UnityEngine;

public static class WallsGenerator
{
    public static IEnumerable<Vector3Int> GetWallsPositions(HashSet<Vector3Int> floorPosition, Vector3Int direction)//, DungeonVizualizer dungeonVizualizer)
    {
        HashSet<Vector3Int> DirectionWallsPosition = new HashSet<Vector3Int>();
        DirectionWallsPosition = FindWallsInDirection(floorPosition, direction);
        return DirectionWallsPosition;
    }

    private static HashSet<Vector3Int> FindWallsInDirection(HashSet<Vector3Int> floorPosition, Vector3Int direction)
    {
        HashSet<Vector3Int> wallsPosition = new HashSet<Vector3Int>();

        foreach (Vector3Int floor in floorPosition) 
        { 
            var neighbourPosition = floor + direction;

            if (floorPosition.Contains(neighbourPosition) == false)
                wallsPosition.Add(floor);
        }

        return wallsPosition;
    }
}
