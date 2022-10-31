using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [SerializeField] private int _width, _height;

    //A variable to decide how large the grid will be, width being it's with and height being it's height.
 
    [SerializeField] private TileScript _towerTile, _enemyTile;
 
    private Dictionary<Vector2, TileScript> _tiles;
 
    void Awake() 
    {
        GenerateGrid();
    }
 
    void GenerateGrid() 
    {
        _tiles = new Dictionary<Vector2, TileScript>();
        for (int x = 0; x < _width; x++) 
        {
            for (int y = 0; y < _height; y++) 
            {
                var walkingLine = Instantiate(_enemyTile, new Vector3(x, 0, 7), Quaternion.identity);
                var spawnedTile = Instantiate(_towerTile, new Vector3(x, 0, y), Quaternion.identity);
                walkingLine.name = $"Walking Line Part {x}, {y}";
                spawnedTile.name = $"Tile {x} {y}";

                spawnedTile.Init(x,y);
 
 
                _tiles[new Vector2(x, y)] = spawnedTile;
            }
        }
    }
    void Update ()
    {
        
    }
 
    public TileScript GetTileAtPosition(Vector2 pos) 
    {
        if (_tiles.TryGetValue(pos, out var tile)) return tile;
        return null;
    }
}
