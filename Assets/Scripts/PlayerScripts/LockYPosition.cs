using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockYPosition : MonoBehaviour {

    public GameObject player;

    private void Update() {
        transform.position = player.transform.position;
        transform.up = player.transform.up;
        
    }

}
