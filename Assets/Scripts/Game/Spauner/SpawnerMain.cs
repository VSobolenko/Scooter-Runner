using System.Linq;
using UnityEngine;

public class SpawnerMain : SpawnerObject
{
    private int[] direction = new int[] { 11, 12, 13, 21, 22, 31, 32, 33, 41 };

    private System.Random rand = new System.Random();
    private int state;

    private int[] currentDirection;

    public GameObject skull;
    public int firstSkull = 5;
    public int nextSkull = 10;
    private int _startSkull;

    public override void SpawnBlock()
    {
        state = currentDirection[rand.Next(0, currentDirection.Length)];

        currentDirection = direction.Where(x => x != state).ToArray();

        _inst_obj = GetFreeOrCreateBlock();

        if (state == 11 || state == 13)
        {
            _inst_obj.transform.position = new Vector3(LeftRandomNumberEnd, 0, startSpawn.z);
        }
        else if (state == 12)
        {
            _inst_obj.transform.position = new Vector3(LeftRandomNumberEnd / 2, 0, startSpawn.z);
        }
        else if (state == 21)
        {
            _inst_obj.transform.position = new Vector3(LeftRandomNumberEnd / 4, 0, startSpawn.z);
        }
        else if (state == 22)
        {
            _inst_obj.transform.position = new Vector3(RightRandomNumberEnd, 0, startSpawn.z);
        }
        else if (state == 31 || state == 33)
        {
            _inst_obj.transform.position = new Vector3(RightRandomNumberEnd / 2, 0, startSpawn.z);
        }
        else if (state == 32)
        {
            _inst_obj.transform.position = new Vector3(RightRandomNumberEnd / 4, 0, startSpawn.z);
        }
        else if (state == 41)
        {
            _inst_obj.transform.position = new Vector3(0, 0, startSpawn.z);
        }
        else
        {
            Debug.LogError("ERROR STATE: " + state);
        }

        _inst_obj.transform.rotation = Quaternion.Euler(leftRotationMain);
        _creater.Add(_inst_obj.GetComponent<Renderer>());

        _startSkull--;
        if (_startSkull == 0)
        {
            float posX = state >= 22 ? LeftRandomNumberEnd : RightRandomNumberEnd;
            _startSkull = nextSkull;
            Instantiate(skull, new Vector3(posX, 0.738f, startSpawn.z), Quaternion.identity);
        }
    }

    private void Start()
    {
        _startSkull = firstSkull;
        currentDirection = new int[direction.Length];
        currentDirection = direction;
        SpawnBlock();
    }

    private void Update()
    {
        StartUpdate();
    }
}
