using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Connection : MonoBehaviour
{
    public Piece piece;
    public bool isInverted = false;

    public Connection(Piece piece, bool isInverted = false)
    {
        this.piece = piece;
        this.isInverted = isInverted;
    }
}

public class Piece : MonoBehaviour
{
    public List <Connection> connections;
    public Material mat;
    public GameObject[] parts = new GameObject[3];
    public bool open = false;
    public bool selected = false;

    public void Start()
    {
        foreach (GameObject part in parts)
        {
            part.GetComponent<MeshRenderer>().material = mat;
        }
    }

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
         else
         {
             mat.color = Color.grey;
             open = false;
         }
    }

    public bool CheckMovement(Lock.Side side)
    {
        if (connections.Count > 0)
        {
            foreach (Connection connection in connections)
            {
                if (!connection.piece.CheckMovement(CheckSide(side, connection.isInverted)))
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
    }

    public void Move(Lock.Side side)
    {
        if (connections.Count > 0)
        {
            foreach (Connection connection in connections)
            {
                connection.piece.Move(CheckSide(side,connection.isInverted));
            }
        }

        if (side == Lock.Side.Right)
        {
            transform.Rotate(Vector3.back*5);
        }
        else
        {
            transform.Rotate(Vector3.forward*5);
        }
    }   

    public Lock.Side CheckSide(Lock.Side side, bool isInverted)
    {
        if (isInverted)
        {
            if (side == Lock.Side.Left)
            {
                return Lock.Side.Right;
            }
            else
            {
                return Lock.Side.Left;
            }
        }

        return side;
    }
}

