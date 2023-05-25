using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceBackUp : MonoBehaviour
{
    // public Piece[] pieces;
    // public Material mat;
    // // Start is called before the first frame update
    // public bool open = false;
    // public bool selected = false;
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     if(transform.position.x <= 0.02f && transform.position.x >= -0.02f)
    //     {
    //         mat.color = Color.green;
    //         open = true;
    //     }
    //     else if(selected)
    //     {
    //         mat.color = Color.blue;
    //         open = false;

    //     }
    //     else
    //     {
    //         mat.color = Color.red;
    //         open = false;
    //     }
    // }

    // public bool CheckMovement(bool side)
    // {
    //     if(pieces.Length  > 0)
    //     {
    //         foreach (Piece piece in pieces)
    //         {
    //             if(!piece.CheckMovement(side))
    //             {
    //                 return false;
    //             }
    //         }
    //     }

    //     if(side)
    //     {
    //         if(transform.position.x < 1)
    //         {
    //             return true;
    //         }
    //     }
    //     else
    //     {
    //         if(transform.position.x > -1)
    //         {
    //             return true;
    //         }
    //     }
    //     return false;
    // }

    // public void Move(bool side)
    // {
    //     if(pieces.Length  > 0)
    //     {
    //         foreach (Piece piece in pieces)
    //         {
    //             piece.Move(!side);
    //         }
    //     }

    //     if(side)
    //     {
    //         transform.Translate(Vector3.right * Time.deltaTime  * 1.0f);
    //     }
    //     else
    //     {
    //         transform.Translate(Vector3.left * Time.deltaTime  * 1.0f);
    //     }
    // }   
}

