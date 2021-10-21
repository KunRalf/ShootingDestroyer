using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    private Rigidbody _rgb;
    private ClickShoot _clickShoot;
    private float _force = 600f;
    private Vector3 _moveTo;
    private bool _isCollision = false;

    private void Awake()
    {
        _clickShoot = FindObjectOfType<ClickShoot>();
    }

    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
        _moveTo = _clickShoot.ClickPoint();
        _rgb.AddForce(0, 0, _force);
        
    }

    private void FixedUpdate()
    {
        if(!_isCollision)
            transform.position = Vector3.MoveTowards(transform.position, _moveTo, 1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Box box = collision.gameObject.GetComponent<Box>();
        if (box != null)
        {
            _isCollision = true;
            StartCoroutine(DelayDestroy());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
