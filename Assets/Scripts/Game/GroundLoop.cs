using UnityEngine;

public class GroundLoop : MonoBehaviour
{
    private float _speed = 0f;
    private Vector3 _offset = Vector3.zero;
    private Material _material;
    private float _correctTiling;

    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offset = _material.GetTextureOffset("_MainTex");
        _correctTiling = _material.mainTextureScale.y;
    }

    void Update()
    {
        _speed = SpawnerSettings.speed / 37.5f * _correctTiling;
        _offset.y += _speed * Time.deltaTime;
        _material.SetTextureOffset("_MainTex", _offset);
    }
}
