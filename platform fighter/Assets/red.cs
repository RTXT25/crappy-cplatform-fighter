using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red : MonoBehaviour{
    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            HubController.exitmenuon = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            HubController.exitmenuon = false;
        }
    }
}
