using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Ship", menuName="Ships/Ship")]
public class ShipData : ScriptableObject {

    [Header("Info")]
    public new string name;
    public new int price;

    [Header("Prefab")]
    public new GameObject ship;

    [Header("Shooting")]
    public int gunsInstalled;
    [Tooltip("In seconds")] public float fireRate;

    [Header("Maneuvering")]
    public int speed;

    [Header("Survivability")]
    public int lives;

    [Header("In Shop")]
    public bool isBought;
}
