using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private GameObject connected;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(0f / 255f, 255f / 255f, 255f / 255f, 65f / 255f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        spriteRenderer.color = new Color(255f / 255f, 167f / 255f, 0f / 255f, 65f / 255f);
        connected.GetComponent<IConnectedObstacles>().Use();
 
    }
}
