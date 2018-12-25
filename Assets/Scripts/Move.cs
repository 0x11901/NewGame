using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private GameObject hero;
    private const float Speed = 2.618f;
    private Animator _animator;
    private static readonly int IsWalk = Animator.StringToHash("isWalk");

    #region Unity

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
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

        // var mainCamera = Camera.main;
        // if (mainCamera != null)
        // {
        //     var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        // }

        // RaycastHit hit;

        // if(Physics.Raycast (camRay, out floorHit, camRayLength, floorMask))
        // {
        //     Vector3 playerToMouse = floorHit.point - transform.position;
        //
        //     playerToMouse.y = 0f;
        //
        //     Quaternion newRotatation = Quaternion.LookRotation (playerToMouse);
        //
        //     playerRigidbody.MoveRotation (newRotatation);
        // }
 
        
        if (Input.GetButton("Fire1"))
        {
            print("fire!!!");
        }

        _animator.SetBool(IsWalk, isWalk);
    }

    #endregion
}