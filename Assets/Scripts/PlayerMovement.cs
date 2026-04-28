using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    public float gravity = 20;

    private CharacterController characterController;
    private Vector3 moveDir;

    [SerializeField] private GameObject playerHand;

    public Camera playerCam;
    public float camXSensitivity = 1.5f;
    public float camYSensitivity = 1;

    public GameManager gameManager;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        gameManager = FindObjectOfType<GameManager>();
        //Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CharacterControllerMovement();

        if (Input.GetKey(KeyCode.Alpha1)) AttachGun();
    }

    void LateUpdate()
    {
        CamControls();
    }

    void CharacterControllerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        moveDir = new Vector3(horizontal, 0, vertical);
        moveDir *= moveSpeed;
        moveDir = transform.TransformDirection(moveDir);

        moveDir.y = moveDir.y + Physics.gravity.y;
        characterController.Move(moveDir * Time.deltaTime);
    }

    void CamControls()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 rotationY = transform.localEulerAngles;
        rotationY.y += mouseX * camYSensitivity;
        transform.localRotation = Quaternion.AngleAxis(rotationY.y, Vector3.up);

        Vector3 rotationX = playerCam.gameObject.transform.localEulerAngles;
        rotationX.x -= mouseY * camXSensitivity;
        playerCam.gameObject.transform.localRotation = Quaternion.AngleAxis(rotationX.x, Vector3.right);
    }

    void AttachGun()
    {
        gameManager.AR.transform.parent = playerHand.transform;
        gameManager.AR.transform.position = playerHand.transform.position;
        gameManager.AR.transform.rotation = playerHand.transform.rotation;
        gameManager.AR.isGunEquipped = true;
    }
}
