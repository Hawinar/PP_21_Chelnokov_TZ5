using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScoreTMP;
    private void Start()
    {
        _bestScoreTMP.text = PlayerPrefs.GetInt("BestScore").ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
