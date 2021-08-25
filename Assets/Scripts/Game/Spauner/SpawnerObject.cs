using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnerObject : SpawnerSettings
{
    public GameObject spaunBlock;

    internal readonly List<Renderer> _creater = new List<Renderer>();
    internal readonly List<Renderer> _visibled = new List<Renderer>();
    internal readonly List<GameObject> _free = new List<GameObject>();
    internal GameObject _inst_obj;
    internal bool _leftOrRight = true;

    //Левая граница рандомного спавна
    public float LeftRandomNumberEnd = -3.5f;
    public float LeftRandomNumberBegin = 0;

    //Правая граница спавна
    public float RightRandomNumberEnd = 3.5f;
    public float RightRandomNumberBegin = 0;

    //Поворот на угол
    public Vector3 leftRotationMain = new Vector3(0, 90, 0);
    public Vector3 rightRotation = new Vector3(0, 90, 0);

    public float addHeight = 0;
    public float addLength = 0;

    public virtual void SpawnBlock()
    {
        _inst_obj = GetFreeOrCreateBlock();
        if (_leftOrRight)
        {
            _inst_obj.transform.position = new Vector3(UnityEngine.Random.Range(LeftRandomNumberEnd, LeftRandomNumberBegin), startSpawn.y + addHeight, startSpawn.z + addLength);
            _leftOrRight = false;
            _inst_obj.transform.eulerAngles = leftRotationMain;
        }
        else
        {
            _inst_obj.transform.position = new Vector3(UnityEngine.Random.Range(RightRandomNumberBegin, RightRandomNumberEnd), startSpawn.y + addHeight, startSpawn.z + addLength);
            _leftOrRight = true;
            _inst_obj.transform.eulerAngles = rightRotation;
        }
        _creater.Add(_inst_obj.GetComponent<Renderer>());
    }

    internal GameObject GetFreeOrCreateBlock()
    {
        if (_free.Count > 0)
        {
            var temp = _free[0];
            _free.RemoveAt(0);
            return temp;
        }
        return Instantiate(spaunBlock);
    }

    internal void StartUpdate(int val = 17)
    {
        if (_inst_obj.transform.position.z <= startSpawn.z - val)
        {
            SpawnBlock();
        }
        _creater.Where(x => x.isVisible).ToList().ForEach(y =>
        {
            _visibled.Add(y);
            _creater.Remove(y);
        });
        foreach (var temp in _visibled.ToList())
        {
            if (!temp.isVisible)
            {
                _visibled.Remove(temp);
                _free.Add(temp.gameObject);
            }
        }
    }

    private int _slowdown = 0;
    private int _varForSlowdown = 60;

    private void FixedUpdate()
    {
        if (_varForSlowdown < _slowdown)
        {
            speed += stepForSpeed;
            _slowdown = 0;
        }
        _slowdown++;
    }
}

