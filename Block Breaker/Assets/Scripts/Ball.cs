using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle;
    [SerializeField] float randomFactor = 0.5f;

    Vector2 paddleToBallVector;

    bool hasLaunched = false;

    AudioSource audioSource;

    Rigidbody2D myRigidBody2D;



    [SerializeField] float xVelocity = 2f;
    [SerializeField] float yVelocity = 15f;

    [SerializeField] AudioClip[] ballSounds;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!hasLaunched)
        {
            LockBallToPaddle();
            LaunchOnMouseClick();
        }
    }

    public void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButton(0))
        {
            hasLaunched = true;
            myRigidBody2D.velocity = new Vector2(xVelocity, yVelocity);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(UnityEngine.Random.Range(0f,randomFactor), UnityEngine.Random.Range(0f,randomFactor));
        if (hasLaunched)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            audioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }

    public bool IsGameStarted()
    {
        return hasLaunched;
    }

    public void resetLaunch()
    {
        hasLaunched = false;
    }


}
