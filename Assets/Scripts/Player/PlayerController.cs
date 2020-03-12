using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {

	[Header("Dependencies:")]
	public GameObject playerGfx;
	public Camera playerCamera;
	private Transform cameraAnchor;

	private Rigidbody rb;
	private NavMeshAgent navMeshAgent;

	public GameObject clickEffect;

	[Header("Settings:")]
	public bool showCursor = true;
	public PlayerSettings playerSettings;


	[Header("Movement:")]
	private Vector3 movementInput;
	private Vector3 velocity;

	[Header("Rotation:")]
	private Vector3 rotationInput;
	private Vector3 rotation;

	private Quaternion playerGfxRotation;
	void Start() {
		rb = GetComponent<Rigidbody>();
		navMeshAgent = GetComponent<NavMeshAgent>();

		UnparentPlayerGfxStart();
	}

	private void UnparentPlayerGfxStart() {

		// gets cameraAnchor and cameraAnchor offset
		cameraAnchor = playerCamera.transform.parent;

		// set initial rotation
		rotation.x = cameraAnchor.localRotation.eulerAngles.x;
		rotation.y = transform.localRotation.eulerAngles.y;

		//playerGfx.transform.SetParent(null);
	}

	private void UnparentCameraStart() {

		// gets cameraAnchor through the assinged camera
		cameraAnchor = playerCamera.transform.parent;
		// set initial camera AnchorRotation rotation
		rotation.x = cameraAnchor.localRotation.eulerAngles.x;
		rotation.y = cameraAnchor.localRotation.eulerAngles.y;
		// stores original offset
		cameraAnchor.SetParent(null);
	}

	void Update() {
		GetInput();

		playerGfx.transform.position = this.transform.position;
	}

	private void GetInput() {
		// Movement Input
		movementInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Jump"), Input.GetAxis("Vertical"));
		if (Input.GetMouseButton(0) && Input.GetMouseButton(1)) {
			movementInput = new Vector3(movementInput.x, movementInput.y, 1);
		}

		// Rotation Input
		rotationInput = new Vector3(-Input.GetAxisRaw("Mouse Y"), Input.GetAxisRaw("Mouse X"), 0);

		// Mouse Input
		if (Input.GetMouseButtonDown(1)) { // this can be made a lot nicer by differentiating clicking and holding
			if (showCursor == true) {
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
			else {
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			showCursor = !showCursor;
		}
	}

	private void FixedUpdate() {

		CameraRotation();

		WASDMovement();

		//cameraAnchor.transform.position = transform.position + cameraAnchorOffset;
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

	private void WASDMovement() {

		float velX = movementInput.x * playerSettings.movementSpeed;
		float velZ = movementInput.z * playerSettings.movementSpeed;

		rb.velocity += transform.right * velX + transform.forward * velZ;

		//rb.MovePosition(transform.position + (transform.right * velX + transform.forward * velZ));

		//rb.velocity = new 
	}

	private void CameraRotation() {
		if (showCursor == false) {
			rotation.x += rotationInput.x * playerSettings.sensetivity;
			rotation.x = Mathf.Clamp(rotation.x, playerSettings.cameraYRotMin, playerSettings.cameraYRotMax);
			rotation.y += rotationInput.y * playerSettings.sensetivity;

			cameraAnchor.localRotation = Quaternion.Euler(rotation.x, 0, 0);
			transform.rotation = Quaternion.Euler(0, rotation.y, 0);
		}

		// Rotate the playerGfx smoothly
		playerGfxRotation = Quaternion.Lerp(playerGfxRotation, this.transform.rotation, playerSettings.playerGfxRotationSpeed);
		playerGfx.transform.rotation = playerGfxRotation;


		/* ----- Code Remnants ----- */
		// rotates the cameraAnchor as if it is not the child of the player Object even if that is the case
		//cameraAnchor.localRotation = Quaternion.Euler(cameraAnchorRotation.x - transform.localRotation.eulerAngles.x, cameraAnchorRotation.y - transform.localRotation.eulerAngles.y, 0);
		// smooth rotation effect to current player rotation
		//playerGfx.transform.rotation = Quaternion.Lerp(playerGfx.transform.rotation, Quaternion.Euler(playerGfx.transform.rotation.x, cameraAnchor.rotation.eulerAngles.y, playerGfx.transform.rotation.z), playerSettings.playerGfxRotationSpeed);
	}
}

[System.Serializable]
public class PlayerSettings {

	[Header("Movement:")]

	public float movementSpeed = 1f;
	public float accelerationSpeed = 0.2f;

	[Header("Rotation:")]
	public float sensetivity = 1f;
	public Vector2 sensetivityAxisMultiplier = new Vector2(1f, 1f);
	public float cameraYRotMax = 80f;
	public float cameraYRotMin = 5f;
	public float scrollSpeed = 1f;

	[Header("Player Graphics:")]
	public float playerGfxRotationSpeed = 0.1f;
}