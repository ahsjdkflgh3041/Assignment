using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public bool isGrab = false;
    private float boxCheckRange = 2f;
    [SerializeField]
    private SpriteRenderer playerSpriteRenderer;
    [SerializeField]
    private LayerMask boxLayer;
    [SerializeField]
    private Transform grabPosition;
    [SerializeField]
    private GameObject grabBox;
    private Rigidbody2D grabRigidbody;
    private SpriteRenderer grabRenderer;
    private float letForce = 7f;
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        distance = float.MaxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameInputManager.Instance.keyMapping.ContainsKey("Grab"))
        {
            if (grabBox == null)
            {
                Collider2D[] compareBoxes = Physics2D.OverlapCircleAll(transform.position, boxCheckRange, boxLayer);
                if (compareBoxes != null)
                {
                    foreach (Collider2D var in compareBoxes)
                    {
                        if (Vector2.Distance(transform.position, var.transform.position) < distance)
                        {
                            if (grabBox != null)
                            {
                                grabRenderer = grabBox.GetComponent<SpriteRenderer>();
                                grabRenderer.color = Color.white;
                            }
                            grabBox = var.gameObject;
                            distance = Vector2.Distance(transform.position, var.transform.position);
                        }
                    }
                }
            }
            else
            {
                grabRenderer = grabBox.GetComponent<SpriteRenderer>();
                grabRenderer.color = Color.cyan;

                if (Vector2.Distance(this.transform.position, grabBox.transform.position) > boxCheckRange)
                {
                    distance = float.MaxValue;
                    grabBox = null;
                    grabRenderer.color = Color.white;
                    grabRenderer = null;
                }
                if (GameInputManager.Instance.GetKeyDown("Grab"))
                {
                    if (!isGrab)
                    {
                        Grab();
                    }
                    else
                    {
                        Let();
                    }
                }
            }
        }
    }

    private void Grab()
    {
        isGrab = true;
        grabRigidbody = grabBox.GetComponent<Rigidbody2D>();
        grabRigidbody.gravityScale = 0f;
    }

    private void Let()
    {
        distance = float.MaxValue;
        grabRigidbody.gravityScale = 1f;
        if (playerSpriteRenderer.flipX)
        {
            grabRigidbody.AddForce(Vector2.left * (letForce - 5), ForceMode2D.Impulse);
        }
        else
        {
            grabRigidbody.AddForce(Vector2.right * (letForce - 5), ForceMode2D.Impulse);
        }
        grabRigidbody.AddForce(Vector2.up * letForce, ForceMode2D.Impulse);
        grabBox = null;
        isGrab = false;
    }

    private void FixedUpdate()
    {
        if (GameInputManager.Instance.keyMapping.ContainsKey("Grab"))
        {
            if (isGrab)
            {
                grabBox.transform.position = grabPosition.position;
            }
        }
        else if (isGrab)
        {
            distance = float.MaxValue;
            grabRigidbody.gravityScale = 1f;
            grabBox = null;
            isGrab = false;
            grabRenderer.color = Color.white;
        }
    }
}
