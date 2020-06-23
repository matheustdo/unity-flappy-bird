using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D birdRigidBody;
    public Animator birdAnimator;
    public AudioSource wingSound;
    public AudioSource pointSound;
    public AudioSource hitSound;
    public AudioSource fallSound;
    public float jumpHeight = 10f;
    public float rotationSpeed = -20f;
    public float jumpRotationDelay = 1f;
    private float jumpTime = 0f;
    private float currentTime = 0f;
    public float initialOffsetY = 0.11f;
    private bool groundReached = false;

    void Start()
    {
        birdRigidBody = GetComponent<Rigidbody2D>();
        birdAnimator = GetComponent<Animator>();
        birdRigidBody.isKinematic = true;
    }

    void Update()
    {
        if (Game.CurrentState == GameState.Menu && !groundReached)
        {
            MenuMovement();
        }

        jumpTime -= Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            if (Game.CurrentState == GameState.Menu)
            {
                Game.CurrentState = GameState.Running;
                birdRigidBody.isKinematic = false;
                Jump();
            }
            else if (Game.CurrentState == GameState.Dead)
            {
                Game.CurrentState = GameState.Menu;
            }
            else if (Game.CurrentState == GameState.Running)
            {
                Jump();
            }
        }
        else if (jumpTime <= 0f && Game.CurrentState == GameState.Running)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
        else if (Game.CurrentState == GameState.Dead && !groundReached)
        {
            transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Floor")
        {
            if (Game.CurrentState == GameState.Running)
            {
                birdAnimator.enabled = false;
                hitSound.Play(0);
                Game.CurrentState = GameState.Dead;
            }
            groundReached = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Point" && Game.CurrentState == GameState.Running)
        {
            Game.CurrentScore++;
            pointSound.Play(0);
        }
        else if (Game.CurrentState == GameState.Running)
        {
            birdAnimator.enabled = false;
            hitSound.Play(0);
            fallSound.Play(0);
            Game.CurrentState = GameState.Dead;
        }
    }

    void Jump()
    {
        if (Game.CurrentState == GameState.Running)
        {
            birdRigidBody.velocity = new Vector2(0, jumpHeight);
            transform.rotation = Quaternion.Euler(0f, 0f, 20f);
            wingSound.Play(0);
            jumpTime = jumpRotationDelay;
        }
    }

    void MenuMovement()
    {
        birdRigidBody.isKinematic = true;
        transform.position = new Vector2(transform.position.x, initialOffsetY + 0.3f * Mathf.Sin(currentTime * 6f));
        currentTime += Time.deltaTime;
    }
}
