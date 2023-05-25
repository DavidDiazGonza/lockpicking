using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lock : MonoBehaviour
{
    public bool isVersion2;
    public Piece[] pieces;
    private int index = 0;
    public GameObject locker;

    public bool open = false;

    public LockPick lockPick;
    private Color lockpickColor;

    public GameObject leftWall;
    public GameObject rightWall;

    public enum Side
    {
        Right,
        Left
    }

    void Start()
    {
        pieces[index].selected = true;
        lockpickColor = lockPick.GetComponent<MeshRenderer>().material.color;
    }

    // Update is called once per frame
    void Update()
    {
        if(open)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if(index+1 < pieces.Length)
            {
                pieces[index].selected = false;
                index++;
                pieces[index].selected = true;
                float position = -2.9f + (index * 0.5f);
                lockPick.transform.DOMoveZ(position, 0.5f);
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (index - 1 >= 0)
            {
                pieces[index].selected = false;
                index--;
                pieces[index].selected = true;
                float position = -2.9f + (index * 0.5f);
                lockPick.transform.DOMoveZ(position, 0.5f);
            }
        }
        //if (isVersion2)
        //{
            if (Input.GetKeyDown(KeyCode.D))
            {
                if (CheckMovement(Side.Right))
                {
                    Move(Side.Right);
                    lockPick.GetComponent<MeshRenderer>().material.color = lockpickColor;
                }

                else
                {
                    Sequence mySequence = DOTween.Sequence();
                    mySequence.Append(lockPick.transform.DOShakeRotation(0.75f, 0.75f));
                    mySequence.Join(lockPick.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.75f));
                    mySequence.Join(rightWall.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.75f));
                    mySequence.Join(rightWall.transform.DOShakeRotation(0.75f, 0.75f));
                    mySequence.Append(lockPick.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.75f).OnComplete(Charge));
                    mySequence.Join(rightWall.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.75f));
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                if (CheckMovement(Side.Left))
                {
                    Move(Side.Left);
                    lockPick.GetComponent<MeshRenderer>().material.color = lockpickColor;
                }
                else
                {
                    Sequence mySequence = DOTween.Sequence();
                    mySequence.Append(lockPick.transform.DOShakeRotation(0.75f, 0.75f));
                    mySequence.Join(lockPick.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.75f));
                    mySequence.Join(leftWall.GetComponent<MeshRenderer>().material.DOColor(Color.red, 0.75f));
                    mySequence.Join(leftWall.transform.DOShakeRotation(0.75f, 0.75f));
                    mySequence.Append(lockPick.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.75f).OnComplete(Charge));
                    mySequence.Join(leftWall.GetComponent<MeshRenderer>().material.DOColor(Color.white, 0.75f));
                }
            }
        //}
        //else
        //{
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        if (CheckMovement(Side.Right))
        //        {
        //            Move(Side.Right);
        //            lockPick.GetComponent<MeshRenderer>().material.color = lockpickColor;
        //        }
        //        else
        //        {
        //            lockPick.GetComponent<MeshRenderer>().material.color = Color.red;
        //            Charge();

        //        }
        //    }
        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        if (CheckMovement(Side.Left))
        //        {
        //            Move(Side.Left);
        //            lockPick.GetComponent<MeshRenderer>().material.color = lockpickColor;

        //        }
        //        else
        //        {
        //            Charge();
        //            lockPick.GetComponent<MeshRenderer>().material.color = Color.red;
        //        }
        //    }
        //}
        

        foreach(Piece piece in pieces)
        {
            if(!piece.open)
            {
                return;
            }
        }

        open = true;
        locker.transform.GetComponent<Animation>().Play();
    }

    public void Charge()
    {
        lockPick.Charge();
    }

    public bool CheckMovement(Side side)
    {
        return pieces[index].CheckMovement(side);
    }

    public void Move(Side side)
    {
        pieces[index].Move(side);
        //lockPick.Move(side);
    }
}
