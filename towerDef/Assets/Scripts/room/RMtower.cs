using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class RMtower : MonoBehaviour
{
    public NetworkRoomManager t;
    
    public void sethost(Text r)
    {
        t.networkAddress = r.text;
    }
}
