using UnityEngine;

public class TowerBarrel : MonoBehaviour
{
    [SerializeField] private Transform _targetAnchorPoint;

    private void Update()
    {
        transform.position = _targetAnchorPoint.position;

        transform.rotation = _targetAnchorPoint.rotation;
    }
}
