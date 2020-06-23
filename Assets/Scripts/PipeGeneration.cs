using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeGeneration : MonoBehaviour
{
    public GameObject pipe;
    public float generationRange = 7f;
    public float bottomRange = -1f;
    public float TopRange = 3f;
    public float movementSpeed = -1f;
    public float generationDelay = 4f;
    private float generationTime = 0f;
    private List<GameObject> pipes = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (Game.CurrentState != GameState.Dead && Game.CurrentState != GameState.Paused)
        {
            List<GameObject> deletionBuffer = new List<GameObject>();
            if (Game.CurrentState == GameState.Running)
            {
                generationTime -= Time.deltaTime;

                if (generationTime <= 0)
                {
                    generationTime = generationDelay;
                    pipe.transform.position = new Vector2(generationRange, Random.Range(bottomRange, TopRange));
                    pipes.Add(Instantiate(pipe));
                }

                pipes.ForEach(p =>
                {
                    if (p.transform.position.x < -generationRange)
                    {
                        deletionBuffer.Add(p);
                    }
                    else
                    {
                        p.transform.position = new Vector2(p.transform.position.x + movementSpeed * Time.deltaTime, p.transform.position.y);
                    }
                });

                deletionBuffer.ForEach(p =>
                {
                    pipes.Remove(p);
                    Destroy(p);
                });
            }
        }
    }
}
