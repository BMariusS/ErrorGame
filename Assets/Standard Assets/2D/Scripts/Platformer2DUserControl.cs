using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        private bool m_isPlaying = true;
        private bool m_isPlayingLeft = true;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
                //m_ChangeGravityDirection = false; // Reset
                if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && GetComponent<Rigidbody2D>().gravityScale > 0
                || (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)) && GetComponent<Rigidbody2D>().gravityScale < 0)
                {
                if (!m_Character.M_IsAlive)
                    return;
                if (m_Character.M_Grounded)
                {
                    GetComponent<Rigidbody2D>().gravityScale *= -1;
                }
            //    Debug.Log(m_ChangeGravityDirection);
                }


            
/*            //Changes gravity of the player
            if (Input.GetKeyDown(KeyCode.W) && GetComponent<Rigidbody2D>().gravityScale > 0)
            {
              m_ChangeGravityDirection = true;
            }
            if(Input.GetKeyDown(KeyCode.S) && GetComponent<Rigidbody2D>().gravityScale < 0)
            {
              m_ChangeGravityDirection = true;
            }
*/
            
        }


        private void FixedUpdate()
        {
            // Read the inputs.
//            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, false, m_Jump);
            m_Jump = false;
        //    if (!m_isPlaying)
        //    {
        //        m_Character.Move(1, false, m_Jump);
        //    }
        //    if (!m_isPlayingLeft)
        //    {
        //        m_Character.Move(-1, false, m_Jump);
        //    }
        //}
        //private void OnTriggerEnter2D(Collider2D other)
        //{
        //    if(other.tag == "NextLevel")
        //    {
        //        m_isPlaying = false;
        //    }
        //    if(other.tag == "NextLevelLeft")
        //    {
        //        m_isPlayingLeft = false;
        //    }

        }
    }
}
