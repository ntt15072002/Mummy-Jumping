using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Startring,
    Playing,
    Gameover
}

public enum GameTag
{
    Platform,
    Player,
    Leftcorner,
    Rightcorner,
    Collectable
}

public enum PrefKey
{
    BestScore
}

[System.Serializable]

public class CollectableItem
{
    public Collectable collectablePreFb;
    [Range(0f, 1f)]
    public float spawnRate;
}