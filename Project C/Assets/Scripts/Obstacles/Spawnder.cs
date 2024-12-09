using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnder : MonoBehaviour, IConnectedObstacles
{
    [SerializeField]
    private GameObject spawn;

    public void Use()
    {
        Instantiate(spawn, transform.position, transform.rotation);
    }
}
