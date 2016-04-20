using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float bulletSpeed;
    Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed);
	}

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }
}
