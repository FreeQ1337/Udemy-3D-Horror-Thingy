using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour
{
    public Text DisplayedHP; 
    

    void Start()
    {
        DisplayedHP.text = PlayerValues.Health.ToString(); // zamienia int na string bo drze morde konsola
    }
 
    public void UpdateHP() // wywołujemy z metody w PlayerValues celem aktualizacji UI.
    {
        DisplayedHP.text = PlayerValues.Health.ToString();
    }
}
