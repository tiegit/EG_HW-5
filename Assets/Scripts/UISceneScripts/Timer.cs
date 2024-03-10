using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private int _minutes = 5;
    [SerializeField] private int _seconds = 60;

    private int _delta = 1;
    private int _currentSeconds;
    private int _currentMinutes;

    private void Start()
    {
        _currentMinutes = _minutes;
        _currentSeconds = _seconds;
        SetTime(_currentMinutes, _currentSeconds);

        _timerText.color = new Color(0.3803922f, 0.7333333f, 0.9372549f);

        StartCoroutine(TimerCourutine());
    }

    private IEnumerator TimerCourutine()
    {
        while (true)
        {
            if (_currentSeconds == 0)
            { 
                _currentMinutes--;
                _currentSeconds = _seconds;
            }

            _currentSeconds -= _delta;

            SetTime(_currentMinutes, _currentSeconds);

            yield return new WaitForSeconds(1);
        }
    }

    private void SetTime(int minutes, int seconds) 
    {
        _timerText.text = minutes.ToString("D2") + ":" + seconds.ToString("D2"); 
    }
}
