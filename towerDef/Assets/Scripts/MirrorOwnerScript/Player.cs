using UnityEngine;

namespace Mirror.test.owner
{
    public class Player : NetworkBehaviour
    {
        [SerializeField] private Vector3 movement = new Vector3();

        [Client]
        private void Update()
        {
            if (!hasAuthority) { return; }

            if (!Input.GetKeyDown(KeyCode.Space)) { return; }
            
            CmdMove();
        }

        [Command]
        private void CmdMove()
        {
           RpcMove();
        }

        [ClientRpc]
        private void RpcMove() => transform.Translate(movement);
    }
}

