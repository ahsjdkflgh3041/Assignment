using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TItle : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            GameManager.Instance.ChangeScene("Stage1");
        }
    }
}
