using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharacterController : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 10;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float rotateSpeed=1;
    [SerializeField] private bool mouseAiming=true;
    [SerializeField] private float gravity = 10;
    private CharacterController playerController;
    private float fallSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector2 inputVector = new Vector2(h, v).normalized;
        Vector3 mousePosition = Input.mousePosition;

        Vector3 targetVector = new Vector3(inputVector.x, 0, inputVector.y);
        Vector3 movementVector = MoveTowardTarget(targetVector);
        if (!mouseAiming)
        {
            RotateTowardMovementVector(movementVector);
        }
        else
        {
            RotateTowardMouseVector(mousePosition);
        }
        
        
    }
    private void RotateTowardMouseVector(Vector3 mousePosition)
    {
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance: 300f))
        {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }
    }

    private void RotateTowardMovementVector(Vector3 movementVector)
    {
        if (movementVector.magnitude == 0) { return; }
        Quaternion rotation = Quaternion.LookRotation(movementVector);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotateSpeed);
    }

    private Vector3 MoveTowardTarget(Vector3 targetVector)
    {
        float speed = moveSpeed * Time.deltaTime;
        targetVector = Quaternion.Euler(0, mainCamera.gameObject.transform.eulerAngles.y, 0) * targetVector;
        if (playerController.isGrounded)
        {
            fallSpeed = -gravity * Time.deltaTime;
        }
        else
        {
            fallSpeed -= gravity * Time.deltaTime;
        }
        targetVector.y = fallSpeed;
        playerController.Move(targetVector*speed);
        return targetVector;
    }
}
