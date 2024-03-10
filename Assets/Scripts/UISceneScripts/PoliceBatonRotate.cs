using UnityEngine;

public class PoliceBatonRotate : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed;
    private void Update()
    {
        transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
    }
}
