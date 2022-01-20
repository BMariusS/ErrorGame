using System;
using System.Collections;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsInteractable;            // A mask determining what is interactable with the character
        [SerializeField]
        private AudioClip sound;
        [SerializeField]
        private AudioClip soundJumping;
        //[SerializeField]
        //private AudioClip soundLanding;
        [SerializeField]
        private AudioClip soundGravity;
        //[SerializeField]
        //private AudioClip soundFootsteps;

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        private Transform m_CeilingCheck;   // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Animator m_Anim;            // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
        private bool m_OnGround = true;     // Check if it is grounded

        [SerializeField]
        private bool m_IsAlive = true;
        [SerializeField]private int deathsNumber = 0;

                                                                                                private bool touch = false;

        private void Awake() {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }
        private void FixedUpdate() {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsInteractable);
            for(int i = 0; i < colliders.Length; i++) {
                if(colliders[i].gameObject != gameObject) {
                    m_Grounded = true;
                }
            }
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);

        }

        public void Move(float move, bool crouch, bool jump) {
            if(!m_IsAlive)
                return;

            // If crouching, check to see if the character can stand up
            if(!crouch && m_Anim.GetBool("Crouch")) {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if(Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsInteractable)) {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if(m_Grounded || m_AirControl) {
                // Reduce the speed if crouching by the crouchSpeed multiplier
                move = (crouch ? move * m_CrouchSpeed : move);

                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if(move > 0 && !m_FacingRight) {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if(move < 0 && m_FacingRight) {
                    // ... flip the player.
                    Flip();
                }

                // change direction requested
                //if (newGravityDirection && m_Grounded)
                //{
                //    m_Rigidbody2D.gravityScale *= -1;
                //}

                //If the player is on the floor
                if(m_Rigidbody2D.gravityScale < 0 && m_OnGround) {
                    // flip the player
                    FlipVertical();
                }
                //If the player is on the ceiling
                else if(m_Rigidbody2D.gravityScale > 0 && !m_OnGround) {
                    //flip the player
                    FlipVertical();
                }
            }
            // If the player should jump...
            if(m_Grounded && jump && m_Anim.GetBool("Ground")) {
                if(m_Rigidbody2D.gravityScale > 0) {
                    // Add a vertical force to the player.
                    m_Grounded = false;
                    m_Anim.SetBool("Ground", false);
                    GetComponent<AudioSource>().PlayOneShot(soundJumping);
                    m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
                }
                if(m_Rigidbody2D.gravityScale < 0) {
                    m_Grounded = false;
                    m_Anim.SetBool("Ground", false);
                    GetComponent<AudioSource>().PlayOneShot(soundJumping);
                    m_Rigidbody2D.AddForce(new Vector2(0f, -m_JumpForce));
                }
            }

            //if(m_OnGround || !m_OnGround) {
            //    GetComponent<AudioSource>().PlayOneShot(soundLanding);
            //}
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void FlipVertical()
        {
            //Switch if the player is walking on ground or ceiling
            m_OnGround = !m_OnGround;

            //Switch the player's y local scale by -1
            Vector3 verticalScale = transform.localScale;
            verticalScale.y *= -1;
            transform.localScale = verticalScale;
            GetComponent<AudioSource>().PlayOneShot(soundGravity);
        }

        private void Death()
        {
            m_Anim.SetBool("isDead", true);
            m_IsAlive = false;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Killzone")
            {
                Death();
                if(DeathsNumber == 0) {
                   //GetComponent<AudioSource>().PlayOneShot(sound);
                   // DeathsNumber++;
                }
            }
            if(other.tag == "Spikes" || other.tag == "SpikeBall")
            {
                Death();
                if(touch == false) {
                    touch = true;
                    Debug.Log("test");
                    Debug.Log(touch);
                    GetComponent<AudioSource>().PlayOneShot(sound);
                }
                //if(DeathsNumber == 0) {
                //    GetComponent<AudioSource>().PlayOneShot(sound);
                //   // DeathsNumber++;
                //}
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if(other.gameObject.tag == "SpikeBall" || other.gameObject.tag == "Spikes")
            {
                Death();
                if(DeathsNumber == 0) {
                    //GetComponent<AudioSource>().PlayOneShot(sound);
                    //DeathsNumber++;
                }
            }
            //if (other.gameObject.tag == "MovingPlatform")
            //{
            //    transform.parent = other.transform;
            //}

            if(other.gameObject.tag == "Boss")
            {
                Death();
                //if(DeathsNumber == 0) {
                //    GetComponent<AudioSource>().PlayOneShot(sound);
                //    //DeathsNumber++;
                //}
                if(touch == false) {
                    touch = true;
                    Debug.Log("test");
                    Debug.Log(touch);
                    GetComponent<AudioSource>().PlayOneShot(sound);
                }
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.tag == "MovingPlatform")
            {
                transform.parent = null;
            }
        }
        private void OnCollisionStay2D(Collision2D other)
        {
            if (other.gameObject.tag == "SpeedUp" && m_FacingRight)
            {
                m_MaxSpeed = 50f;
            }
            else if (other.gameObject.tag == "SpeedUpLeft" && !m_FacingRight)
            {
                m_MaxSpeed = 50f;
            }
            else
            {
                m_MaxSpeed = 11f;
            }
            if(other.gameObject.tag == "Walls")
            {
                m_MaxSpeed = 11f;
            }
            if (other.gameObject.tag == "MovingPlatform") {
                m_MaxSpeed = 11f;
            GameObject findPlaftorm = GameObject.Find("MovingPlatform");
            SimpleMovingPlatform platformSpeed = findPlaftorm.GetComponent<SimpleMovingPlatform>();
                transform.parent = other.transform;

                if (platformSpeed.PointSelection == 1 && m_FacingRight || platformSpeed.PointSelection == 0 && !m_FacingRight)
                    m_MaxSpeed += platformSpeed.MoveSpeed;
            }
        }

        public bool M_Grounded
        {
            get
            {
                return m_Grounded;
            }
        }
        public bool M_IsAlive
        {
            get
            {
                return m_IsAlive;
            }
            set
            {
                m_IsAlive = value;
            }
        }

        public int DeathsNumber
        {
            get
            {
                return deathsNumber;
            }
            set
            {
                deathsNumber = value;
            }
        }

        public Animator M_Anim
        {
            get
            {
                return m_Anim;
            }
        }

        public Rigidbody2D M_Rigidbody2D
        {
            get
            {
                return m_Rigidbody2D;
            }
        }

        public bool Touch {
            get {
                return touch;
            }
            set {
                touch = value;
            }
        }

        /*        private void OnTriggerExit2D(Collider2D other)
                {
                    if (other.tag == "CannonBall")
                    {
                        Death();
                    }
                }
        */
    }
}
