using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof(BossAi))]
    public class BossControl : MonoBehaviour
    {
        private BossAi m_Character;
        private GameObject findPlayer;

        private void Awake()
        {
            m_Character = GetComponent<BossAi>();
            m_Character.Move(0);
        }
        private void FixedUpdate()
        {
            m_Character.Move(1);
            findPlayer = GameObject.Find("CharacterRobotBoy");
            PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<PlatformerCharacter2D>();
            if(!player.M_IsAlive) {
                m_Character.Move(0);
            }
        }

        //private void OnCollisionEnter2D(Collision2D other) {
        //    if(other.gameObject.tag == "Player") {
        //        findPlayer = GameObject.Find("CharacterRobotBoy");
        //        PlatformerCharacter2D player = findPlayer.gameObject.GetComponent<PlatformerCharacter2D>();

        //        m_Character.Move(0);
        //    }
        //}
    }
}