using GameAnalyticsSDK;
using UnityEngine;

namespace Analytics
{
    public static class AnalyticsController
    {
        public static void StartLevel(string levelName, int countMoney)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Start, "Level: " + levelName, "Start with money: " + countMoney);
            Debug.Log($"<color=#52A4BA>[analytics]</color>Start: {levelName}; Money: {countMoney}");
        }

        public static void FinishLevel(string levelName, float score, int countMoney)
        {
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level: " + levelName, "End with money: " + countMoney, "Score: " + score);   
            Debug.Log($"<color=#52A4BA>[analytics]</color>Finish: {levelName}, Score: {score}; Money: {countMoney}");
        }

        public static void ByNewLevel(string levelName, int price,  int countMoneyAfterBy)
        {
            GameAnalytics.NewDesignEvent($"By level: {levelName}; Price: {price}; Money after by: {countMoneyAfterBy}");
            Debug.Log($"<color=#52A4BA>[analytics]</color>By level: {levelName}; Price: {price}; Money after by: {countMoneyAfterBy}");
        }

        public static void OpenDiscord()
        {
            GameAnalytics.NewDesignEvent($"Open discord");
            Debug.Log($"<color=#52A4BA>[analytics]</color>Open discord");
        }
    }
}
