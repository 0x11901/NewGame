using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _bullet;

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
        if (Input.GetButton("Fire1"))
        {
            var mainCamera = Camera.main;
            var bullet = Instantiate(_bullet);
            bullet.transform.position = mainCamera.transform.position;

            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                bullet.GetComponent<Rigidbody>().velocity = (hit.point - bullet.transform.position) * 10;
            }
        }
    }
}