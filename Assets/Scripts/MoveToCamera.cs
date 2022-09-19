using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveToCamera : MonoBehaviour
{
    public float speed;
    public int materialIndex;
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < -10)
            Destroy(gameObject);
    }
}
