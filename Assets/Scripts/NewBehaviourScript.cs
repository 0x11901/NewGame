using UnityEngine;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _designTemplateLeft;
    [SerializeField] private GameObject _designTemplateTop;
    [SerializeField] private GameObject _designTemplateRight;
    [SerializeField] private GameObject _designTemplateSelf;

    private byte _no;

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
                var card = Instantiate(_designTemplateLeft);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

//                card.tag = _no

                var startPosition = _designTemplateLeft.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z + i * _size.x);
            }
        }

        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateTop);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                var startPosition = _designTemplateTop.transform.position;
                card.transform.position = new Vector3(startPosition.x + i * _size.x, startPosition.y + j * _size.y,
                    startPosition.z);
            }
        }

        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateRight);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                var startPosition = _designTemplateRight.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z - i * _size.x);
            }
        }

        for (var i = 0; i < 15; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(_designTemplateSelf);
                if (_size == Vector3.zero)
                {
                    _size = GetObjectSize(card);
                }

                var startPosition = _designTemplateSelf.transform.position;
                card.transform.position = new Vector3(startPosition.x - i * _size.x, startPosition.y + j * _size.y,
                    startPosition.z);
            }
        }
    }
}