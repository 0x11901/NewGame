using UnityEngine;

internal class Test : MonoBehaviour
{
    private float _speed;

    private void Start()
    {
        _speed = 1f;
    }

    public void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(Time.deltaTime * _speed, Vector3.up);
    }
}