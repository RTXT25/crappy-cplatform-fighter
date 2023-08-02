using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour{
    public static bool popupteston = false;
    public GameObject popuptest;
    void Start(){
        
    }
    void Update(){
        if(popupteston){
            popuptest.SetActive(true);
        }else{
            popuptest.SetActive(false);
        }
    }
}
