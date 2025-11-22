using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public Vector3 mapsize;

    public float GetMapSize()
    {
        return mapsize.z;
    }
}
