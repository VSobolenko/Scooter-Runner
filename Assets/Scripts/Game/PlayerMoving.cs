using System;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [NonSerialized] public float rihgtZone;
    [NonSerialized] public float leftZone;
    [NonSerialized] public float speed;

    private bool _moveLeft = false;
    private bool _moveRight = false;

    private Quaternion _norMode = Quaternion.Euler(0, -90, 0);
    private Quaternion _movModeLeft = Quaternion.Euler(4, -100, 0);
    private Quaternion _movModeRight = Quaternion.Euler(-4, -80, 0);

    public void GoToLeftStart()
    {
        _moveLeft = true;
        //Debug.Log("Moving to left START");
    }

    public void GoToLeftStop()
    {
        _moveLeft = false;
        //Debug.Log("Moving to left STOP");
    }

    public void GoToRightStart()
    {
        _moveRight = true;
        //Debug.Log("Go to right START");
    }

    public void GoToRightStop()
    {
        _moveRight = false;
        //Debug.Log("Go to right STOP");
    }

    void Update()
    {
        speed = gameObject.GetComponent<Player>().speed;
        if (_moveLeft)
        {
            transform.rotation = _movModeLeft;

            transform.Translate(-1 * Time.deltaTime * speed, 0, 0, Space.World);
            if (transform.position.x < leftZone)
            {
                transform.position = new Vector3(leftZone, 0.2f, -0.528f);
            }
        }

        if (_moveRight)
        {
            transform.rotation = _movModeRight;

            transform.Translate(1 * Time.deltaTime * speed, 0, 0, Space.World);
            if (transform.position.x > rihgtZone)
            {
                transform.position = new Vector3(rihgtZone, 0.2f, -0.528f);
            }
        }

        if (!_moveLeft && !_moveRight)
            transform.rotation = _norMode;
    }
}
