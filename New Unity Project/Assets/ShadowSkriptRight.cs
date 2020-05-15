using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ShadowSkriptRight : MonoBehaviour
{
    float yNeu;
    float xNeu;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yNeu = transform.position.y + 70 * Time.deltaTime;
        xNeu = transform.position.x + 2.0f;
        transform.position = new Vector3(xNeu, yNeu, 0);
        if (yNeu > 200.2f)
        {
            transform.position = new Vector3(-36.0f, 3.1f, 0);
        }

    }
}