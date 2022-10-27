using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTile : TileScript
{
    [SerializeField] private Color _baseColor, _offsetColor;
    [SerializeField] private GameObject _highlight;

    public override void Init(int x, int y) 
    {
        var isOffset = (x + y) % 2 == 1;
        _renderer.material.color = isOffset ? _offsetColor : _baseColor;
    }
 
    void OnMouseEnter() 
    {
        _highlight.SetActive(true);
    }
 
    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
}
