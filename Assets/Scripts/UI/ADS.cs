using Analytics;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour
{
    private void Start()
    {
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3822175", false);
        }
        else
        {
            Debug.Log("isSupported");
        }
    }

    public void GoADS()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
        else
        {
            Debug.Log("isReady");
        }
    }

    public void GoADS2()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo");
        }
        else
        {
            Debug.Log("isReady");

        }
    }

    public void OpenUrl(string url)
    {
        AnalyticsController.OpenDiscord();
        Application.OpenURL(url);
    }

    private void Update()
    {
        if (Player.temping >= 6)
        {
            GoADS2();
            Player.temping = 0;
        }
    }
}
