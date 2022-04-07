using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker_LightPost : MonoBehaviour
{
    Light PostLight;
    GameObject Bulb;
    Material BulbMaterial;

	public float minFlickerTime = 0.1f;
	public float maxFlickerTime = 0.04f;
    public float minIntensity = 0.8f;
    public float maxIntensity = 2.0f;
	// Use this for initialization
	void Start () {
		PostLight = GetComponent<Light> (); // getuje swiatelko
        Bulb = PostLight.transform.parent.gameObject; // bulb jako zarowa z emisja
        BulbMaterial = Bulb.GetComponent<Renderer>().material; // Getuje material z bulba
	
		StartCoroutine (Flashing ());
	}

	IEnumerator Flashing(){
		while (true) {

            if (PostLight.enabled == false)
            {
			    yield return new WaitForSeconds (Random.Range(minFlickerTime,maxFlickerTime));
			    PostLight.intensity = Random.Range(minIntensity,maxIntensity);
			    PostLight.enabled = !PostLight.enabled; // switchuje state swiatla
                BulbMaterial.EnableKeyword("_EMISSION"); // wlaczqa emisje (czyli zarowe nasza)
            }else
            {
                yield return new WaitForSeconds (Random.Range(minFlickerTime*0.2f, maxFlickerTime*0.2f));
                PostLight.enabled = !PostLight.enabled;
                BulbMaterial.DisableKeyword("_EMISSION"); // wylacza emisje
            }
		}
	}
}
