using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float speed = 3f;
    public float beginPosition = -5f;
    public float replayPosition = -13f;

    void Update()
    {
        if (Game.CurrentState != GameState.Dead && Game.CurrentState != GameState.Paused)
        {
            if (transform.position.x <= replayPosition)
            {
                transform.position = new Vector3(beginPosition, transform.position.y, transform.position.z);
            }
            transform.position += Vector3.right * -speed * Time.deltaTime;
        }
    }
}
