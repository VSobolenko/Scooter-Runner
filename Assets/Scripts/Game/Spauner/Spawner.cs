using System;
using UnityEngine;

/// <summary>
/// Скрипт, который "спавнит" наши барикады
/// </summary>

public class SpawnerSettings : MonoBehaviour
{
    //Скорость объекта
    [NonSerialized] public static float speed;

    //Шаг увелечения скорости
    [NonSerialized] public static float stepForSpeed;

    //Позиция спавна 
    [NonSerialized] public static Vector3 startSpawn;
}
