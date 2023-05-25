using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Piece : MonoBehaviour
{
    public bool isVersion2;
    public Piece[] pieces;
    public Material mat;
    // Start is called before the first frame update
    public bool open = false;
    public bool selected = false;

    public float speed;
    void Start()
    {
        speed = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.rotation.z <= 0.02f && transform.rotation.z >= -0.02f)
        {
            mat.color = Color.green;
            open = true;
         }
         else if (selected)
         {
            mat.color = Color.blue;
            open = false;
         }
         //else if(((Input.GetKey(KeyCode.D) && transform.rotation.z <= -0.1736482f) || (Input.GetKey(KeyCode.A) && transform.rotation.z >= 0.1736482f)) && isVersion2)
         //{
         //   Debug.LogError(transform.rotation.z);
         //   mat.color = Color.red;
         //   open = false;
         //}
         else
         {
             mat.color = Color.grey;
             open = false;
         }

         if (Input.GetKey(KeyCode.LeftShift))
         {
            speed = 12;
         }
         else
         {
            speed = 6;
         }
    }

    public bool CheckMovement(Lock.Side side)
    {
        //if (isVersion2)
        //{
            if (pieces.Length > 0)
            {
                foreach (Piece piece in pieces)
                {
                    if (!piece.CheckMovement(side))
                    {
                        return false;
                    }
                }
            }

            if (side == Lock.Side.Right)
            {
                if (transform.rotation.z >= -0.1736482f)
                {
                    return true;
                }
            }
            else
            {
                if (transform.rotation.z <= 0.1736482f)
                {
                    return true;
                }
            }
            this.mat.DOColor(Color.red, 1);

            return false;
        //}
        //else
        //{
        //    if (pieces.Length > 0)
        //    {
        //        foreach (Piece piece in pieces)
        //        {
        //            if (!piece.CheckMovement(side))
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    if (side == Lock.Side.Right)
        //    {
        //        if (transform.rotation.z > -0.24f)
        //        {
        //            return true;
        //        }
        //    }
        //    else
        //    {
        //        if (transform.rotation.z < 0.24f)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
    }

    public void Move(Lock.Side side)
    {
        //if (isVersion2)
        //{
            if (pieces.Length > 0)
            {
                foreach (Piece piece in pieces)
                {
                    piece.Move(side);
                }
            }

            if (side == Lock.Side.Right)
            {
                //transform.Rotate(Vector3.forward, -5);
                transform.Rotate(Vector3.back*5);
            }
            else
            {
                //transform.Rotate(Vector3.forward, 5);
                transform.Rotate(Vector3.forward*5);
            }
        //}
        //else
        //{
        //    if (pieces.Length > 0)
        //    {
        //        foreach (Piece piece in pieces)
        //        {
        //            piece.Move(side);
        //        }
        //    }

        //    if (side == Lock.Side.Right)
        //    {
        //        transform.Rotate(Vector3.back * Time.deltaTime * speed);
        //    }
        //    else
        //    {
        //        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
        //    }
        //}
    }   
}

