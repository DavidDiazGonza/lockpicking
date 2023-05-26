using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Lock : MonoBehaviour
{
    public int pieceAmount = 3;
    public Piece[] pieces;
    public Material[] materials;
    private int index = 0;
    public GameObject locker;

    public bool open = false;

    public LockPick lockPick;
    private Color lockpickColor;

    public GameObject leftWall;
    public GameObject rightWall;

    public Piece piecePrefab;

    public enum Side
    {
        Right,
        Left
    }

    private void Awake()
    {
        Level level = SaverManager.Load();


        if(level != null)
        {
            pieces = new Piece[level.pieces.Count];
            for (int i = 0; i < level.pieces.Count; i++)
            {
                Piece piece = Instantiate(piecePrefab, new Vector3(0.0f, 0.0f, i * 0.5f), Quaternion.Euler(0, 0, level.pieces[i].rotation));
                piece.mat = materials[i];
                pieces[i] = piece;
            }

            for (int j = 0; j < level.pieces.Count; j++)
            {
                if(level.pieces[j].connections != null)
                {
                    foreach (ConnectionData data in level.pieces[j].connections)
                    {
                        int value = data.piece[data.piece.Length - 1] - '0';
                        Debug.LogError(data.piece + " " + value);
                        pieces[j].connections.Add(new Connection(pieces[value -1], data.isInverted));
                    }
                }
            }
        }
    }

    void Start()
    {
        pieces[index].selected = true;
        lockpickColor = lockPick.GetComponent<MeshRenderer>().material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            List<ConnectionData> connections = new List<ConnectionData>();
            connections.Add(new ConnectionData("piece1", true));

            List<PieceData> entries = new List<PieceData>();
            entries.Add(new PieceData("piece1", 5));
            entries.Add(new PieceData("piece2", 15, connections));
            entries.Add(new PieceData("piece3", -15));
            Level level = new Level("level-1", entries);

            SaverManager.Save(level);
        }


        if (open)
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
    }
}
