using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class NPC_BarbarianMovement : MonoBehaviour {

        // reference to the animator
        public Animator animator;

        // these variables are used for the speed
        // horizontal and vertical movement of the NPC
        public float speed = 0.0f;
        public float h = 0.0f;
        public float v = 0.0f;
        public bool attack = false; // used for attack mode 1
        public bool jump = false; // used for jumping
        public bool die = false; // are we alive?

        // used for debugging
        public bool DEBUG = false;
        public bool DEBUG_DRAW = false;

        // Reference to the NavMeshAgent component.
        private NavMeshAgent nav;

        // Reference to the sphere collider trigger component.
        private SphereCollider col;

        // where is the player character in relation to NPC
        public Vector3 direction;

        // how far away is the player character from NPC
        public float distance = 0.0f;

        // what is the angle between the PC and NPC
        public float angle = 0.0f;

        // a reference to the player character
        public GameObject player;

        // is the PC in sight?
        public bool playerInSight;

        // what is the field of view for our NPC?
        // currently set to 110 degrees
        public float fieldOfViewAngle = 110.0f;

        // calculate the angle between PC and NPC
        public float calculatedAngle;

        // Use this for initialization
        private void Awake()
        {
            // get reference to the animator component
            animator = GetComponent<Animator>() as Animator;

            // get reference to nav mesh agent
            nav = GetComponent<NavMeshAgent>() as NavMeshAgent;

            // get reference to the sphere collider
            col = GetComponent<SphereCollider>() as SphereCollider;

            // get reference to the player
            player = GameObject.FindGameObjectWithTag("Player") as GameObject;

            // we don't see the player by default
            playerInSight = false;
        }

        // Use this for initialization
        void Start ()
        {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
            // if player is in sight let's slerp towards the player
            if (playerInSight)
            {
                transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            }
        }

        // let's update our scene using fixed update
        void FixedUpdate()
        {
            h = angle; // assign horizontal axis
            v = distance; // assign vertical axis

            // calculate speed based on distance and delta time
            speed = distance / Time.deltaTime;
            if (DEBUG)
                Debug.Log(string.Format("H:{0} - V:{1} - Speed:{2}", h, v, speed));

            // set the parameters defined in the animator controller
            animator.SetFloat("Speed", speed);
            animator.SetFloat("AngularSpeed", v);
            animator.SetBool("Attack", attack);
        }
    }
}
