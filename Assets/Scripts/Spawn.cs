using UnityEngine;

public class Spawn : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Random.Range(0, 100) < 3)
        {
            GameObject b = Pool.singleton.Get("asteroid");
            if (b != null)
            {
                b.transform.position =  transform.position + new Vector3(Random.Range(-10, 11), 0, 0);
                b.SetActive(true);
            }

        }
    }
}
