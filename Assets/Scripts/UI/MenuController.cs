using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт, который контролирует главное меню 
/// </summary>

public class MenuController : MonoBehaviour, IMenuController
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _information;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject _cherep;
    [SerializeField] private GameObject _bestScore;
    [SerializeField] private GameObject _scoreSkull;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("SelectMap");
    }

    public void ShowMenu()
    {
        _mainMenu.SetActive(true);
        _cherep.SetActive(true);
        _bestScore.SetActive(true);

        _information.SetActive(false);
        _settings.SetActive(false);
        _exit.SetActive(false);
    }

    public void ShowSettings()
    {
        _settings.SetActive(true);

        _bestScore.SetActive(false);
        _cherep.SetActive(false);
        _exit.SetActive(false);
        _information.SetActive(false);
        _mainMenu.SetActive(false);
    }

    public void ShowInformation()
    {
        _information.SetActive(true);

        _bestScore.SetActive(false);
        _cherep.SetActive(false);
        _mainMenu.SetActive(false);
        _settings.SetActive(false);
        _exit.SetActive(false);
    }

    public void ShowQuitGame()
    {
        _exit.SetActive(true);

        _bestScore.SetActive(false);
        _cherep.SetActive(false);
        _information.SetActive(false);
        _mainMenu.SetActive(false);
        _settings.SetActive(false);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

    private void Start()
    {
        _bestScore.GetComponent<TextMeshProUGUI>().text = "Best score:\n" + PlayerPrefs.GetFloat("Record");
        _scoreSkull.GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt("Skull").ToString();
    }
}
