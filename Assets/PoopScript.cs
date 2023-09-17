using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class PoopScript : MonoBehaviour
{
    [SerializeField] ParticleSystem HopParticle = null;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource fart;

    private void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    private void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        fart = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            fart.Play(0);
            HopParticle.Play();
        }

        if (transform.position.y < -20 || transform.position.y > 20)
        { 
            logic.gameOver();
            birdIsAlive = false;
        }
        foreach (var touch in Touch.activeTouches)
        {
            // Only respond to first finger
            if (touch.finger.index == 0 && touch.isInProgress)
            {
                if (birdIsAlive)
                {
                    myRigidbody.velocity = Vector2.up * flapStrength;
                    fart.Play(0);
                    HopParticle.Play();
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
