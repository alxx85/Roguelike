using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractDungeonGenerator : MonoBehaviour
{
    [SerializeField] protected Vector3Int startPosition = Vector3Int.zero;
    [SerializeField] protected DungeonVizualizer vizualizer;

    public void GenerateDungeon()
    {
        vizualizer.DeleteFloorObjects();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
}
