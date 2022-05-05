using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 velocity;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
           collision.gameObject.SetActive(false);
        }    
    }

    void Update()
    {
        transform.Translate(velocity);
    }

    
}
