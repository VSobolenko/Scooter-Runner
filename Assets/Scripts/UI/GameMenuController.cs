using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт, который контролирует всё, что свзяано с canvas в игре
/// </summary>
public class GameMenuController : MonoBehaviour, IGameMenuController
{
    //Основные панели - кнопки в игре
    [SerializeField] private TextMeshProUGUI _scoreGame;
    [SerializeField] private TextMeshProUGUI _scoreSkull;
    [SerializeField] private TextMeshProUGUI _scorePause;
    [SerializeField] private TextMeshProUGUI _scoreRestart;
    [SerializeField] private TextMeshProUGUI _maxScorePause;
    [SerializeField] private TextMeshProUGUI _maxScoreRestart;
    //[SerializeField] private TextMeshProUGUI _textMaxScoreOrCrashed;
    [SerializeField] private GameObject _bottonPause;
    [SerializeField] private GameObject _bottonGoToMenu;
    [SerializeField] private GameObject _bottonResumeGame;
    [SerializeField] private GameObject _panelPauseMenu;
    [SerializeField] private GameObject _panelRestartGame;

    [NonSerialized] public static float maxScore;
    [NonSerialized] public static int skullCount;

    private string _nowScore;
    private int _nowSkull;

    private Color _colorForStop = new Color(0, 0, 0, 0);
    private Color _coloForPlay = new Color(0, 0, 0, 1);

    private Player player;

    //private float _prevMaxScore;
    private void Awake()
    {
        //PlayerPrefs.SetFloat("Record", 0);
        maxScore = PlayerPrefs.GetFloat("Record", 0);
        //_prevMaxScore = PlayerPrefs.GetFloat("Record", 0);
        skullCount = PlayerPrefs.GetInt("Skull", 0);

        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    ~GameMenuController()
    {
        PlayerPrefs.SetFloat("Record", maxScore);
        PlayerPrefs.SetInt("Skull", skullCount);
    }

    public void ShowMenuPause()
    {
        Time.timeScale = 0f;
        _bottonPause.SetActive(false);
        _panelPauseMenu.SetActive(true);
        _scoreGame.color = _colorForStop;
        _scoreSkull.color = _colorForStop;
        _scorePause.text = "Score: " + _nowScore;
        _maxScorePause.text = "Best score = " + PlayerPrefs.GetFloat("Record");
    }

    public void ShowRestartGameMenu()
    {
        //var ter = PlayerPrefs.GetFloat("Record", 0);
        //if (player.timer >= _prevMaxScore)
        //{
        //    maxScore = player.timer;
        //    PlayerPrefs.SetFloat("Record", maxScore);
        //    _textMaxScoreOrCrashed.text = "New Record !";
        //}
        //else
        //{
        //    _textMaxScoreOrCrashed.text = "You crashed :(";
        //}

        Time.timeScale = 0f;
        _bottonPause.SetActive(false);
        _panelRestartGame.SetActive(true);
        _scoreGame.color = _colorForStop;
        _scoreSkull.color = _colorForStop;
        _scoreRestart.text = "Score: " + _nowScore;
        _maxScoreRestart.text = "Best score = " + PlayerPrefs.GetFloat("Record");

    }

    //Тот самый метод, который показывает меню когда игрок проиграл, а не нажал на паузу
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _scoreGame.color = _coloForPlay;
        _scoreSkull.color = _coloForPlay;
        _bottonPause.SetActive(true);
        _panelPauseMenu.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //Его вызывает игрок обиделся и решил пойти в меню
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    private void Update()
    {
        _nowScore = player.timer.ToString();
        _scoreGame.text = _nowScore;
        if (player.timer > maxScore)
        {
            maxScore = player.timer;
            PlayerPrefs.SetFloat("Record", maxScore);
        }

        _nowSkull = player.skull;
        _scoreSkull.text = _nowSkull.ToString();
        if (player.skull > skullCount)
        {
            skullCount = player.skull;
            PlayerPrefs.SetInt("Skull", skullCount);
        }
    }
}
