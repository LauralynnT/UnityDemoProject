using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private Camera playerCamera;
    
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 3.0f;
    private CharacterController player;
    private Vector3 currentMovement = Vector3.zero;
    [Header("Look Settings")]
    [SerializeField] private float mouseSensitivity = 2.0f;
    [SerializeField] private float upDownLimit = 65f;
    private float verticalRotation;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleLook();
    }
    
    void HandleMovement()
    {
        Vector3 horizontalMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        horizontalMovement = transform.rotation * horizontalMovement;
        currentMovement.x = horizontalMovement.x * walkSpeed;
        currentMovement.z = horizontalMovement.z * walkSpeed;
        player.Move(currentMovement * Time.deltaTime);
    }
    void HandleLook()
    {
        float mouseXRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        this.transform.Rotate(0,mouseXRotation,0);
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownLimit, upDownLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation,0,0);
    }
}
