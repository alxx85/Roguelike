using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SimpleRandomParameters_", menuName ="PCG/SimpleRandomData", order = 51)]
public class SimpleRandomSO : ScriptableObject
{
    public int Iterations = 10;
    public int WalkLenght = 10;
    public bool StartRandomlyEachIteration = true;
}
