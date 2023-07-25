using Mirror;
using UnityEngine;

namespace QuickStart{
    public class playertest : NetworkBehaviour{
        bool isGround = true;
        public override void OnStartLocalPlayer(){

        }

        void Update(){
            if (!isLocalPlayer) { return; }

            float moveX = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 4f;
            float moveY = Input.GetAxisRaw("Vertical") * Time.deltaTime * 4f;

            //gravity
            //if(isGround == true){
            //moveY = moveY - 10 * Time.deltaTime;
            //}

            transform.Translate(moveX, moveY,0);
        }
    }
}