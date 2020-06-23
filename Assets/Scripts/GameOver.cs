using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
    }

    void Update()
    {
        if (Game.CurrentState == GameState.Dead)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
        }
    }
}
