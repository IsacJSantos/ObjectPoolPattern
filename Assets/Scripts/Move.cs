using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3 velocity;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity);
    }

    
}
