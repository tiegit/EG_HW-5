using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField] private Transform _cameraTransform;

    private void Update()
    {
        Vector3 toCamera = _cameraTransform.position - transform.position;

        transform.rotation = Quaternion.LookRotation(toCamera);
    }
}
