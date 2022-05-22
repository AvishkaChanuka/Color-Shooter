using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    [SerializeField] float maxPos = 5.25f;
    public enum color { Blue, Red, Yellow };
    public color bulletColor;
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        Destroy();
    }

    void Destroy()
    {
        if(transform.position.x>maxPos || transform.position.x < -maxPos || transform.position.z > maxPos || transform.position.z < -maxPos)
        {
            Destroy(gameObject);
        }
    }
}
