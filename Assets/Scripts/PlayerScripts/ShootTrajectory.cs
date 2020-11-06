using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class ShootTrajectory : MonoBehaviour {

    public Ball ball;
    private Transform player;


    private List<GameObject> trajectoryLine = new List<GameObject>();

    public GameObject trajectoryObject;
    public int trajectoryMaxLength = 20;



    private void Start() {
        player = GetComponent<Transform>();
    }

    private void CreateTrajectory() {
        // Get the players z-direction to find where trajectory should go
        Vector3 trajectoryDirection = player.transform.forward;


        float t;
        t = (-1f * ball.exitSpeed); // divide it also by gravity 
        t = 2f * t;

        for (int i = 0; i < trajectoryMaxLength; i++) {
            // set the line trajectory line
            GameObject g = Instantiate(trajectoryObject, player.transform.position + trajectoryDirection * i, Quaternion.identity);
            g.transform.parent = player.GetChild(3).transform;
        }




    }

    private void Update() {
        if (Input.GetButtonDown("Fire1")) {
            CreateTrajectory();
        }
        if (Input.GetButtonUp("Fire1")) {
            foreach(Transform child in player.GetChild(3).transform) {
                GameObject.Destroy(child.gameObject);
            }
        }
        //if (trajectoryLine.Count >= 1) {
        //    for (int i= 0; i<trajectoryLine.Count; i++) {

        //    }
        //}
    }

}
