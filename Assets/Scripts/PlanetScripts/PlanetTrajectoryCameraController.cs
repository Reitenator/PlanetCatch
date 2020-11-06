using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTrajectoryCameraController : MonoBehaviour {

    public Transform currentPlanet;
    public Transform player;

    void SetCameraAngleAndPosition() {
        //Debug.Log(player.transform.position);
    }

    void SetPlanetView() {
        // when the planet is changed. Considering to 
    }

    public void Update() {
        SetCameraAngleAndPosition();
    }
}
