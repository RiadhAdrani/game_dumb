using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Game : MonoBehaviour
{
    public static int Randomize(int min, int max)
    {
        return Random.Range(min, max+1);
    }
}
