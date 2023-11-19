using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    private int _score;
    public event Action<int> ScoreChanged;

    private float _time;

    private void Start()
    {
        _score = 0;
        ChangeScore(0);
    }

    private void Update()
    {
        //if (Time.time > _time)
        //{
        //    Debug.Log(_time);
        //    ChangeScore(1);
        //    _time = Time.time + 1;
        //}

    }

    public void ChangeScore(int value)
    {
        _score += value;

        ScoreChanged?.Invoke(_score);
    }
}
