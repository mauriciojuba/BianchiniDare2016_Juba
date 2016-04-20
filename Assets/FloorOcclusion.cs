using UnityEngine;
using System.Collections;

public class FloorOcclusion : MonoBehaviour {

    public GameObject FirstFloor, SecondFloor, ThirdFloor;
    public Transform Player;
    bool isInside;
	
    void Update()
    {
        Debug.Log(isInside);
        if (isInside)
        {
            if (Player.position.y >= 3f)
            {
                FirstFloor.SetActive(true);
                SecondFloor.SetActive(false);
                ThirdFloor.SetActive(false);
                if (Player.position.y >= 7f)
                {
                    SecondFloor.SetActive(true);
                    FirstFloor.SetActive(true);
                }
            }
            else
            {
                FirstFloor.SetActive(false);
                SecondFloor.SetActive(false);
                ThirdFloor.SetActive(false);
            }

            //y3 = 2andar
            //y7 = 3andar
        }
        else
        {
            FirstFloor.SetActive(true);
            SecondFloor.SetActive(true);
            ThirdFloor.SetActive(true);
        }
    }

    void OnTriggerStay(Collider hit)
    {
        if (hit.CompareTag("Player")) isInside = true;
    }
    void OnTriggerExit(Collider hit)
    {
        if (hit.CompareTag("Player")) isInside = false;
    }
}
