using UnityEngine;
using System.Collections;

public class FloorInteracable : MonoBehaviour {

    Renderer rend;
    public Material Hit, DontHit, waitFORit;
    bool Hitting;
	void OnEnable()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine("RandomizeColor");
    }
    void OnDisable()
    {
        StopCoroutine("RandomizeColor");
    }
    IEnumerator RandomizeColor()
    {
        while (true)
        {
            this.gameObject.GetComponent<Collider>().enabled = false;
            int i = 0;
            i = Random.Range(0, 100);
            if (i > 60 && !Hitting)
            {
                rend.sharedMaterial = waitFORit;
                Hitting = true;
                yield return new WaitForSeconds(2f);
                rend.sharedMaterial = Hit;
                this.gameObject.GetComponent<Collider>().enabled = true;
            }
            else
            {
                rend.sharedMaterial = DontHit;
                Hitting = false;
            }
            yield return new WaitForSeconds(2f);
        }
    }
    void OnTriggerEnter(Collider hit)
    {
        if (hit.CompareTag("Player"))
        {
            CameraShake.Instance.Shake(0.3f, 0.2f);
            hit.GetComponent<LivingObject>().TakeDamage(Random.Range(0, 30));
        }
        
    }
}
