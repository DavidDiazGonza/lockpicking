using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LockPick : MonoBehaviour
{
    public bool isVersion2;
    public bool touching = false;
    public float charge = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    touching = true;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    touching = false;
    //}

    //public void Move(Lock.Side side)
    //{
    //    if (touching)
    //    {
    //        return;
    //    }

    //    if (side == Lock.Side.Right)
    //    {
    //        transform.Rotate(Vector3.down * Time.deltaTime * 20.0f);
    //    }
    //    else
    //    {
    //        transform.Rotate(Vector3.up * Time.deltaTime * 20.0f);
    //    }
    //}

    public void Charge()
    {
       //if (isVersion2)
        //{
            charge++;
        //}
        //else
        //{
        //    charge += Time.deltaTime * 3.5f;
        //}
        if (charge >= 3)
        {
            SceneManager.LoadScene(0);
        }

    }


}
