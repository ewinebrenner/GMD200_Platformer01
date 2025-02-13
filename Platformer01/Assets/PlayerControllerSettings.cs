using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Controller Settings", 
    menuName = "Platformer/Player Settings")]
public class PlayerControllerSettings : ScriptableObject
{
    public float moveSpeed = 6.0f;
    public float jumpSpeed = 12.0f;
    public LayerMask groundLayer;
    public float groundCheckDistance = 1.5f;
    public Item startingItem;
}
