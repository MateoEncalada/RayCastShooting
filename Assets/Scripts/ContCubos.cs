using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ContCubos : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI conteoText;
    private int cubosElim = 0;
    public void CubosElim()
    {
        cubosElim++;
        Actualizar();
    }
    private void Actualizar()
    {
        conteoText.text = "Cubos Eliminados: " + cubosElim;
    }

}
