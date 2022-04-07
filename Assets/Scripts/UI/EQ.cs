using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EQ : MonoBehaviour
{

    [SerializeField] GameObject Inventory;
    [SerializeField] GameObject Player;
    [SerializeField] List<GameObject> ApplesButtons;
    [SerializeField] List<GameObject> BatteriesButtons;
    [SerializeField] Image Bateryjka;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && !Inventory.activeSelf) 
        {
            Inventory.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0; // pauzuje gre
            Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false; // razem z namespace bo skrypt tego używa, inaczej nie znajdzie komponentu

                UpdateEQ(); 

        }else if(Input.GetKeyDown(KeyCode.I))
            {
              Inventory.SetActive(false);
              Cursor.visible = false;
              Time.timeScale = 1; // unpauzuje gre
              Player.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true; // razem z namespace bo skrypt tego używa, inaczej nie znajdzie komponentu
            }
    }

   public void UpdateEQ() // aktywuje badz dezaktywuje komorki w EQ odpowiadajace za japczany (sa w liscie)
    {
        for (int i=0; i<6 ; i++) // lecimy po wszystkich 6 pozycjach sprawdzajac czy powinny byc aktywne czy nie... boze pozdro z reszta EQ...
        {
            ApplesButtons[i].SetActive(true);

            if(i>PlayerValues.Apples -1) // -1 bo list liczy od 0 nie od 1, jednocześnie list nie przyjmuje wartosci ujemnych wiec sprawdzamy wczesniej zeby w ApplesButtons[i] nie wjebac w "i" wartosci ujemnej
            {
                ApplesButtons[i].SetActive(false);
            }
        }

        for (int i=0; i<4 ; i++) // lecimy po wszystkich 6 pozycjach sprawdzajac czy powinny byc aktywne czy nie... boze pozdro z reszta EQ...
        {
            BatteriesButtons[i].SetActive(true);

            if(i>PlayerValues.Batteries -1) // -1 bo list liczy od 0 nie od 1, jednocześnie list nie przyjmuje wartosci ujemnych wiec sprawdzamy wczesniej zeby w ApplesButtons[i] nie wjebac w "i" wartosci ujemnej
            {
                BatteriesButtons[i].SetActive(false);
            }
        }
    }

    public void UseApple() // minusik na jableczka i wywoluje funkcje leczonka oraz update EQ
    {
        PlayerValues.Apples -=1;
        PlayerValues.HPchange(25);
        UpdateEQ();
    }

    public void UseBattery() // minusik na jableczka i wywoluje funkcje leczonka oraz update EQ
    {
        PlayerValues.Batteries -=1;
        Bateryjka.fillAmount += 0.25f;
        UpdateEQ();
    }
}
