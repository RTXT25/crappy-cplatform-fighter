using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green : MonoBehaviour{
    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            HubController.popupteston = true;
        }
    }
    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            HubController.popupteston = false;
        }
    }
}
