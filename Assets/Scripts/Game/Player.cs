using System;
using System.Collections;
using Analytics;
using MoreMountains.NiceVibrations;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Считаю его великим после GameManager
/// </summary>

class Player : MonoBehaviour//, IPlayer
{
    public ParticleSystem OnDestroyParticle;
    public new GameObject particleSystem;

    //public static Player instance;

    [NonSerialized] public float speed;
    [NonSerialized] public float rihgtZone;
    [NonSerialized] public float leftZone;
    [NonSerialized] public float timer;
    [NonSerialized] public int skull;
    [NonSerialized] public GameMenuController menuControllerPlayer;

    [HideInInspector] public static uint temping;

    private void Start()
    {
        timer = 0f;
        skull = PlayerPrefs.GetInt("Skull");
        StartCoroutine(GetTime());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == null)
        {
            return;
        }
        
        if (collision.collider.tag == "Block")
        {
            Time.timeScale = 0f;
            menuControllerPlayer.ShowRestartGameMenu();
            temping++;
            Instantiate(OnDestroyParticle, new Vector3(transform.position.x, transform.position.y + 1.5f, transform.position.z + 1.2f), Quaternion.identity);
            //Debug.LogWarning(temping);
            MMVibrationManager.Haptic(HapticTypes.HeavyImpact);
            AnalyticsController.FinishLevel(SceneManager.GetActiveScene().name.Substring(2), (int)timer, skull);
        }
    }

    WaitForSeconds second = new WaitForSeconds(0.1f);
    IEnumerator GetTime()
    {
        while (true)
        {
            timer += 0.1f;
            timer = (float)Math.Round(timer, 1);
            yield return second;
        }
    }

    private void FixedUpdate()
    {
        speed += 0.0026f;
        //timer = (float)Math.Round(Time.time, 2);
        //Debug.Log(speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Skull")
        {
            skull++;
            Debug.Log("Skull: " + skull);
            Destroy(Instantiate(particleSystem, other.gameObject.transform.position, transform.rotation), 2f);
            MMVibrationManager.Haptic(HapticTypes.MediumImpact);
            Destroy(other.gameObject);
        }
    }
}

