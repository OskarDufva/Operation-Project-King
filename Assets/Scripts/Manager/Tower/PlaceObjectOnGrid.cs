using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectOnGrid : MonoBehaviour
{
    public Transform gridCellPrefab;
    public Transform cube;
    public Transform onMousePrefab;

    public Vector3 smoothMousePosition;
    [SerializeField] private int height;
    [SerializeField] int width;

    Vector3 mousePosition;
    private Node[,] nodes;
    private Plane Plane;



    void Start()
    {
        CreateGrid();
        Plane = new Plane(Vector3.up, transform.position);
    }

    void Update()
    {
        GetMousePositionOnGrid();
    }

    void GetMousePositionOnGrid()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Plane.Raycast(ray, out var enter))
        {
            mousePosition = ray.GetPoint(enter);
            smoothMousePosition = mousePosition;
            mousePosition.y = 0;
            mousePosition = Vector3Int.RoundToInt(mousePosition);
            foreach (var node in nodes)
            {
                if (node.cellPosition == mousePosition && node.isPlaceable)
                {
                    if (Input.GetMouseButtonDown(0) && onMousePrefab != null)
                    {
                        node.isPlaceable = false;
                        onMousePrefab.GetComponent<ObjFollowMouse>().isOnGrid = true;
                        onMousePrefab.position = node.cellPosition + new Vector3(0, 0.5f, 0);
                        onMousePrefab = null;
                    }
                }
            }
        }

    }

    public void OnMouseClickOnUi()
    {
        if (onMousePrefab == null)
        {
            onMousePrefab = Instantiate(cube, mousePosition, Quaternion.identity);
        }
    }


    private void CreateGrid()
    {
        nodes = new Node[width, height];
        var name = 0;
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector3 worldPosition = new Vector3(x:i, y:0, z:j);
                Transform obj = Instantiate(gridCellPrefab, worldPosition, Quaternion.identity);
                obj.name = "Cell" + name;
                nodes[i,j] = new Node(isPlaceable: true, worldPosition, obj);
                name++;
            }
        }

    }
}

public class Node
{
    public bool isPlaceable;
    public Vector3 cellPosition;
    public Transform obj;

    public Node(bool isPlaceable, Vector3 cellPosition, Transform obj)
    {
        this.isPlaceable = isPlaceable;
        this.cellPosition = cellPosition;
        this.obj = obj;
    }
}
