using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private const string Horizontal = "Horizontal";
    private const string Vertical = "Vertical";
    private const string MouseX = "Mouse X";
    private const string MouseY = "Mouse Y";

    [SerializeField] private float _mouseSensetivity = 8f;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxisRaw(Horizontal);
        float vertical = Input.GetAxisRaw(Vertical);

        float mouseX = Input.GetAxis(MouseX);
        float mouseY = Input.GetAxis(MouseY);
        bool isShoot = Input.GetMouseButton(0);

        _player.SetInput(horizontal, vertical, mouseX * _mouseSensetivity);
        _player.BarrelRotateX(-mouseY * _mouseSensetivity);

        if (isShoot) _player.Shoot();
    }
}