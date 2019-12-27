﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

    public PlayerSettings playerSettings;
    public GameObject playerGfx;
    private Rigidbody rb;

	private Vector3 keybordInput;
	private Vector3 velocity;

	public Camera playerCamera;
	private Transform cameraAnchor;
    private Vector3 cameraAnchorRotation;
	private Vector3 cameraAnchorOffset;

	private Vector3 forward;

    private NavMeshAgent navMeshAgent;
    public GameObject clickEffect;

	//private Vector3 previousMousePos;

    void Start() {
		rb = GetComponent<Rigidbody>();

        cameraAnchor = playerCamera.transform.parent; // gets cameraAnchor through the assinged camera
		// sets initial rotation
        cameraAnchorRotation.x = cameraAnchor.localRotation.eulerAngles.x;
        cameraAnchorRotation.y = cameraAnchor.localRotation.eulerAngles.y;
		// stores original offset
		cameraAnchorOffset = cameraAnchor.localPosition;
		cameraAnchor.SetParent(null);


		navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        CameraMovement();

		Debug.Log(forward);
		Debug.DrawLine(cameraAnchor.transform.position, cameraAnchor.transform.position + forward, Color.red);

		//PathfinderMovement();
		KeybordInput();
	}

	private void FixedUpdate() {
		forward = Vector3.ProjectOnPlane(cameraAnchor.forward, Vector3.up).normalized;



		

		KeybordMovement();
		//Debug.Log(velocity);
		//rb.velocity = velocity;
		//Debug.Log(rb.velocity);

		cameraAnchor.transform.position = transform.position + cameraAnchorOffset;
	}

	private void LateUpdate() {
    }

	private void PathfinderMovement() {
		if (Input.GetMouseButtonDown(0)) {
			Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

			RaycastHit[] rayHits = Physics.RaycastAll(ray, 100, LayerMask.GetMask("Ground"));

			foreach (RaycastHit rh in rayHits) {
				navMeshAgent.destination = rh.point;
				GameObject _ffx = Instantiate(clickEffect, rh.point + new Vector3(0, 0.1f, 0), Quaternion.identity);
				Destroy(_ffx, 2f);
			}
		}
	}

	private void KeybordInput() {
		keybordInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
	}

	private void KeybordMovement() {
		//rb.velocity = transform.forward * Input.GetAxis("Vertical") * playerSettings.movementSpeed + transform.right * Input.GetAxis("Horizontal") * playerSettings.movementSpeed;
		
		rb.MovePosition(transform.position + (transform.right * keybordInput.x * playerSettings.movementSpeed + forward * keybordInput.z * playerSettings.movementSpeed));
		//rb.AddForce(transform.forward * Input.GetAxis("Vertical") * playerSettings.movementSpeed + transform.right * Input.GetAxis("Horizontal") * playerSettings.movementSpeed);
	}

	private void CameraMovement() {
        if (Input.GetMouseButton(1)) {
			Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

			//cameraAnchor.rotation *= Quaternion.AngleAxis(playerSettings.sensetivity * Input.GetAxisRaw("Mouse X") * Time.deltaTime, transform.up);
			//cameraAnchor.rotation *= Quaternion.AngleAxis(playerSettings.sensetivity * -Input.GetAxisRaw("Mouse Y") * Time.deltaTime, transform.right);
			
			cameraAnchorRotation.x += -Input.GetAxisRaw("Mouse Y") * playerSettings.sensetivity;
            cameraAnchorRotation.x = Mathf.Clamp(cameraAnchorRotation.x, playerSettings.cameraYRotMin, playerSettings.cameraYRotMax);
            cameraAnchorRotation.y += Input.GetAxisRaw("Mouse X") * playerSettings.sensetivity;
			
		}
		else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

		// rotates the cameraAnchor as if it is not the child of the player Object even if that is the case
		//cameraAnchor.localRotation = Quaternion.Euler(cameraAnchorRotation.x - transform.localRotation.eulerAngles.x, cameraAnchorRotation.y - transform.localRotation.eulerAngles.y, 0);

		cameraAnchor.localRotation = Quaternion.Euler(cameraAnchorRotation.x, cameraAnchorRotation.y, 0);

		// rotates the player itself around the y axis
		transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(transform.rotation.x, cameraAnchor.rotation.eulerAngles.y, playerGfx.transform.rotation.z), playerSettings.playerGfxRotationSpeed);
	}
}

[System.Serializable]
public class PlayerSettings {

	[Header("Keybord:")]

	public float movementSpeed = 1f;

	[Header("Mouse:")]
    public float sensetivity = 1f;
    public Vector2 sensetivityAxisMultiplier = new Vector2(1f, 1f);
    public float cameraYRotMax = 80f;
    public float cameraYRotMin = 5f;
    public float scrollSpeed = 1f;

	public float playerGfxRotationSpeed = 0.1f;
}