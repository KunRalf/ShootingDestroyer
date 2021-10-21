using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    [SerializeField] private List<Box> _boxes;
    private bool _isRestingState;
    private bool _isReadyToShoot;
    private int _count = 0;

    private void Update()
    {
        IsRestingState();
    }

    public int BoxesCount()
    {
        return _boxes.Count;
    }

    public void AddToBoxes(Box box)
    {
        _boxes.Add(box);
    }

    public bool IsRestingState()
    {
        for (int i = 0; i < _boxes.Count; i++)
        {
            if (_boxes[i].RgbVelocity() == Vector3.zero)
            {
                _isRestingState = true;
            }
            else
            {
                _isRestingState = false;
            }
        }
        return _isRestingState;
    }

    public bool IsReadyToShoot()
    {
        for (int i = 0; i < _boxes.Count; i++)
        {
            if (_boxes[i].IsReadyToShoot)
            {
                _count++;
            }
        }
        if (_count >= BoxesCount())
        {
            _isReadyToShoot = true;
            _count = 0;
        }
        else
        {
            _isReadyToShoot = false;
            _count = 0;
        }
 
        return _isReadyToShoot;
    }
}
