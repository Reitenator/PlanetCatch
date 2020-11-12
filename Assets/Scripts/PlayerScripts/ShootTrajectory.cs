using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class ShootTrajectory : MonoBehaviour {

    public Ball ball;
    private Transform player;



    Vector3 trajectoryDirection;
    public GameObject trajectoryObject;
    public GameObject ballHolder;

    public int trajectoryMaxLength = 30;
    public float throwForce = 50;
    public bool playerHasBall;

    private void Start() {
        player = GetComponent<Transform>();
        
    }

    private void CreateTrajectory() {
        // Get the players z-direction to find where trajectory should go
        Vector3 trajectoryDirection = player.transform.forward;
        // The trajectory should curve along with the gravity (force downwards)




        float t;
        t = (-1f * ball.exitSpeed); // divide it also by gravity 
        t = 2f * t;

        for (int i = 0; i < trajectoryMaxLength; i++) {
            // set the line trajectory line
            GameObject g = Instantiate(trajectoryObject, player.position + trajectoryDirection * i, Quaternion.identity);
            g.transform.parent = player.GetChild(3).transform;
        }




    }

    IEnumerator ThrowBall() {
        playerHasBall = false;
        ball.GetComponent<Rigidbody>().AddForce((trajectoryDirection) * throwForce, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f);
        ball.GetComponent<Collider>().enabled = true;
        
    }


   
    private void PickUpBall() {
        playerHasBall = true;
        ball.GetComponent<Collider>().enabled = false;
        Debug.Log("Ball should have been picked up");
    }


    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.name == "Ball" && !playerHasBall) {
            PickUpBall();
        }
    }

    private void Update() {
        trajectoryDirection = player.forward;
        if (playerHasBall) {
            ball.transform.position = ballHolder.transform.position;
        }
        
        if (Input.GetButtonDown("Fire1")) {
            CreateTrajectory();
        }
        if (Input.GetButtonUp("Fire1")) {
            foreach(Transform child in player.GetChild(3).transform) {
                Destroy(child.gameObject);
            }
            if (playerHasBall) {
                StartCoroutine(ThrowBall());
            }
            
        }
        //if (trajectoryLine.Count >= 1) {
        //    for (int i= 0; i<trajectoryLine.Count; i++) {

        //    }
        //}
    }

}
