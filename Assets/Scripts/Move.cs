using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    private float _speed;

    #region Unity

    // Start is called before the first frame update
    private void Start()
    {
        _speed = 1f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            this.transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            this.transform.Translate(Vector3.left * _speed * Time.deltaTime);
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            this.transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            this.transform.Translate(Vector3.back * _speed * Time.deltaTime);
        }

        if (Input.GetButton("Fire1"))
        {
            print("fire!!!");
        }
    }

    #endregion
}