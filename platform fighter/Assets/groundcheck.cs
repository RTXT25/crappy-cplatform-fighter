using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour{
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("solidplat") || other.gameObject.CompareTag("semisolid")){
            move.jumpsLeft = move.maxJumps;
        }   
    }
}