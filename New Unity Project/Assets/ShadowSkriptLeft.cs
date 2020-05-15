using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class ShadowSkriptLeft : MonoBehaviour
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
        xNeu = transform.position.x - 1.5f;
        transform.position = new Vector3(xNeu, yNeu, 0);
        if (yNeu > 200.2f)
        {
            transform.position = new Vector3(-34.3f, -9.2f, 0);
        }

    }
}
