using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractPedestal : MonoBehaviour, IPedestal
{
    public IConnectedObstacles actObject;
    public KeyCode activeKey;

    public void LetKey(KeyCode key)
    {
        activeKey = KeyCode.None;
    }

    public void SetKey(KeyCode key)
    {
        activeKey = key;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(activeKey))
        {
            actObject.Use();
        }
    }
}
