using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockPick : MonoBehaviour
{
    public bool touching = false;
    public float charge = 0;

    public void Charge()
    {
        charge++;
        
        if (charge >= 3)
        {
            SceneManager.LoadScene(0);
        }

    }


}
