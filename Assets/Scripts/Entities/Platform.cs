using System;
using UnityEngine;

[Serializable]
public class Platform : Entity
{
    public Vector2 RotationMultipliers = new Vector2(1, 1);
    [HideInInspector] public Vector2 StartingPosition;
    [Range(0.01f, 2)]public float Speed = 1;
}
