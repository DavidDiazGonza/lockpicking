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

        UpdateColor();
    }

    public bool CheckMovement(Lock.Side side)
    {
        if (connections.Count > 0)
        {
            foreach (Connection connection in connections)
            {
                if (!connection.piece.CheckMovement(CheckSide(side, connection.isInverted)))
                {
                    //this.mat.DOColor(Color.red, 1).OnComplete(UpdateColor);
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

        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(this.mat.DOColor(Color.red, 1).OnComplete(UpdateColor));
        Lock tempLock = GameObject.Find("Lock").GetComponent<Lock>();
        if(side == Lock.Side.Right)
        {
            mySequence.Join(tempLock.rightWall.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.75f));
            mySequence.Join(tempLock.rightWall.transform.DOShakeRotation(0.75f, 0.75f));
            mySequence.Append(tempLock.rightWall.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.75f));
        }
        else
        {
            mySequence.Join(tempLock.leftWall.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.75f));
            mySequence.Join(tempLock.leftWall.transform.DOShakeRotation(0.75f, 0.75f));
            mySequence.Append(tempLock.leftWall.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.75f));
        }

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

        UpdateColor();
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

    public void UpdateColor()
    {
        if (transform.rotation.z <= 0.02f && transform.rotation.z >= -0.02f)
        {
            mat.color = Color.green;
            open = true;
        }
        else
        {
            mat.color = Color.grey;
            open = false;
        }

        for(int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<Outline>().enabled = selected;
        }
    }
}

