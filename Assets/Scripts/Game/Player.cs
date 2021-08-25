using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Считаю его великим после GameManager
/// </summary>

class Player : MonoBehaviour//, IPlayer
{
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
        if (collision.collider.tag == "Block")
        {
            Time.timeScale = 0f;
            menuControllerPlayer = menuControllerPlayer.GetComponent<GameMenuController>();
            menuControllerPlayer.ShowRestartGameMenu();
            temping++;
            Debug.LogWarning(temping);
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
            //particleSystem.Play();
            Destroy(other.gameObject);
        }
    }
}

