using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HubController : MonoBehaviour{
    public static bool popupteston = false;
    public GameObject popuptest;
    public static bool exitmenuon = false;
    public GameObject exitmenu;
    public static bool hubmenuon = false;
    public GameObject hubmenu;
    void Update(){
        if(Input.GetKey(KeyCode.Escape)){
            hubmenu.SetActive(true);
        }else{
            hubmenu.SetActive(false);
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
