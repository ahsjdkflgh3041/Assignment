using UnityEngine;

public class Blocks : MonoBehaviour
{
    public KeyCode keyCode;
    private IPedestal closePelestal;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pedestal"))
        {
            closePelestal = collision.gameObject.GetComponent<IPedestal>();
            if (closePelestal != null)
            {
                closePelestal.SetKey(keyCode);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pedestal"))
        {
            if (closePelestal != null)
            {
                closePelestal.LetKey(keyCode);
                closePelestal = null;
            }
        }
    }
}
