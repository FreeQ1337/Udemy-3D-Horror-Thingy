using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerValues : MonoBehaviour
{
    
    public static int Health = 100; // HP gracza (storuje do ramu, gracz jest jeden więc nie ma sensu robić z tego klasy doh)
    public static int Apples = 0;
    public static int Batteries = 0;
   
   public static void HPchange (int change) 
   {
    PlayerValues.Health += change;
    if (PlayerValues.Health>=100)
    {
        PlayerValues.Health = 100;
    }
    
   }
}
