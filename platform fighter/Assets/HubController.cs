using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour{
    public static bool popupteston = false;
    public GameObject popuptest;
    public static bool exitmenuon = false;
    public GameObject exitmenu;
    void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            Debug.Log("ass");
        }
        if(popupteston){
            popuptest.SetActive(true);
        }else{
            popuptest.SetActive(false);
        }
        if(exitmenuon){
            exitmenu.SetActive(true);
        }else{
            exitmenu.SetActive(false);
        }
    }
}
