using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CollectorValues", menuName = "Collector")]
public class CollectorScriptable : ScriptableObject
{
    public float CharacterMovementSpeed;
    public float CharacterRotationSpeed;
    public float MovementDelay;
    public float ResponseTime;
}
