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
        public bool attack1 = false; // needed when script was updated ** check **
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
        private void Start ()
        {
		
        }

        // Update is called once per frame
        private void Update ()
        {
            // if player is in sight let's slerp towards the player
            if (playerInSight)
            {
                this.transform.rotation =
                    Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
            }
            if(this.player.transform.GetComponent<BarbarianCharacterController>().die)
            {
                animator.SetBool("Attack", false);
                animator.SetFloat("Speed", 0.0f);
                animator.SetFloat("AngularSpeed", 0.0f);
            }
        }

        // let's update our scene using fixed update
        private void FixedUpdate()
        {
            h = angle; // assign horizontal axis
            v = distance; // assign vertical axis

            // calculate speed based on distance and delta time
            speed = distance / Time.deltaTime;
            if (DEBUG)
                Debug.Log(string.Format("H:{0} - V:{1} - Speed:{2}", h, v,
                    speed));
            // set the parameters defined in the animator controller
            animator.SetFloat("Speed", speed);
            animator.SetFloat("AngularSpeed", v);
            animator.SetBool("Attack", attack1);
            animator.SetBool("Attack1", attack1);
            if(playerInSight)
            {
                if (animator.GetFloat("Attack1C") == 1.0f)
                {
                    this.player.GetComponent<PlayerAgent>().playerCharacterData.Health -= 1.0f;
                }
            }
        }

        // if the PC is in our collider, we want to examine the location
        // of the player
        // calculate the direction based on our position and the
        // player's position
        // use the DOT product to get the angle between the two vectors
        // calculate the angle between the NPC forward vector and the PC
        // if it falls within the field of view, we have the player in
        // sight.
        // if the player is in sight, we will set the nav agent destination
        // if we are within a certain distance from the PC, the NPC has
        // the ability to attack

        private void OnTriggerStay(Collider other)
        {
            if (other.transform.tag.Equals("Player"))
            {
                // Create a vector from the enemy to the player and store
                // the angle between it and forward.
                direction = other.transform.position - transform.position;
                distance = Vector3.Distance(other.transform.position, transform.position) -
                           1.0f;
                float DotResult = Vector3.Dot(transform.forward,
                    player.transform.position);
                angle = DotResult;
                if (DEBUG_DRAW)
                {
                    Debug.DrawLine(transform.position + Vector3.up, direction * 50,
                        Color.gray);
                    Debug.DrawLine(other.transform.position, transform.position, Color.cyan);
                }
                playerInSight = false;
                calculatedAngle = Vector3.Angle(direction, transform.forward);
                if (calculatedAngle < fieldOfViewAngle * 0.5f)
                {
                    RaycastHit hit;
                    if (DEBUG_DRAW)
                        Debug.DrawRay(transform.position + transform.up, direction.normalized,
                            Color.magenta);
                    // ... and if a raycast towards the player hits something...
                    if (Physics.Raycast(transform.position + transform.up,
                        direction.normalized, out hit,
                        col.radius))
                    {
                        // ... and if the raycast hits the player...
                        if (hit.collider.gameObject == player)
                        {
                            // ... the player is in sight.
                            playerInSight = true;
                            if (DEBUG)
                                Debug.Log("PlayerInSight: " + playerInSight);
                        }
                    }
                }
                if (playerInSight)
                {
                    nav.SetDestination(other.transform.position);
                    CalculatePathLength(other.transform.position);
                    if (distance < 1.1f)
                    {
                        attack = true;
                    }
                    else
                    {
                        attack = false;
                    }
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.transform.tag.Equals("Player"))
            {
                distance = 0.0f;
                angle = 0.0f;
                attack = false;
                playerInSight = false;
            }
        }

        // this is a helper function at this point
        // in the future we will use it to calculate distance around
        // the corners
        // it currently is also used to draw the path of the nav mesh
        // agent in the
        // editor
        private float CalculatePathLength(Vector3 targetPosition)
        {
            // Create a path and set it based on a target position.
            NavMeshPath path = new NavMeshPath();

            if (nav.enabled)
                nav.CalculatePath(targetPosition, path);

            // Create an array of points which is the length of the number
            // of corners in the path + 2.
            Vector3[] allWayPoints = new Vector3[path.corners.Length + 2];

            // The first point is the enemy's position.
            allWayPoints[0] = transform.position;

            // The last point is the target position.
            allWayPoints[allWayPoints.Length - 1] = targetPosition;

            // The points inbetween are the corners of the path.
            for (int i = 0; i < path.corners.Length; i++)
            {
                allWayPoints[i + 1] = path.corners[i];
            }
            // Create a float to store the path length that is by default 0.
            float pathLength = 0;

            // Increment the path length by an amount equal to the
            // distance between each waypoint and the next.
            for (int i = 0; i < allWayPoints.Length - 1; i++)
            {
                pathLength += Vector3.Distance(allWayPoints[i], allWayPoints[i + 1]);
                if (DEBUG_DRAW)
                    Debug.DrawLine(allWayPoints[i], allWayPoints[i + 1], Color.red);
            }
            return pathLength;
        }
    }
}
