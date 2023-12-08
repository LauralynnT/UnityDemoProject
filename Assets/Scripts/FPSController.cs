using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
   
    [Header("Movement Settings")]
    [SerializeField] private float walkSpeed = 3.0f;
    private CharacterController player;
    private Vector3 currentMovement = Vector3.zero;
    [Header("Look Settings")]
    [SerializeField] private float mouseSensitivity = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }
    
    void HandleMovement()
    {
        Vector3 horizontalMovement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        currentMovement.x = horizontalMovement.x * walkSpeed;
        currentMovement.z = horizontalMovement.z * walkSpeed;
        player.Move(currentMovement * Time.deltaTime);
    }
}
