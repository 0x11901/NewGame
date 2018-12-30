using UnityEngine;

public class Move : MonoBehaviour
{
    private const float Speed = 2.618f;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");
    private Animator _animator;
    private Camera _mainCamera;

    private const float RayLength = 100f;
    private LayerMask _floorMask;

    #region Unity

    private void Awake()
    {
        _floorMask = LayerMask.GetMask("Floor");
    }

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

        if (Input.GetButton("Fire1"))
        {
            print("fire!!!");
        }

        _animator.SetBool(IsWalk, isWalk);
    }

    private void FixedUpdate()
    {
        TurningWithMouse();
    }

    private void TurningWithMouse()
    {
        var camRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(camRay, out var floorHit, RayLength, _floorMask)) return;
        var target = floorHit.point;
        target.y = transform.position.y;
        transform.LookAt(target);
    }

    #endregion
}