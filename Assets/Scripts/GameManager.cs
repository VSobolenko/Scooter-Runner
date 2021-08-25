using UnityEngine;

/// <summary>
/// О велий и могуйчий GameManager
/// </summary>

class GameManager : MonoBehaviour
{
    //public GameManager instance;
    [Header("Person")]
    public float speedPerson = 3.5f;
    public float rightZoneX = 3.7f;
    public float leftZoneX = -3.7f;
    private Player player;

    [Header("Block")]
    public float startSpeed = 3f;
    public float stepForSpeed = 0.5f;
    public Vector3 startSpawn = new Vector3(0, 0.428f, 30);

    //[Header("Spauner")]
    public SpawnerSettings main;

    [Header("UI")]
    public GameMenuController menuControllerUI;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        SpawnerSettings.startSpawn = startSpawn;
        SpawnerSettings.speed = startSpeed;
        SpawnerSettings.stepForSpeed = stepForSpeed;

        /*
        SpaunerBlock.instance.speed = startSpeedBlock;
        SpaunerBlock.instance.stepForSpeed = stepForSpeed;
        SpaunerBlock.instance.objectForSpaun = block;
        SpaunerBlock.instance.startSpawn = startSpaunBlock;
        */

        player.menuControllerPlayer = menuControllerUI;
        player.speed = speedPerson;
        player.rihgtZone = rightZoneX;
        player.leftZone = leftZoneX;

        PlayerMoving playerMoving = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoving>();
        playerMoving.leftZone = leftZoneX;
        playerMoving.rihgtZone = rightZoneX;
        playerMoving.speed = speedPerson;

        /*
        Player.instance.menuControllerPlayer = menuControllerUI;
        Player.instance.speed = speedPerson;
        Player.instance.rihgtZone = rightZoneX;
        Player.instance.leftZone = leftZoneX;
        */

        Debug.unityLogger.logEnabled = false;
    }
}
