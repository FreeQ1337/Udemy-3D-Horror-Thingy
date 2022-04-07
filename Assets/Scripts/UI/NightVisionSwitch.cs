using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class NightVisionSwitch : MonoBehaviour
{

    [SerializeField] PostProcessVolume PPVolume;
    [SerializeField] PostProcessProfile Standard;
    [SerializeField] PostProcessProfile NightVision;
    [SerializeField] Image Overlay;
    [SerializeField] Image Battery;
    Coroutine DrainNV;
    [SerializeField] float NVDrainSpeed = 15.0f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N) && PPVolume.profile==Standard){
            PPVolume.profile = NightVision;
            Overlay.enabled = true;
            DrainNV = StartCoroutine(BatteryDrain(Battery));

        }else if(Input.GetKeyDown(KeyCode.N)) // tu wywala błąd bo chce wylaczyc corotyne chociaz jej nie ma jeszcze za pierwszym razem jak się "N" kliknie. i wonder why...
            {
                PPVolume.profile = Standard;
                Overlay.enabled = false;
                StopCoroutine(DrainNV);
            }
       

    }

     IEnumerator BatteryDrain (Image ImgFill) // code reuse later in the coroutine, bad practice i guess, will change later or sth...
    {
        while(true)
        {
        ImgFill.fillAmount -= 1.0f / NVDrainSpeed * Time.deltaTime; // zmniejsza fill baterii zależnie od parametru DrainSpeed pomnożone przez faktyczny czas jaki upłynął (inaczej zależnie od fps będzie prędkość drain)
        if(ImgFill.fillAmount <= 0)  // jak fill dojdzie do 0 wylaczamy latare i wylaczamy corotynke zeby nam procka nie zjadało bo po chuj
        {
            PPVolume.profile = Standard;
            Overlay.enabled = false;
            StopCoroutine(DrainNV);
        }
        yield return ImgFill;
        }
    }

}
