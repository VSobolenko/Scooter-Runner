using System.Collections.Generic;
using GameAnalyticsSDK;
using UnityEngine;

namespace Analytics
{
    public static class AnalyticsController
    {
        public static void StartLevel(string levelName, int countMoney)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, $"Level {levelName}", countMoney);
            
            Debug.Log($"<color=#52A4BA>[analytics]</color>Start: {levelName}; Money: {countMoney}");
        }

        public static void FinishLevel(string levelName, int score, int countMoney)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, $"Level {levelName}", score);   
            Debug.Log($"<color=#52A4BA>[analytics]</color>Finish: {levelName}, Score: {score}; Money: {countMoney}");
        }

        public static void ByNewLevel(string levelName, int price,  int countMoneyAfterBy)
        {
            GameAnalytics.NewDesignEvent($"By level {levelName}", countMoneyAfterBy);
            Debug.Log($"<color=#52A4BA>[analytics]</color>By level: {levelName}; Price: {price}; Money after by: {countMoneyAfterBy}");
        }

        public static void OpenDiscord()
        {
            GameAnalytics.NewDesignEvent($"Open discord");
            Debug.Log($"<color=#52A4BA>[analytics]</color>Open discord");
        }
    }
}
