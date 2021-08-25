using UnityEngine;

/// <summary>
/// Ну так, может и понадоюится, хотя можно было и без него наверняка. 
/// Однако гуру паттернов мне подсказал что лучше сделать так
/// </summary>

public class Block : MonoBehaviour//, IBlock
{
    private float _speed = 0;

    private void Update()
    {
        _speed = SpawnerSettings.speed;
        transform.Translate(0, 0, -1 * Time.deltaTime * _speed, Space.World);
    }
}