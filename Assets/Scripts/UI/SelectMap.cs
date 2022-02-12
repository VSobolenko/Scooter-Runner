using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    public void LoadDesertScene()
    {
        SceneManager.LoadSceneAsync("1_Desert");
    }

    public void LoadForestScene()
    {
        SceneManager.LoadSceneAsync("3_Forest");
    }

    public void LoadVillageScene()
    {
        SceneManager.LoadSceneAsync("2_Village");
    }

    public void LoadCityScene()
    {
        SceneManager.LoadSceneAsync("4_City");
    }
}
