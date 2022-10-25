using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlighting : MonoBehaviour
{
        private Color startcolor;
        void OnMouseEnter()
        {
            startcolor = GetComponent<Renderer>().material.color;
            GetComponent<Renderer>().material.color
    = Color.green;
        }
        void OnMouseExit()
        {
            GetComponent<Renderer>().material.color
    = startcolor;
        }
}
