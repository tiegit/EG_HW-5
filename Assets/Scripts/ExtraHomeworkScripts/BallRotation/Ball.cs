using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";

    [SerializeField] private BallBody _ballBody;
    [SerializeField] private float _speed = 10f;

    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody _rigidbody;
    private Vector3 _velocity;

    public Vector3 Velocity => _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _horizontalInput = Input.GetAxisRaw(Horizontal);
        _verticalInput = Input.GetAxisRaw(Vertical);

        Move();
    }

    private void Move()
    {
        Vector3 velocity = (transform.forward * _verticalInput + transform.right * _horizontalInput).normalized * _speed;
        velocity.y = _rigidbody.velocity.y;
        _velocity = velocity;

        _rigidbody.velocity = _velocity;
    }
}
