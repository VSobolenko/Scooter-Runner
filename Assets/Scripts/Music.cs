using UnityEngine;

public class Music : MonoBehaviour
{
    public UnityEngine.UI.Toggle toggleOption;
    private int _var = 1;

    private void Start()
    {
        _var = PlayerPrefs.GetInt("Music", 1);
        if (_var == 1)
            toggleOption.isOn = true;
        else
            toggleOption.isOn = false;
        AudioListener.volume = _var;
    }

    public void MusicChanged(bool temp)
    {
        toggleOption.isOn = temp;
        if (temp)
            _var = 1;
        else
            _var = 0;
        AudioListener.volume = _var;
        PlayerPrefs.SetInt("Music", _var);
    }
}
