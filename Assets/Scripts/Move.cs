using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    private const float Speed = 2.618f;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");
    private Animator _animator;
    private Camera _mainCamera;

    #region Unity

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        var isWalk = false;
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            isWalk = true;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            isWalk = true;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
            isWalk = true;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
            isWalk = true;
        }


        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            var vector = hit.point - transform.position;
            vector.y = 0f;
            transform.LookAt(vector);
        }


        if (Input.GetButton("Fire1"))
        {
            print("fire!!!");
        }

        _animator.SetBool(IsWalk, isWalk);
    }

    #endregion
}