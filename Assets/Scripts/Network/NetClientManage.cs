using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetClientManage : MonoBehaviour
{
    public static NetClientManage instance;
    public NetConnect netConnect;

    void Start()
    {
        instance = this;
        netConnect = new NetConnect();
        netConnect.Connect();
    }

    void Update()
    {
        
    }
}
