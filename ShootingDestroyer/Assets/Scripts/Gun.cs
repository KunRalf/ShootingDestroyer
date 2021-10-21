using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform _shotPoint;
    [SerializeField] private GameObject _missilePrefab;
    
    public void Shoot()
    {
        GameObject missile = Instantiate(_missilePrefab, _shotPoint.position, _shotPoint.rotation) as GameObject;
    }
}
