using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waypoints : MonoBehaviour
{
    // Whenever we need gameobjects to be referenced use transform
    public static Transform[] waypointList;

    private void Awake()
    {
        waypointList = new Transform[transform.childCount];

        for (int i = 0; i < waypointList.Length; i++)
        {
            // iterate through every child of the points
            waypointList[i] = transform.GetChild(i);
        }
    }
}
