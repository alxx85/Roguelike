using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimpleRandomGenetation : AbstractDungeonGenerator
{
    [SerializeField] private SimpleRandomSO _randomGeneratorParameters;

    private void Start()
    {
        RunProceduralGeneration();
    }

    protected override void RunProceduralGeneration()
    {
        HashSet<Vector3Int> floorPosition = RunRandomWalk();
        vizualizer.CreateFloorObjects(floorPosition);
    }

    private HashSet<Vector3Int> RunRandomWalk()
    {
        var currentPosition = startPosition;
        HashSet<Vector3Int> floorPosition = new HashSet<Vector3Int>();

        for (int i = 0; i < _randomGeneratorParameters.Iterations; i++)
        {
            var path = ProceduralGenerator.SimpleRandomWalk(currentPosition, _randomGeneratorParameters.WalkLenght);
            floorPosition.UnionWith(path);

            if (_randomGeneratorParameters.StartRandomlyEachIteration)
            {
                currentPosition = floorPosition.ElementAt(UnityEngine.Random.Range(0, floorPosition.Count));
            }
        }

        return floorPosition;
    }

}
