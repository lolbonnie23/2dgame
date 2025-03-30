using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameoverpanel;
    [SerializeField] private GameObject _winpanel;
    [SerializeField] private int _scoretoWin;
    [SerializeField] private TMP_Text _scoreText;

    public static Action playerAction;
    public static Action enemyAction;

    private int _score; 
    void Start()
    {
        Time.timeScale = 1;
        _gameoverpanel.SetActive(false);
        playerAction += ActivePanel;
        _winpanel.SetActive(false);
        enemyAction += Score;

    }



    private void Score()
    {
        _score++;
        _scoreText.text = _score.ToString();


        if (_score == _scoretoWin)
        {
            _winpanel.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void ActivePanel()
    {
        _gameoverpanel.SetActive(true);

    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
}
