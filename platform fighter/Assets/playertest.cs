using Mirror;
using UnityEngine;

namespace QuickStart{
    public class playertest : NetworkBehaviour{
        public override void OnStartLocalPlayer(){

        }

        void Update(){
            if (!isLocalPlayer) { return; }

            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4f;
            float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4f;

            transform.Translate(moveX, moveY,0);
        }
    }
}