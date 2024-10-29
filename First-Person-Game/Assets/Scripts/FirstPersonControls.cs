using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class FirstPersonControls : MonoBehaviour
{

    [Header("MOVEMENT SETTINGS")]
    [Space(5)]
    // Public variables to set movement and look speed, and the player camera
    public float moveSpeed; // Speed at which the player moves
    public float lookSpeed; // Sensitivity of the camera movement
    public float gravity = -9.81f; // Gravity value
    public float jumpHeight = 1.0f; // Height of the jump
    public Transform playerCamera; // Reference to the player's camera
                                   // Private variables to store input values and the character controller
    private Vector2 moveInput; // Stores the movement input from the player
    private Vector2 lookInput; // Stores the look input from the player
    private float verticalLookRotation = 0f; // Keeps track of vertical camera rotation for clamping
    private Vector3 velocity; // Velocity of the player
    private CharacterController characterController; // Reference to the CharacterController component
    public Controls playerInput;

    [Header("EXAMINE")]
    [Space(5)]
    public Transform itemPrefab;
    public Transform orbPrefab;
    public Transform[] ItemPrefabs;
    public GameObject ExaminePanel;
    private Door doorScript;

    [Header("UI SETTINGS")]
    [Space(5)]
    //public TextMeshProUGUI pickUpText;
    //public Image healthBar;
    public float damageAmount = 0.25f; // Reduce the health bar by this amount
    //private float healAmount = 0.5f;// Fill the health bar by this amount
    public float transparency;
    public RawImage crosshair;
    private HUD HUDScript;
    [SerializeField] GameObject player;
    public GameObject[] EndingUI;
    public GameObject ExitBtn;
    private ExamineItems examineItems;
    
    [Header("SHOOTING SETTINGS")]
    [Space(5)]
    public GameObject projectilePrefab; // Projectile prefab for shooting
    public Transform firePoint; // Point from which the projectile is fired
    public float projectileSpeed = 20f; // Speed at which the projectile is fired
    public float pickUpRange = 3f; // Range within which objects can be picked up
    private bool holdingGun = false;

    [Header("PICKING UP SETTINGS")]
    [Space(5)]
    public Transform holdPosition; // Position where the picked-up object will be held
    private GameObject heldObject; // Reference to the currently held object

    [Header("CROUCH SETTINGS")]
    [Space(5)]
    public float crouchHeight = 1f;//height of the player when crouching
    public float standingHeight = 2f;//Height of the player when standing 
    public float crouchSpeed = 1.5f;//Speed at which the player is moving while crouching
    private bool isCrouching = false; //Whether player is currently crouching

    [Header("DOOR AND DRAWER SETTINGS")]
    [Space(5)]
    //public string doorOpenAnimName, doorCloseAnimName;
    public float Interactiondistance = 3f;
    public LayerMask layers;
    public GameObject[] Doors;
    public GameObject[] DoorLocks;
    public GameObject DoorCanvas;

    [Header("EXAMINE SETTINGS")]
    [Space(5)]
    public GameObject[] ItemDescriptions;
    private bool toggle;

    public AudioSource KeySfx;

    private void Awake()
    {
        //Get and store the CharacterController component attached to this GameObject
        characterController = GetComponent<CharacterController>();
        HUDScript = player.GetComponent<HUD>();

        ExitBtn.SetActive(false);
        //DoorLocks[0].enabled = true;
        //DoorLocks[1].enabled = true;
        //DoorLocks[2].enabled = true;

    }

    private void Start()
    {

        
    }

    private void OnEnable()
    {
        // Create a new instance of the input actions
        var playerInput = new Controls();

        // Enable the input actions
        playerInput.Player.Enable();

        // Subscribe to the movement input events
        playerInput.Player.Movement.performed += ctx => moveInput = ctx.ReadValue<Vector2>(); // Update moveInput when movement input is performed
        playerInput.Player.Movement.canceled += ctx => moveInput = Vector2.zero; // Reset moveInput when movement input is canceled

        // Subscribe to the look input events
        playerInput.Player.LookAround.performed += ctx => lookInput = ctx.ReadValue<Vector2>(); // Update lookInput when look input is performed
        playerInput.Player.LookAround.canceled += ctx => lookInput = Vector2.zero; // Reset lookInput when look input is canceled

        // Subscribe to the jump input event
        playerInput.Player.Jump.performed += ctx => Jump(); // Call the Jump method when jump input is performed

        // Subscribe to the shoot input event
        playerInput.Player.Shoot.performed += ctx => Shoot(); // Call the Shoot method when shoot input is performed

        // Subscribe to the pick-up input event
        playerInput.Player.PickUp.performed += ctx => PickUpObject(); // Call the PickUpObject method when pick-up input is performed
        playerInput.Player.OldInteract.performed += ctx => Interaction(); // Call the PickUpObject method when pick-up input is performed

        playerInput.Player.Examine.performed += OnExaminePerformed;

        playerInput.Player.Crouch.performed += ctx => ToggleCrouch(); // Call the ToggleCrouchObject method when pick-up input is performed

    }

    public void OnExaminePerformed(InputAction.CallbackContext ctx)
    {
        ItemExamination();
    }


    private void Update()
    {
        // Call Move and LookAround methods every frame to handle player movement and camera rotation
        Move();
        LookAround();
        ApplyGravity();
        CheckForPickUp();
         
    }

    private void CheckForPickUp()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        // Perform raycast to detect objects
        if (Physics.Raycast(ray, out hit, pickUpRange))
        {
            // Check if the object has the "PickUp" tag
            if (hit.collider.CompareTag("Door"))
            {
                crosshair.color = Color.white;

            }
            else if (hit.collider.CompareTag("PickUp"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("Orb"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("LeftDoor"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("RightDoor"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.gameObject.GetComponent<NoteScript>())
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("Drawer"))
            {
                crosshair.color = Color.white;

            }
            else if (hit.collider.CompareTag("Lever"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("Cabinet"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("GoldKey"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("BronzeKey"))
            {
                crosshair.color = Color.white;

            }
            else if (hit.collider.CompareTag("SilverKey"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.CompareTag("Staff"))
            {
                crosshair.color = Color.white;
            }
            else if (hit.collider.gameObject.GetComponent<NoteScript>())
            {
                crosshair.color = Color.white;

            }
            else if (hit.collider.CompareTag("Staff"))
            {
                crosshair.color = Color.white;
            }
            else
            {
                crosshair.color = new Color(255f, 255f, 255f, transparency);
            }



        }
        else
        {
            // Hide the text if not looking at any object
            crosshair.color = new Color(255f, 255f, 255f, transparency);
        }
    }

  

    public void Move()
    {
        // Create a movement vector based on the input
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // Transform direction from local to world space
        move = transform.TransformDirection(move);

        float currentSpeed;
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        // Move the character controller based on the movement vector and speed
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }

    public void LookAround()
    {
        // Get horizontal and vertical look inputs and adjust based on sensitivity
        float LookX = lookInput.x * lookSpeed;
        float LookY = lookInput.y * lookSpeed;

        // Horizontal rotation: Rotate the player object around the y-axis
        transform.Rotate(0, LookX, 0);

        // Vertical rotation: Adjust the vertical look rotation and clamp it to prevent flipping
        verticalLookRotation -= LookY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        // Apply the clamped vertical rotation to the player camera
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);
    }

    public void ApplyGravity()
    {
        if (characterController.isGrounded && velocity.y < 0)
        {
            velocity.y = -0.5f; // Small value to keep the player grounded
        }

        velocity.y += gravity * Time.deltaTime; // Apply gravity to the velocity
        characterController.Move(velocity * Time.deltaTime); // Apply the velocity to the character
    }
    public void Jump()
    {
        if (characterController.isGrounded)
        {
            // Calculate the jump velocity
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //healthBar.fillAmount -= damageAmount;
    }
    public void Shoot()
    {
        if (holdingGun == true)
        {
            // Instantiate the projectile at the fire point
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

            // Get the Rigidbody component of the projectile and set its velocity
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = firePoint.forward * projectileSpeed;

            // Destroy the projectile after 3 seconds
            Destroy(projectile, 3f);
        }

        //healthBar.fillAmount += healAmount;
    }

    public void PickUpObject()
    {
        // Check if we are already holding an object
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
            heldObject.transform.parent = null;
            holdingGun = false;
            
        }

        // Perform a raycast from the camera's position forward
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        // Debugging: Draw the ray in the Scene view
        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.red, 2f);


        if (Physics.Raycast(ray, out hit, pickUpRange, layers))
        {
            // Check if the hit object has the tag "PickUp"
            if (hit.collider.CompareTag("PickUp"))
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

               
            }
            else if (hit.collider.CompareTag("Magic Staff"))
            {
                // Pick up the object
                heldObject = hit.collider.gameObject;
                heldObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics

                // Attach the object to the hold position
                heldObject.transform.position = holdPosition.position;
                heldObject.transform.rotation = holdPosition.rotation;
                heldObject.transform.parent = holdPosition;

                holdingGun = true;



            }
        }
    }

    public void ToggleCrouch()
    {
        if (isCrouching)
        {
            characterController.height = standingHeight;
            isCrouching = false;
        }
        else
        {
            characterController.height = crouchHeight;
            isCrouching = true;
        }
    }


    public void Interaction()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        Debug.DrawRay(playerCamera.position, playerCamera.forward * Interactiondistance, Color.blue, 2f);

        if (Physics.Raycast(ray, out hit, Interactiondistance, layers))
        {


            if (hit.collider.CompareTag("Door"))
            {
                foreach (GameObject door in Doors)
                {
                    if (hit.collider.gameObject.GetComponent<Door>().isDoorLocked == true)
                    {
                        hit.collider.GetComponent<Door>().DoorOpenClose();
                        StartCoroutine(LockDoor());
                    }

                }

                hit.collider.GetComponent<Door>().DoorOpenClose();

                
              
            }
            else if (hit.collider.CompareTag("Drawer"))
            {
                hit.collider.GetComponent<Door>().DrawerOpenClose();
                print("DRAWER OPENED");

            }
            else if (hit.collider.CompareTag("LeftDoor"))
            {
                hit.collider.GetComponent<CupboardScript>().LeftDoor();
            }
            else if (hit.collider.CompareTag("RightDoor"))
            {
                hit.collider.GetComponent<CupboardScript>().RightDoor();
            }
            else if (hit.collider.CompareTag("Lever"))
            {
                hit.collider.GetComponent<ShelfSwitch>().Lever();
                print("Hit!!");

            }
            else if (hit.collider.CompareTag("Cabinet"))
            {
                hit.collider.GetComponent<Door>().CabinetOpenClose();
            }
            else if (hit.collider.CompareTag("Staff"))
            {
                StartCoroutine(DisplayButton());
                foreach (GameObject end in EndingUI)
                {
                    end.SetActive(true);
                }
                SetPlayerMovement(false);



            }

            else if (hit.collider.CompareTag("Orb"))
            {
                print("Spin");
                hit.collider.GetComponent<OrbScript>().OrbSpin();
            }
            else if (hit.collider.CompareTag("GoldKey"))
            {
                Doors[2].layer = 0;//Changes the layer the doors on back to the default so the raycast can interact with. Essentially unlocking the door
                Destroy(hit.collider.gameObject);//The Key is destroyed after it is collected
                if(HUDScript.HeavenKeyCount <= 0)
                {
                    HUDScript.HeavenKeyCount++;
                    //DoorLocks[2].enabled = false;
                    DoorCanvas.SetActive(false);
                }
            }

            else if (hit.collider.CompareTag("BronzeKey"))
            {
                KeySfx.Play();
                Doors[0].GetComponent<Door>().UnlockDoor();
                Destroy(hit.collider.gameObject);//The Key is destroyed after it is collected
                /*if(HUDScript.LibraryKeyCount <= 0)
                {
                    HUDScript.LibraryKeyCount++;
                    DoorLocks[0].enabled = false;
                }
                */
            }

            else if (hit.collider.CompareTag("SilverKey"))
            {
                Doors[1].layer = 0;//Changes the layer the doors on back to the default so the raycast can interact with. Essentially unlocking the door
                Destroy(hit.collider.gameObject);//The Key is destroyed after it is collected
                if(HUDScript.HllKeyCount <= 0)
                {
                    HUDScript.HllKeyCount++;
                    //DoorLocks[1].enabled = false;
                }
            }

            else if (hit.collider.gameObject.GetComponent<NoteScript>())
            {
                hit.collider.gameObject.GetComponent<NoteScript>().NoteOpenClose();

               


                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);

                }

                if (toggle)
                {

                    SetPlayerMovement(false);
                }

            }


        }
        
    }

    public void ItemExamination()
    {
        Ray ray = new Ray(playerCamera.position, playerCamera.forward);
        RaycastHit hit;

        Debug.DrawRay(playerCamera.position, playerCamera.forward * pickUpRange, Color.green, 0.2f);

        if (Physics.Raycast(ray, out hit, pickUpRange, layers))
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.CompareTag("Bookshelf"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[0].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[0].SetActive(true);


                    if (itemPrefab != null)
                    {
                      Destroy(itemPrefab.gameObject);
                    }
                     itemPrefab = Instantiate(itemPrefab, new Vector3(1000, 1000, 1000), Quaternion.identity);
                }
            }
            else if (hit.collider.CompareTag("Orb"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ExaminePanel.SetActive(false);
                    crosshair.enabled = true;
                    ItemDescriptions[1].SetActive(false);
                    Destroy(itemPrefab.gameObject);
                    
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ExaminePanel.SetActive(true);
                    crosshair.enabled = false;
                    ItemDescriptions[1].SetActive(true);
                    itemPrefab = Instantiate(ItemPrefabs[0], new Vector3(1000, 1000, 1000), Quaternion.identity);
                }
            }
            else if (hit.collider.CompareTag("BronzeKey"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ExaminePanel.SetActive(false);
                    crosshair.enabled = true;
                    ItemDescriptions[1].SetActive(false);
                    Destroy(itemPrefab.gameObject);

                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ExaminePanel.SetActive(true);
                    crosshair.enabled = false;
                    ItemDescriptions[1].SetActive(true);
                    itemPrefab = Instantiate(ItemPrefabs[1], new Vector3(1000, 1000, 1000), Quaternion.identity);
                }
            }
            else if (hit.collider.CompareTag("Door"))
            {

                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[2].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[2].SetActive(true);
                }
            }
            else if (hit.collider.CompareTag("Lever"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[3].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[3].SetActive(true);
                }
            }
            else if (hit.collider.CompareTag("Drawer"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[4].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[4].SetActive(true);
                }
            }
            else if (hit.collider.CompareTag("Cupboard"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[5].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[5].SetActive(true);
                }
            }
            else if (hit.collider.CompareTag("LeftDoor"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[6].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[6].SetActive(true);
                }
            }
            else if (hit.collider.CompareTag("RightDoor"))
            {
                toggle = !toggle;
                if (toggle == false)
                {
                    SetPlayerMovement(true);
                    ItemDescriptions[7].SetActive(false);
                }

                if (toggle)
                {
                    SetPlayerMovement(false);
                    ItemDescriptions[7].SetActive(true);
                }
            }

        }

    }

    private void SetPlayerMovement(bool isActive)
    {
        if (isActive)
        {
           moveSpeed = 6.4f;
           lookSpeed = 0.62f;
        }
        else
        {
           lookSpeed = 0f;
           moveSpeed = 0f;
        }
    }


  

    IEnumerator DisplayButton()
    {

        yield return new WaitForSeconds(5.0f);
        ExitBtn.SetActive(true);

    }

    IEnumerator LockDoor()
    {

        foreach(GameObject UIlock in DoorLocks)
        {
            UIlock.SetActive(true);
        }
        yield return new WaitForSeconds(4.0f);
        foreach (GameObject UIlock in DoorLocks)
        {
            UIlock.SetActive(false);
        }

    }



}