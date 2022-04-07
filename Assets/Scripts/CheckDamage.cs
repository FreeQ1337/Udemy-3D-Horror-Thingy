using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDamage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.H) ) 
         {
           PlayerValues.HPchange(-10);
           GetComponent<DisplayHealth>().UpdateHP();
         }
    }
}
