using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePedestal : MonoBehaviour, IPedestal
{
    public string ActString;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;
    }

    public void LetKey(KeyCode key)
    {
        spriteRenderer.color = Color.yellow;
        if (GameInputManager.Instance != null)
        {
            GameInputManager.Instance.RemoveKeyMap(ActString);
        }
    }

    public void SetKey(KeyCode key)
    {
        spriteRenderer.color = Color.red;
        GameInputManager.Instance.SetKeyMap(ActString, key);
    }
}
