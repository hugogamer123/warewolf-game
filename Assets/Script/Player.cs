using Mirror;
using UnityEngine;
using UnityEngine.InputSystem;

namespace DapperDino.Mirror.Tutorials.Ownership
{
    public class Player : NetworkBehaviour
    {
        public void Jump(InputAction.CallbackContext context)
        {
            
        }

        [SerializeField] private Vector3 movement = new Vector3();

        [Client]
        private void Update()
        {
            if (!isOwned) { return; }

            //if (!Input.GetKeyDown(KeyCode.Space)) { return; }

            //transform.Translate(movement);

            CmdMove();
        }

        [Command]
        private void CmdMove()
        {
            // Validate logic here

            RpcMove();
        }

        [ClientRpc]
        private void RpcMove() => transform.Translate(movement);
    }
}
