using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TileScript : MonoBehaviour
{
    [SerializeField] protected MeshRenderer _renderer;
    [SerializeField] private bool _isPlaceable;

    public virtual void Init(int x, int y) 
    {
        
    }
}
