using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootingSettings", menuName = "ScriptableObjects/ShootingSettings", order = 1)]
public class ShootingSettings : ScriptableObject
{
    public float ShootDelay = 0.4f;
}
