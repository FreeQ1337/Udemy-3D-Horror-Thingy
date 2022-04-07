using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class FlashlightToggle : MonoBehaviour
{
    [SerializeField] Light Flashlight;
    [SerializeField] Image BatteryFill;
    [SerializeField] float DrainSpeed = 15.0f;
    Coroutine Drain;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Flashlight.enabled == false) {

                Flashlight.enabled=true;
                Drain = StartCoroutine (BatteryDrain(BatteryFill)); // Startuje animacje draina baterii

            }else if(Input.GetKeyDown(KeyCode.F))
            {
                Flashlight.enabled=false;
                StopCoroutine (Drain); // wylacza corotynke zeby bateria sie nie zyzywala jak wylaczymy
            }
        
    }

    IEnumerator BatteryDrain (Image ImgFill)
    {
        while(true)
        {
        ImgFill.fillAmount -= 1.0f / DrainSpeed * Time.deltaTime; // zmniejsza fill baterii zależnie od parametru DrainSpeed pomnożone przez faktyczny czas jaki upłynął (inaczej zależnie od fps będzie prędkość drain)
        if(ImgFill.fillAmount <= 0)  // jak fill dojdzie do 0 wylaczamy latare i wylaczamy corotynke zeby nam procka nie zjadało bo po chuj
        {
            Flashlight.enabled=false;
            StopCoroutine(Drain);
        }
        yield return ImgFill;
        }
    }
}
