using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighhouse_Rotation : MonoBehaviour
{
   [SerializeField] GameObject Lighthouse;
   [SerializeField] float Rot_speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Lighthouse.transform.Rotate(0,Rot_speed,0,Space.World);
    }
}
