using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    public PlayerSettings playerSettings;
    //public GameObject player; //this
    public Rigidbody rb;

    private Transform cameraAnchor;
    public Camera playerCamera;
    private Vector3 cameraAnchorRotation;

    private NavMeshAgent navMeshAgent;
    public GameObject clickEffect;

	//private Vector3 previousMousePos;

    void Start() {
        cameraAnchor = playerCamera.transform.parent;
        cameraAnchorRotation.x = cameraAnchor.localRotation.eulerAngles.x;
        cameraAnchorRotation.y = cameraAnchor.localRotation.eulerAngles.y;

        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        CameraMovement();

		//PathfinderMovement();
		KeybordMovement();
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

	private void KeybordMovement() {
		//different types of wasd movement

		//transform.position += transform.forward * Input.GetAxis("Vertical") * slower + transform.right * Input.GetAxis("Horizontal") * slower;
		rb.MovePosition((transform.position + transform.forward * Input.GetAxis("Vertical") + transform.right * Input.GetAxis("Horizontal")) * Time.deltaTime);
		//rb.AddForce(transform.forward * Input.GetAxis("Vertical") * faster + transform.right * Input.GetAxis("Horizontal") * faster);
	}

	private void CameraMovement() {
        if (Input.GetMouseButton(1)) {
			Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;



            //y is left and right, x is up and down, cus unity is stupid
            cameraAnchorRotation.x += -Input.GetAxisRaw("Mouse Y") * playerSettings.sensetivity * playerSettings.sensetivityAxisMultiplier.x;
            cameraAnchorRotation.x = Mathf.Clamp(cameraAnchorRotation.x, playerSettings.cameraYRotMin, playerSettings.cameraYRotMax);
            cameraAnchorRotation.y += Input.GetAxisRaw("Mouse X") * playerSettings.sensetivity * playerSettings.sensetivityAxisMultiplier.y;


        }
        else {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        cameraAnchor.localRotation = Quaternion.Euler(cameraAnchorRotation.x - transform.localRotation.eulerAngles.x, cameraAnchorRotation.y - transform.localRotation.eulerAngles.y, 0);
        //cameraAnchor.localRotation = Quaternion.Euler(cameraAnchorRotation.x, 0, 0);
        //transform.rotation = Quaternion.Euler(0, cameraAnchorRotation.y, 0);
    }
}

[System.Serializable]
public class PlayerSettings {
    public float sensetivity = 1f;
    public Vector2 sensetivityAxisMultiplier = new Vector2(1f, 1f);
    public float cameraYRotMax = 80f;
    public float cameraYRotMin = 5f;
    public float scrollSpeed = 1f;

}