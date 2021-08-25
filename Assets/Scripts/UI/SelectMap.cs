using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    public void LoadDesertScene()
    {
        Debug.Log("Load Scene DESERT");
        SceneManager.LoadScene("1_Desert");
    }

    public void LoadForestScene()
    {
        Debug.Log("Load Scene FOREST");
        SceneManager.LoadScene("3_Forest");
    }

    public void LoadVillageScene()
    {
        Debug.Log("Load Scene FOREST");
        SceneManager.LoadScene("2_Village");
    }

    public void LoadCityScene()
    {
        Debug.Log("Load Scene FOREST");
        SceneManager.LoadScene("4_City");
    }
}
