using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyFadeOut : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public float fadeSpeed = 1f;
    private float opacity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Game.CurrentState != GameState.Menu)
        {
            spriteRenderer.color = new Color(1f, 1f, 1f, opacity);

            if (opacity > 0)
            {
                opacity -= fadeSpeed * Time.deltaTime;
            }
            else
            {
                opacity = 0;
            }
        }
    }
}
