using UnityEngine;
using System.Collections;

public class CamTilt : MonoBehaviour
{
    public float _tiltAmount = 5;
    public KeyCode _leftBtn = KeyCode.A;
    public KeyCode _rightBtn = KeyCode.D;
    public float _rotationSpeed = 1;
    private Quaternion _initialRotation;
    private Quaternion _targetRotation;

    void Start()
    {
        _initialRotation = _targetRotation = transform.rotation;
    }

    void Update()
    {

        if (Input.GetKeyDown(_leftBtn))
        {
            _targetRotation = Quaternion.Euler(0, 0, _tiltAmount) * _initialRotation;
        }
        else if (Input.GetKeyUp(_leftBtn))
        {
            _targetRotation = _initialRotation;
        }

        if (Input.GetKeyDown(_rightBtn))
        {
            _targetRotation = Quaternion.Euler(0, 0, -_tiltAmount) * _initialRotation;
        }
        else if (Input.GetKeyUp(_rightBtn))
        {
            _targetRotation = _initialRotation;
        }
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, _targetRotation, _rotationSpeed * Time.deltaTime);
    }
}