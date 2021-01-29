using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Speeds")]
    public float ForwardSpeed;
    public float SidewaysSpeed;

    [Header("Mouse Sensitivity")]
    public float MouseSensitivityX;
    public float MouseSensitivityY;

    [Space]
    public bool AirControl = true;
    public float JumpForce;

    private Vector3 MovementVector;
    private float HeadAngle = 0;

    private Camera camera;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        camera = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {        
        MovementVector.x = Input.GetAxis("Horizontal") * SidewaysSpeed;
        MovementVector.z = Input.GetAxis("Vertical") * ForwardSpeed;
        if (Input.GetButtonDown("Jump"))
        {
            MovementVector.y = JumpForce;
        }

        MovementVector.y -= -Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded || (!controller.isGrounded && AirControl))
        {
            controller.Move(transform.TransformDirection(MovementVector * Time.deltaTime));
        }

        transform.Rotate(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivityX, 0));
        HeadAngle = Mathf.Clamp(HeadAngle + (Input.GetAxis("Mouse Y") * MouseSensitivityY), -90, 90);

        camera.transform.localEulerAngles = new Vector3(HeadAngle, 0, 0);

        if (Input.GetAxis("Cancel") == 1)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }
}
