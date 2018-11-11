using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject DesignTemplate;
    private Vector3 _size;

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

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(DesignTemplate);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                var startPosition = DesignTemplate.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z + i * _size.x);
            }
        }
    }
}