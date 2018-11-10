using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject DesignTemplate;
    private Vector3 _size;


    private void Awake()
    {
//        _size = DesignTemplate.transform.GetComponent<MeshFilter>().mesh.bounds.size;
        _size = new Vector3(0.05207656f, 0.06724269f, 0.03182981f);
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start()
    {
        for (var i = 0; i < 18; ++i)
        {
            for (var j = 0; j < 2; ++j)
            {
                var card = Instantiate(DesignTemplate);
                var startPosition = DesignTemplate.transform.position;
                card.transform.position = new Vector3(startPosition.x + _size.x * 0.5f + i * _size.x, startPosition.y,
                    startPosition.z);
            }
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
    }
}