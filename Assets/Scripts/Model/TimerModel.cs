using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerModel : MonoBehaviour
{
    [SerializeField] private int _maxSeconds = 90;
    [SerializeField] private TextMeshProUGUI _loseText;
    private WaitForSeconds _waiting = new WaitForSeconds(2);

    private int _seconds;
    private float _time;

    public event Action<float> TimeChanged;
    private void Start()
    {
        _loseText.gameObject.SetActive(false);
        _seconds = _maxSeconds;
    }

    private void Update()
    {
        if(Time.time > _time)
        {
            ChangeTime(-1);
            _time = Time.time + 1;
        }
    }
    
    public void ChangeTime(int value)
    {
        _seconds += value;
        switch (_seconds)
        {
            case <= -1:
                StartCoroutine(Lose());
                break;
            default:
                float _timeAsPercentage = (float)_seconds / _maxSeconds;
                TimeChanged?.Invoke(_timeAsPercentage);
                break;
        }
    }

    IEnumerator Lose()
    {
        _loseText.gameObject.SetActive(true);
        yield return _waiting;
        SceneManager.LoadScene("MainMenu");
    }
}
