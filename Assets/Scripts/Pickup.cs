using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] float RayDistance;
    [SerializeField] GameObject PickupUI;
    int maska = 1 << 7; //layer pickupa, żeby raycast sam w siebie nie napieralal (akurat ID maski 7 to maska "PickUp")


    void FixedUpdate()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hit,RayDistance, maska) && ((hit.transform.tag == "Apple") || (hit.transform.tag == "Battery")))
        {
            PickupUI.SetActive(true);
            if(Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.tag == "Apple"  && PlayerValues.Apples < 6)
                {
                Destroy(hit.transform.gameObject); // niszczy japko ktore raycast udeza 
                PlayerValues.Apples += 1; // ilość jabłeczków
                }

                if(hit.transform.tag == "Battery"  && PlayerValues.Batteries < 4)
                {
                Destroy(hit.transform.gameObject); // niszczy japko ktore raycast udeza 
                PlayerValues.Batteries += 1; // ilość jabłeczków
                }
                
            }
        }else
            {
                PickupUI.SetActive(false);
            }
    }
}
