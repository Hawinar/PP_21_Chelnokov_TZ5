using TMPro;
using UnityEngine;

public class PlayerViewModel : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreTMP;
    [SerializeField] private TextMeshProUGUI _scoreTMP;

    [SerializeField] private PlayerModel _player;
    private int _bestScore;

    private void Awake()
    {
        _player.ScoreChanged += OnScoreChanged;
    }

    private void OnDestroy()
    {
        _player.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int value)
    {
        _scoreTMP.text = value.ToString();
        _bestScore = PlayerPrefs.GetInt("BestScore");
        if (value > _bestScore)
        {
            _bestScore = value;
            PlayerPrefs.SetInt("BestScore", value);
        }
        _bestScoreTMP.text = _bestScore.ToString();
        
    }
}
