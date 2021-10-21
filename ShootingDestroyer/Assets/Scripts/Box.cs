using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private BoxCollider _boxCollider;
    private Rigidbody _rgb;
    private BoxController _boxController;
    private Vector3 _startPos;
    private Quaternion _startRot;
    private bool _isStartPos = false;
    private bool _isReadyToShoot = true;
    private float _timeToBuild = 4f;

    public bool IsReadyToShoot => _isReadyToShoot;

    private void Awake()
    {
        _boxController = FindObjectOfType<BoxController>();
        _boxController.AddToBoxes(this);
    }

    private void Start()
    {
        _rgb = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        _startPos = transform.position;
        _startRot = transform.rotation;
        EventService.Instance.OnStartPos += ToStartPosition;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Missile missile = collision.gameObject.GetComponent<Missile>();
        if (missile != null)
        {
            _isReadyToShoot = false;
        }
    }

    private void Update()
    {
        if (_isStartPos)
        {
            StartTransform();
        }
    }

    public void ToStartPosition()
    {
        _isStartPos = true;
        _rgb.useGravity = false;
        _boxCollider.enabled = false;
        StartCoroutine(TurnOnCollider());
    }

    private void StartTransform()
    {
        transform.position = Vector3.Lerp(transform.position, _startPos, _timeToBuild * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, _startRot, _timeToBuild * Time.deltaTime);
    }

    private IEnumerator TurnOnCollider()
    {
        yield return new WaitForSeconds(2.5f);
        _rgb.useGravity = true;
        _boxCollider.enabled = true;
        _isStartPos = false;
        _isReadyToShoot = true;
    }

    public Vector3 RgbVelocity()
    {
        return _rgb.velocity;
    }
}
