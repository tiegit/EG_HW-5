using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _snowmanNameText;

    [SerializeField] private float _force =100f;
    [SerializeField] private TextMeshProUGUI _massText;

    [SerializeField] private List<Renderer> _snowmanRenderers = new List<Renderer>();

    private float _result;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ShowMassText(_rigidbody.mass);
    }

    public void SetName(string name)
    {
        _snowmanNameText.text = name;
    }

    public void Jump()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * _force, ForceMode.Impulse);
    }

    public void ChangeMass(float delta)
    {
        _result = _rigidbody.mass + delta;

        _result = Mathf.Clamp(_result, 10f, 100f);

        _rigidbody.mass = _result;

        ShowMassText(_result);
    }

    public void SetMaterial(Material material)
    {
        for (int i = 0; i < _snowmanRenderers.Count; i++)
        {
            _snowmanRenderers[i].material = material;
        }
    }

    private void ShowMassText(float value)
    {
        _massText.text = value.ToString("0");
    }
}
