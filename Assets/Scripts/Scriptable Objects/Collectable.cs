using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Collectable", menuName = "Collectable/New")]
public class Collectable : ScriptableObject
{
    [Header("Attributes")]
    [SerializeField] private int _score;

    public int Score { get => _score; }
}
