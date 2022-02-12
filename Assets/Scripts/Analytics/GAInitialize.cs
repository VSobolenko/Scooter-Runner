using GameAnalyticsSDK;
using UnityEngine;

public class GAInitialize : MonoBehaviour
{
    private void Start()
    {
        GameAnalytics.Initialize();
    }
}