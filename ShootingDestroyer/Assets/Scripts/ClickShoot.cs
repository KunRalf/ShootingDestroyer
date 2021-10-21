using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickShoot : MonoBehaviour
{
    public Vector3 ClickPoint()
    {
        RaycastHit hit;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit);
        return hit.point;
    }
}
