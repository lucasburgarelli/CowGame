using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player : Person
{
    public Transform TransformCamera;
    public float JumpForce = 1200;
    public float SlowMotionEnergy = 1000;
    [HideInInspector] public bool IsShooting, IsMoving, OnSlowMotion, IsJumpAllowed;
}
