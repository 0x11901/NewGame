using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private GameObject _box;

    // Use this for initialization
    private void Start()
    {
        for (var i = 0; i < 5; i++)
        {
            for (var j = 0; j < 5; j++)
            {
                var box = Instantiate(_box);
                box.transform.position = new Vector3(-2.0f + i, 0.5f + j, 4.5f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}