using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SnowBallSizeChanger : MonoBehaviour
{
    [SerializeField] private Transform _anchorPont;
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _sizeValueText;

    private void Start()
    {
        _slider.value = transform.localScale.x;
        ShowSizeText(_slider.value);
    }

    public void SetSize(float value)
    {
        transform.localScale = new Vector3(value, value, value);
        ShowSizeText(value);
    }

    private void ShowSizeText(float value)
    {
        _sizeValueText.text = _slider.value.ToString("0.0");
    }
}

