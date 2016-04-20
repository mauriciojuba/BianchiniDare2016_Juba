using UnityEngine;
using System.Collections;

public class Enemy : LivingObject {
    
	void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Bullet"))
        {
            this.TakeDamage(Random.Range(0, 100));
            CameraShake.Instance.Shake(0.1f, 0.2f);
        }
    }
}
