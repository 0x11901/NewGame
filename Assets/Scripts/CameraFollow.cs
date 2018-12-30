using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 _vector;

    private void Start()
    {
        _vector = transform.position - target.position;
    }

    private void LateUpdate()
    {
        transform.position = _vector + target.position;
    }
}