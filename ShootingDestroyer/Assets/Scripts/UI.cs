using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _rearSight;
    [SerializeField] private GameObject _button;
    [SerializeField] private BoxController _boxController;
    [SerializeField] private Text _text;
    private bool _isClickButton = false;
    private Gun _gun;

    private void Start()
    {
        _gun = FindObjectOfType<Gun>();
    }

    private void Update()
    {
        if (_boxController.IsReadyToShoot())
        {
            _isClickButton = false;
            _text.gameObject.SetActive(true);
        }
        else
        {
            _text.gameObject.SetActive(false);
        }

        if (!_boxController.IsReadyToShoot() && _boxController.IsRestingState() && !_isClickButton)
        {
            _button.SetActive(true);
        }
        else
        {
            _button.SetActive(false);
        }
    }

    public void TurnOffButton()
    {
        _isClickButton = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_boxController.IsReadyToShoot())
        {
            _rearSight.gameObject.SetActive(true);
            _rearSight.transform.position = eventData.position;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_boxController.IsReadyToShoot())
        {
            _rearSight.gameObject.SetActive(true);
            _rearSight.transform.position = eventData.position;
        }

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_boxController.IsReadyToShoot())
        {
            _gun.Shoot();
        }
        _rearSight.gameObject.SetActive(false);
    }
}
