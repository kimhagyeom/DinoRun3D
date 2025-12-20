using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raptor : MonoBehaviour
{
    private bool isTarget;
    void Start()
    {

    }
    public void SetTarget()
    {
        isTarget = true;
    }
    public bool IsTarget()
    {
        return isTarget;
    }
}
