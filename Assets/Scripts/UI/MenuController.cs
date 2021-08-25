using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Скрипт, который контролирует главное меню 
/// </summary>

public class MenuController : MonoBehaviour, IMenuController
{
    // Кнопки меню
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _settings;
    [SerializeField] private GameObject _information;
    [SerializeField] private GameObject _exit;
    [SerializeField] private GameObject _cherep;
    [SerializeField] private GameObject _bestScore;
    [SerializeField] private GameObject _scoreSkull;

    //Метод запуска игры (сейчас это index +1)
    public void PlayGame()
    {
        Debug.Log("Star game");
        SceneManager.LoadScene("SelectMap");
    }

    //Метод показа главного меню (вот прям самое главное)
    public void ShowMenu()
    {
        _mainMenu.SetActive(true);
        _cherep.SetActive(true);
        _bestScore.SetActive(true);

        _information.SetActive(false);
        _settings.SetActive(false);
        _exit.SetActive(false);
    }

    //Метод показа меню настроек
    public void ShowSettings()
    {
        _settings.SetActive(true);

        _bestScore.SetActive(false);
        _cherep.SetActive(false);
        _exit.SetActive(false);
        _information.SetActive(false);
        _mainMenu.SetActive(false);
    }

    //Метод показа меню информации
    public void ShowInformation()
    {
        _information.SetActive(true);

        _bestScore.SetActive(false);
        _cherep.SetActive(false);
        _mainMenu.SetActive(false);
        _settings.SetActive(false);
        _exit.SetActive(false);
    }

    //Перед выходом, может,  игрок и передумает ещё...
    public void ShowQuitGame()
    {
        _exit.SetActive(true);

        _bestScore.SetActive(false);
        _cherep.SetActive(false);
        _information.SetActive(false);
        _mainMenu.SetActive(false);
        _settings.SetActive(false);
    }

    //Ну и пускай уходит, я не очень расстроился
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
