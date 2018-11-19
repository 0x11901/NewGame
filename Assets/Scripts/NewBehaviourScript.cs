using System;
using Boo.Lang;
using UnityEngine;
using UnityEngine.Serialization;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private GameObject _designTemplateLeft;
    [SerializeField] private GameObject _designTemplateTop;
    [SerializeField] private GameObject _designTemplateRight;
    [SerializeField] private GameObject _designTemplateSelf;

    [SerializeField] private GameObject _handsLeft;
    [SerializeField] private GameObject _handsTop;
    [SerializeField] private GameObject _handsRight;

    private Vector3 _size;
    private byte _no;
    private byte _total;
    private List<GameObject> _riverCard;

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

    private void Awake()
    {
        _total = 136;
        _no = 0;
        _riverCard = new List<GameObject>(120);
    }

    public void ShowRiver()
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

                card.name = (++_no).ToString();

                var startPosition = _designTemplateLeft.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z + i * _size.x);

                _riverCard.Add(card);
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

                card.name = (++_no).ToString();

                var startPosition = _designTemplateTop.transform.position;
                card.transform.position = new Vector3(startPosition.x + i * _size.x, startPosition.y + j * _size.y,
                    startPosition.z);

                _riverCard.Add(card);
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

                card.name = (++_no).ToString();

                var startPosition = _designTemplateRight.transform.position;
                card.transform.position = new Vector3(startPosition.x, startPosition.y + j * _size.y,
                    startPosition.z - i * _size.x);

                _riverCard.Add(card);
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

                card.name = (++_no).ToString();

                var startPosition = _designTemplateSelf.transform.position;
                card.transform.position = new Vector3(startPosition.x - i * _size.x, startPosition.y + j * _size.y,
                    startPosition.z);

                _riverCard.Add(card);
            }
        }
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        foreach (var card in _riverCard)
        {
            if (byte.Parse(card.name) > _total)
            {
                card.SetActive(false);
            }
        }
    }
}