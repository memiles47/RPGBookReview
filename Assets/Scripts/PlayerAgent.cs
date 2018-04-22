using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class PlayerAgent : MonoBehaviour 
    {
        public PlayerCharacter playerCharacterData;

        private void Awake()
        {
            PlayerCharacter tmp = new PlayerCharacter();
            tmp.Name = "Maximilian";
            tmp.Health = 100.0f;
            tmp.Defense = 50.0f;
            tmp.Description = "Our Hero";
            tmp.Dexterity = 33.0f;
            tmp.Intelligence = 80.0f;
            tmp.Strength = 60.0f;

            playerCharacterData = tmp;
        }

        // Use this for initialization
        private void Start ()
        {
		
        }
	
        // Update is called once per frame
        private void Update ()
        {
            if (playerCharacterData.Health < 0.0f)
            {
                playerCharacterData.Health = 0.0f;
                transform.GetComponent<BarbarianCharacterController>().die = true;
            }
        }
    }
}
