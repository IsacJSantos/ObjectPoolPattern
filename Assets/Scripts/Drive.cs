﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    public float speed = 10.0f;

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
    }
}