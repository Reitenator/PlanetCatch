using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityControllerHandler : MonoBehaviour {

    public float gravity = -10f;
    
    //public GravityField gravityField;

    public void Start() {
        //gravityField = GetComponent<GravityField>();
    }

    public void Attract(Transform other) {
        Vector3 gravityUp = (other.position - transform.position).normalized;
        Vector3 bodyUp = other.up;
        other.GetComponent<Rigidbody>().AddForce(gravityUp * gravity * other.GetComponent<Rigidbody>().mass);
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * other.rotation;
        other.rotation = Quaternion.Slerp(other.rotation, targetRotation, 50 * Time.deltaTime);
    }



    void OnTriggerStay(Collider other) {
        if (other.attachedRigidbody) {
            Attract(other.transform);
        }    
    }

}
