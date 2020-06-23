using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    private bool hitted = false;
    private float opacity = 1f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (hitted)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, opacity);
            opacity -= 4 * Time.deltaTime;
        }
        else if (Game.CurrentState == GameState.Dead)
        {
            hitted = true;
        }
        else
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, 0f);
        }
    }
}
