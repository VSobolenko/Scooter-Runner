using System.Collections;
using UnityEngine;

public class Skull : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(50 / SpawnerSettings.speed);
        Destroy(this.gameObject);
    }
}
