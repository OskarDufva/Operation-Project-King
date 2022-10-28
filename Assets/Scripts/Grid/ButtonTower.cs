using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTower : MonoBehaviour
{
    public GameObject _tower;
    public GameObject movingTower;

    void OnMouseDown()
    {
        Debug.Log("Clicked");
        Debug.Log(_tower);
        GameObject newObject = (GameObject)Instantiate(_tower, new Vector3(-1, 0, -1), Quaternion.identity);
        movingTower = newObject;
        Debug.Log(_tower);
        Debug.Log(newObject);
    }

    void Update()
    {
        Debug.Log("Update");
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);
        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            movingTower.transform.position = hit.point;
            Debug.Log(objectHit);

        }
    }
}
