using UnityEngine;
using UnityEngine.UI;

public class TimerBar : MonoBehaviour
{
    [SerializeField] private Image _timeBarFilling;
    [SerializeField] private TimerModel _timer;

    private void Awake()
    {
        _timer.TimeChanged += OnTimeChanged;
    }

    private void OnDestroy()
    {
        _timer.TimeChanged -= OnTimeChanged;
    }

    private void OnTimeChanged(float valueAsPercentage)
    {
        _timeBarFilling.fillAmount = valueAsPercentage;
    }
}
