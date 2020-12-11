using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    public void clearWalls()
    {
        var walls = GameObject.FindGameObjectsWithTag("wall");
        foreach (var wall in walls)
        {
            Destroy(wall);
        }
    }
}
