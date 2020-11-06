using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Vector3 moveDir;
    private Vector3 moveDirNormalized;
    private Vector3 moveDirRotation;

    private Rigidbody rb;
    //private Collider collider;
    public Ball ball;

    public Transform cam;
    public float rotationSensitivity = 10;
    public float jumpPower = 200;

    float groundDistance;

    public bool isGrounded;
    public float turnSmoothTime = 0.1f;
    
    float turnSmoothVelocity;

    void Start() {
        rb = GetComponent<Rigidbody>();
        //collider = GetComponent<Collider>();
        //Physics.CheckCapsule(collider.bounds.center, new Vector3(collider.bounds.center.x, collider.bounds.min.y - 0.1f, collider.bounds.center.z), 0.18f);
    }


    // Update is called once per frame
    public void Update() {
        //float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float horizontal = Input.GetAxisRaw("Mouse X");
        float horizontalStrife = Input.GetAxisRaw("Horizontal");
        
 

        if (isGrounded) { 
            moveDir = new Vector3(horizontalStrife, 0, vertical).normalized;
            moveDirRotation = new Vector3(horizontal, 0, 0);
            moveDirNormalized = moveDir;
            moveDir = transform.TransformDirection(moveDir);
        }

    }

    public void FixedUpdate() {

        if (isGrounded) {
            if (moveDir.magnitude >= 0.1f) {
                rb.MovePosition(rb.position + moveDir * moveSpeed * Time.deltaTime);
            }

           

            if (Input.GetButtonDown("Jump")) {
                rb.AddRelativeForce(0, jumpPower, 0, ForceMode.Impulse);
            }
        }
        //if (moveDirRotation.normalized.magnitude >= 0.01f) {
            transform.rotation = Quaternion.LookRotation(transform.position - cam.transform.position ).normalized;//Quaternion.Euler(transform.TransformDirection(moveDirNormalized));//Quaternion.LookRotation(transform.TransformDirection(moveDirRotation));//Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.TransformDirection(moveDirRotation) * rotationSensitivity), turnSmoothTime);
        //}
        Debug.Log(cam.transform.position);

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
