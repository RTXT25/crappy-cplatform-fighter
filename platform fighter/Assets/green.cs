using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class green : MonoBehaviour{
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Debug.Log("ass");
        }
    }
}
