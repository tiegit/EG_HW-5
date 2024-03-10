using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 45f;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private float _time = 0.25f;

    private Rigidbody _rigidbody;
    private float _horizontalInput;
    private float _verticalInput;
    private float _mouseX;
    private bool _isJumping;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw(Horizontal);
        _verticalInput = Input.GetAxisRaw(Vertical);
        _mouseX = Input.GetAxis(MouseX);

        Jump();
        Rotate();
        SurfaceAlignment();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void SurfaceAlignment()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit info = new RaycastHit();
        Quaternion currentRotation = Quaternion.Euler(0, 0, 0);

        if (Physics.Raycast(ray, out info, _ground))
        {
            currentRotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(Vector3.up, info.normal), _animationCurve.Evaluate(_time));
            transform.rotation = Quaternion.Euler(currentRotation.eulerAngles.x, transform.eulerAngles.y, currentRotation.eulerAngles.z);
        }
    }

    private void Move()
    {
        if ((_verticalInput != 0 || _horizontalInput != 0) && !_isJumping)
        {
            Vector3 movement = (transform.forward * _verticalInput + transform.right * _horizontalInput).normalized * _moveSpeed;

            //_rigidbody.velocity = Vector3.Slerp(_rigidbody.velocity, movement, _time);

            _rigidbody.velocity = movement;
        }
    }

    private void Rotate()
    {
        transform.Rotate(0, _mouseX * _rotationSpeed * Time.deltaTime, 0);
    }


    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

        if (Physics.Raycast(transform.position + transform.up * 0.1f, -transform.up, 0.2f))
        {
            _isJumping = false;
        }
        else
        {
            _isJumping = true;
        }
    }
}
