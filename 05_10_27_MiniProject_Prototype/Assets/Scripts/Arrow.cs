using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody rb;

    bool hitSomething;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, 10 * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(!hitSomething)
        {
            transform.forward = Vector3.Slerp(transform.forward, rb.velocity.normalized, 10 * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Arrow")
        {
            hitSomething = true;
            ArrowStick();
            transform.GetComponent<Collider>().isTrigger = true;
        }
    }

    private void ArrowStick()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
        Destroy(gameObject, 2f);
    }
}
