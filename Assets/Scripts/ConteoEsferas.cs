using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ConteoEsferas : MonoBehaviour
{
    // Start is called before the first frame update
     public TextMeshProUGUI esferasText;
     private int esferasEliminadas = 0;
     public void EsferaEliminada()
     {
        esferasEliminadas++;
        Actualizar();
        
     }
     private void Actualizar()
     {
        esferasText.text="Esferas Eliminadas: " + esferasEliminadas;
     }

}
