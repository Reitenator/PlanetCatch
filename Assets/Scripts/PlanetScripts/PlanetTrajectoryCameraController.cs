using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTrajectoryCameraController : MonoBehaviour {

    private Transform currentPlanet;
    public Transform player;


    private void Start() {
        currentPlanet = GetComponent<Transform>();
    }

    void SetCameraAngleAndPosition() {
        //Debug.Log(player.transform.position);

    }

    void SetPlanetView() {
        // when the planet is changed. Considering to create a transition of camera
    }

    public void Update() {
        SetCameraAngleAndPosition();
    }
}
