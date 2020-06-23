using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpArea : MonoBehaviour
{
    public BirdMovement bird;
    void OnMouseDown()
    {
        bird.Jump();
    }
}
