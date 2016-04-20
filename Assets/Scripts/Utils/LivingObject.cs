using UnityEngine;
using System.Collections;

public class LivingObject : MonoBehaviour {

    public int Health;

    void Start()
    {
    }

    public virtual void TakeDamage(int amount)
    {
        FloatingTextController.Instance.CreateFloatingText(amount.ToString(), transform);
        if ((Health -= amount) <= 0)
            Die();
    }
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
