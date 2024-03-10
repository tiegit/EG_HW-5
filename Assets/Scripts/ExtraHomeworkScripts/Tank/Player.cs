using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [SerializeField] private Transform _bulletSpawnPoint;
    [SerializeField] private Transform _towerRotationPoint;
    [SerializeField] private Transform _barrelRotationPoint;
    [SerializeField] private float _tankSpeed = 3f;
    [SerializeField] private float _tankRotationSpeed = 2f;
    [SerializeField] private float _maxBarrelAngle = 30f;
    [SerializeField] private float _minBarrelAngle = 10f;

    private Rigidbody _rigidbody;
    private float _horizontalInput, _verticalInput, _rotateY;
    private float _currentRotateX;

    public Vector3 Velocity => _rigidbody.velocity;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        TankMove();
        TankRotateY();
        TowerRotateY();
    }


    public void SetInput(float horizontalInput, float verticalInput, float rotateY)
    {
        _horizontalInput = horizontalInput;
        _verticalInput = verticalInput;
        _rotateY += rotateY;
    }

    public void Shoot()
    {
        Debug.Log("Ïטפ-ןאפ");
    }
    
    public void BarrelRotateX(float value)
    {
        _currentRotateX = Mathf.Clamp(_currentRotateX + value, _minBarrelAngle, _maxBarrelAngle);
        _barrelRotationPoint.localEulerAngles = new Vector3(_currentRotateX, 0, 0);
    }

    private void TowerRotateY()
    {
        _towerRotationPoint.Rotate(new Vector3(0, _rotateY, 0));
        _rotateY = 0;
    }

    private void TankMove()
    {
        Vector3 velocity = (transform.forward * _verticalInput).normalized * _tankSpeed;
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }
    
    private void TankRotateY()
    {
        Vector3 resultEuler = transform.eulerAngles + (transform.up * _horizontalInput * _tankRotationSpeed);
        _rigidbody.MoveRotation(Quaternion.Euler(resultEuler));
    }
}
