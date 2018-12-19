using UnityEngine;

public class Initialization : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    private Vector3 _size;

    #region Unity

    // Start is called before the first frame update
    private void Start()
    {
        for (var i = -50; i <= 50; i++)
        {
            for (var j = -50; j < 50; j++)
            {
                var f = Instantiate(floor);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(f);
                }

                f.transform.position = new Vector3(0 + _size.x * i, 0, _size.z * j);
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #endregion

    #region Tools

    private Vector3 GetObjectSize(GameObject go)
    {
        var realSize = Vector3.zero;

        var mesh = go.GetComponent<MeshFilter>().sharedMesh;
        if (mesh == null)
        {
            return realSize;
        }

        var meshSize = mesh.bounds.size;
        var scale = transform.lossyScale;
        realSize = new Vector3(meshSize.x * scale.x, meshSize.y * scale.y, meshSize.z * scale.z);

        return realSize;
    }

    #endregion
}