using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour{


    [Range(0,30)]
    public float moveSpeed = 15f;

    [Range(50,250)]
    public float rotationSpeed;

    public float rotationSensitivity = 10;
    public float jumpPower = 200;

    public Animator anim;

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;

    private Vector3 moveDir;


    private Rigidbody rb;
    //private Collider collider;
    public Ball ball;

    
    public Transform playerWorldPosition;
    public Transform cam;

   

    public Vector3 lookDirection;

    public bool isGrounded;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private Vector2 ML;
    

    void Start() {
        rb = GetComponent<Rigidbody>();
        lookDirection = transform.position - cam.transform.position;
        Cursor.lockState = CursorLockMode.Locked;
    }


    // Update is called once per frame
    public void Update() {
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontalStrife = Input.GetAxisRaw("Horizontal");

        
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Cursor.lockState = CursorLockMode.None;
        }
        //if (Vector3.Angle(playerWorldPosition.transform.up, transform.up) >= 90) {
        //    horizontalStrife = -Input.GetAxisRaw("Horizontal");
        //}
        moveDir = new Vector3(horizontalStrife, 0, vertical).normalized;
        Vector3 targetMoveAmount = moveDir * moveSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

    }

    public void FixedUpdate() {

        Vector3 lookVector = transform.position - cam.position; //new Vector3(cam.position.x, cam.position.y, cam.position.z)
        if (Vector3.Angle(playerWorldPosition.transform.up, transform.up) <= 90) {
            Debug.Log("Upside");
            

        } else {
            Debug.Log("Downside");
            

        }
        Debug.Log(lookVector);


        
        
        if (isGrounded) {
            if (moveDir.magnitude >= 0.1) {
                //transform.rotation = Quaternion.LookRotation(lookVector);
                
                //transform.rotation = Quaternion.LookRotation(transform.position - new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z), transform.up);
            }

            if (moveAmount.magnitude >= 0.1f) {
                
                rb.MovePosition(rb.position + (transform.TransformDirection(moveAmount) - cam.position ) * Time.fixedDeltaTime);
                Debug.Log(moveDir.magnitude);
                anim.SetFloat("Speed", moveDir.magnitude);

            }

            if (Input.GetButtonDown("Jump")) {
                rb.AddRelativeForce(0, jumpPower, 0, ForceMode.Impulse);
            }
        }
        
       



    }
   

    private void OnCollisionStay(Collision other) {
        if (other.gameObject.CompareTag("Planet") && !other.collider.isTrigger) {
            isGrounded = true;
            //Debug.Log(isGrounded);
        } else {
            //Debug.Log(isGrounded);
            isGrounded = false;
        }
    }
}
