using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFollowMouse : MonoBehaviour
{
    private PlaceObjectOnGrid placeObjectOnGrid;
    public bool isOnGrid;

    void Start()
    {
        placeObjectOnGrid = FindObjectOfType<PlaceObjectOnGrid>();
    }

    void Update()
    {
        if (!isOnGrid)
        {
            transform.position = placeObjectOnGrid.smoothMousePosition + new Vector3(0, 0.5f, 0);
        }

    }
}
