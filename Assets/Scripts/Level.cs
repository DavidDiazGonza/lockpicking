using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Level
{
    public string levelName;
    public string difficulty;
    public List<PieceData> pieces;

    public Level(string levelName = "levelName", string difficulty = "difficulty",  List<PieceData> pieces = null)
    {
        this.levelName = levelName;
        this.difficulty = difficulty;
        this.pieces = pieces;
    }
}

[Serializable]
public class PieceData
{
    public string pieceName;
    public int rotation;
    public List<ConnectionData> connections;

    public PieceData(string pieceName, int rotation, List<ConnectionData> connections = null)
    {
        this.pieceName = pieceName;
        this.rotation = rotation;
        this.connections = connections;
    }
}

[Serializable]
public class ConnectionData
{
    public string piece;
    public bool isInverted;

    public ConnectionData(string piece, bool isInverted)
    {
        this.piece = piece;
        this.isInverted = isInverted;
    }
}




