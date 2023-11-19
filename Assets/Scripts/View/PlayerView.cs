using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private List<Sprite> _images;
    [SerializeField] private Image _soundBtnImage;
    private void Start()
    {
        Time.timeScale = 1.0f;
        _pauseUI.SetActive(false);
    }


    public void Pause()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            _pauseUI.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            _pauseUI.SetActive(false);
        }
           
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Sound()
    {
        if(_soundBtnImage.sprite == _images[0])
            _soundBtnImage.sprite = _images[1];
        else
            _soundBtnImage.sprite = _images[0];
    }
}
