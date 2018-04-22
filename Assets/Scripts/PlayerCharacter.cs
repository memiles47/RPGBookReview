using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class PlayerCharacter : MonoBehaviour {

        public string Name { get; set; }
        public float Health { get; set; }
        public float Defense { get; set; }
        public string Description { get; set; }
        public float Dexterity { get; set; }
        public float Intelligence { get; set; }
        public float Strength { get; set; }

        // Use this for initialization
        private void Start ()
        {
		
        }
	
        // Update is called once per frame
        private void Update ()
        {
		
        }
    }
}
