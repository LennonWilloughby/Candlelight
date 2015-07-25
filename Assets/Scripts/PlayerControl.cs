using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerControl : MonoBehaviour {

	// Public
	public float moveSpeed = 5.0f; // player movement speed
	public float rotationSpeed = 360.0f; // player rotation speed
	public bool vibration;
	public AudioClip rightClick;
	
	// Private
	private Vector3 playerPos; // holds current player position
	private Vector3 targetPosition; // a target position that the player can move towards
	private Quaternion targetRotation; // a target rotation so that the player can face the direction that they will move in
	private CharacterController controller; // unity's easy way to make a controller for player character
	private Camera mainCam; // provides a link to the main camera



	// Use this for initialization
	void Start () {
	
		// set camera and controller
		mainCam = Camera.main;
		controller = GetComponent<CharacterController>();
	}


	// Update is called once per frame
	void Update () {
	
# if UNITY_ANDROID
		ControlTouch ();
#endif

		ControlClick ();
		//ControlMouse();
		//ControlKeys();
	}


	// Control method for click
	void ControlClick () {

		if (Input.GetKeyDown("r")){
			AutoFade.LoadLevel(Application.loadedLevel, 1, 1, Color.black);
		}
		if (Input.GetKeyDown("m")){
			AutoFade.LoadLevel("MenuMain", 1, 1, Color.black);
		}

		// Variables for mouse and player position
		Vector3 mousePos = Input.mousePosition;
		playerPos = new Vector3 (transform.position.x, 0, transform.position.z);

		// Converts mouse position from screen to world point
		mousePos = mainCam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, mainCam.transform.position.y - transform.position.y));

		// Detects raycast hit
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		Physics.Raycast(ray, out hit);

		// If left mouse click
		if (Input.GetMouseButton(0)) {

			// Rotate Player
			targetRotation = Quaternion.LookRotation (mousePos - playerPos);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

			// Sets position of left mouse click and offset from player position
			Vector3 targetPosition = hit.point;
			Vector3 offset = targetPosition - transform.position;

			// If player hasn't reached target position yet
			if (offset != targetPosition) {

				// normalise speed, multiply by moveSpeed and move player via controller
				offset = offset.normalized * moveSpeed;
				controller.Move(offset * Time.deltaTime);
		
			}
		}

		if (!GameManager.micOn) {
			
			// If right mouse click
			if (Input.GetMouseButtonDown(1)) {
				AudioSource.PlayClipAtPoint (rightClick, transform.position, 0.5f);
				vibration = true;
			}
			else {
				
				vibration = false;
			}
		}
	}


	// Control method for mouse
	void ControlMouse () {

		Vector3 input = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

		Vector3 mousePos = Input.mousePosition;
		playerPos = new Vector3 (transform.position.x, 0, transform.position.z);

		mousePos = mainCam.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, mainCam.transform.position.y - transform.position.y));
		targetRotation = Quaternion.LookRotation (mousePos - playerPos);
		transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		
		Vector3 motion = input;
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1) ? 0.7f : 1;
		motion *= moveSpeed;
		controller.Move (motion * Time.deltaTime);
	}


	// Control method for keys
	void ControlKeys () {

		Vector3 input = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
		
		if (input != Vector3.zero) {
			targetRotation = Quaternion.LookRotation (input);
			transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
		}
		
		Vector3 motion = input;
		motion *= (Mathf.Abs (input.x) == 1 && Mathf.Abs (input.z) == 1) ? 0.7f : 1;
		motion *= moveSpeed;
		controller.Move (motion * Time.deltaTime);

	}


	// Control method for touch
	void ControlTouch () {

		// if the screen has been touched
		if (Input.touchCount > 0) {
			// Variables for touch and player position
			Vector3 touchPos = Input.GetTouch(0).position;
			playerPos = new Vector3 (transform.position.x, 0, transform.position.z);
			
			// Converts touch position from screen to world point
			touchPos = mainCam.ScreenToWorldPoint (new Vector3 (touchPos.x, touchPos.y, mainCam.transform.position.y - transform.position.y));
			
			// Detects raycast hit
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
			RaycastHit hit;
			Physics.Raycast(ray, out hit);
			
			// If screen touched
			if (Input.GetTouch(0).phase == TouchPhase.Began || Input.GetTouch(0).phase == TouchPhase.Stationary || Input.GetTouch(0).phase == TouchPhase.Moved) 
				{
					// Rotate Player
				targetRotation = Quaternion.LookRotation (touchPos - playerPos);
				transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
				
				// Sets position of touch and offset from player position
				Vector3 targetPosition = hit.point;
				Vector3 offset = targetPosition - transform.position;
				
				// If player hasn't reached target position yet
				if (offset != targetPosition) {
					
					// normalise speed, multiply by moveSpeed and move player via controller
					offset = offset.normalized * moveSpeed;
					controller.Move(offset * Time.deltaTime);
				}

			}

		}

	}

}
