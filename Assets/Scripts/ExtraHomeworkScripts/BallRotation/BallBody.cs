using UnityEngine;

internal class BallBody : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _ballRotationPoint;
    private float _ballRadius;

    private void Start()
    {
        _ballRadius = transform.localScale.x / 2;
    }

    private void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(_ball.Velocity.z / _ballRadius, 0, -_ball.Velocity.x / _ballRadius);

        transform.rotation *= targetRotation;

        //Debug.Log(transform.localEulerAngles);
    }
}