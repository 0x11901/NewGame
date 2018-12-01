using UnityEngine;

public class Hit : MonoBehaviour
{
    [SerializeField] private GameObject _box;
    [SerializeField] private GameObject _bullet;

    private float _cd;
    private float _margin;

    // Use this for initialization
    private void Start()
    {
        _cd = 0.5f;
        _margin = 0.5f;

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
            _margin += Time.deltaTime;

            if (_margin >= _cd)
            {
                _margin = 0.0f;
                var mainCamera = Camera.main;
                if (mainCamera == null) return;

                var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var bullet = Instantiate(_bullet);
                    bullet.transform.position = mainCamera.transform.position;
                    bullet.GetComponent<Rigidbody>().velocity = (hit.point - bullet.transform.position) * 10;
                }
            }
        }
    }
}