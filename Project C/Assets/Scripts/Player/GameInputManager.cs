using UnityEngine;
using System.Collections.Generic;

public class GameInputManager : MonoBehaviour
{
    private static GameInputManager instance = null;

    void Awake()
    {
        if (null == instance)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public static GameInputManager Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    public Dictionary<string, KeyCode> keyMapping;

    private void OnEnable()
    {
        keyMapping = new Dictionary<string, KeyCode>();
    }

    public void SetKeyMap(string keyMap, KeyCode key)
    {
        if (keyMapping == null || !keyMapping.ContainsKey(keyMap))
        {
            keyMapping.Add(keyMap, key);
        }
        else
        {
            keyMapping[keyMap] = key;
        }
    }

    public void RemoveKeyMap(string keyMap)
    {
        if (keyMapping.ContainsKey(keyMap))
        {
            keyMapping.Remove(keyMap);
        }
    }

    public bool GetKeyDown(string keyMap)
    {
        if (keyMapping != null && keyMapping.ContainsKey(keyMap))
            return Input.GetKeyDown(keyMapping[keyMap]);
        else
        {
            return false;
        }
    }

    public bool GetKey(string keyMap)
    {
        if (keyMapping != null && keyMapping.ContainsKey(keyMap))
            return Input.GetKey(keyMapping[keyMap]);
        else
            return false;
    }
}
