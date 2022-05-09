using UnityEngine.UI;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;
    public Slider healthbar;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "asteroid")
        {
            healthbar.value -= 30;
            if (healthbar.value <= 0)
            {
                Destroy(healthbar.gameObject,0.1f);
                Destroy(gameObject, 0.1f);
            }
        }
    }

    void Update()
    {
        float translation = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        transform.Translate(translation, 0, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Pool.singleton.Get("bullet");
            if (b != null)
            {
                b.transform.position = transform.position;
                b.SetActive(true);
            }
        }

        Vector3 sreenPos = Camera.main.WorldToScreenPoint(transform.position) + new Vector3(0, -35, 0);
        healthbar.transform.position = sreenPos;
    }
}