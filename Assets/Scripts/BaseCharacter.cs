using System;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class BaseCharacter : MonoBehaviour
    {
        //Define attribute for base character
        [SerializeField]
        public string Name;
        [SerializeField]
        public string Description;
        [SerializeField]
        public float Strength;
        [SerializeField]
        public float Defense;
        [SerializeField]
        public float Dexterity;
        [SerializeField]
        public float Intelligence;
        [SerializeField]
        public float Health;

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
