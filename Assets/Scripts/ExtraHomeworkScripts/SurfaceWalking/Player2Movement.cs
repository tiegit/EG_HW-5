using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player2Movement : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _rotationSpeed = 45f;
    [SerializeField] private float _jumpForce = 20f;
    [SerializeField] private AnimationCurve _animationCurve;
    //[SerializeField] private float _time = 0.5f;

    [SerializeField] Transform _planet;
    [SerializeField] private float _gravity = 10f;

    private Rigidbody _rigidbody;
    private float _horizontalInput;
    private float _verticalInput;
    private float _mouseX;
    private bool _isJumping;
    private Vector3 _gravityDirection;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw(Horizontal);
        _verticalInput = Input.GetAxisRaw(Vertical);
        _mouseX = Input.GetAxis(MouseX);

        Rotate();
        Jump();
        GroundSet();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void GroundSet()
    {
        _gravityDirection = (_planet.position - transform.position).normalized;
        _rigidbody.AddForce(_gravityDirection * _gravity, ForceMode.Force);
    }

    private void Move()
    {
        if ((_verticalInput != 0 || _horizontalInput != 0) && !_isJumping)
        {
            Vector3 movement = (transform.forward * _verticalInput + transform.right * _horizontalInput).normalized * _moveSpeed;

            //_rigidbody.velocity = Vector3.Slerp(_rigidbody.velocity, movement, _time);

            _rigidbody.velocity = movement;
        }

        CorrectRotation();
    }

    private void CorrectRotation()
    {
        Vector3 newVerticalMove = Vector3.Cross(transform.right, -_gravityDirection);
        _rigidbody.rotation = Quaternion.LookRotation(newVerticalMove, -_gravityDirection);
    }

    private void Rotate()
    {
        transform.Rotate(0, _mouseX * _rotationSpeed *Time.deltaTime, 0);        
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_isJumping)
        {
            _rigidbody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

        if (Physics.Raycast(transform.position +  transform.up * 0.1f, -transform.up, 0.2f))
        {
            _isJumping = false;
        }
        else
        {
            _isJumping = true;
        }
    }
}
