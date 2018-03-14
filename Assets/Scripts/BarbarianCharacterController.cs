using UnityEngine;

namespace Assets.Scripts
{
    public class BarbarianCharacterController : MonoBehaviour
    {
        public Animator animator;
        public float directionDampTime;

        public float speed = 6.0f;
        public float h = 0.0f;
        public float v = 0.0f;

        private bool attack = false;
        private bool punch = false;
        private bool run = false;

        private bool jump = false;
        private bool die = false;
        private bool dead = false;

        private Vector3 moveDirection = Vector3.zero;

        // Use this for initialization
        void Start ()
        {
            this.animator = GetComponent<Animator>() as Animator;
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (dead)
            {
                if (die)
                {
                    die = !die;
                    animator.SetBool("Die", die);
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                attack = true;
            }

            if (Input.GetKeyUp(KeyCode.C))
            {
                attack = false;
            }

            animator.SetBool("Attack", attack);

            if (Input.GetKeyDown(KeyCode.P))
            {
                punch = true;
            }

            if (Input.GetKeyUp(KeyCode.P))
            {
                punch = false;
            }

            animator.SetBool("Punch", punch);

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                this.run = true;
            }

            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                this.run = false;
            }

            animator.SetBool("Run", run);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                jump = false;
            }

            animator.SetBool("Jump", jump);

            if (Input.GetKeyDown(KeyCode.I))
            {
                die = true;
                dead = true;
            }

            animator.SetBool("Die", die);

        }

        void FixedUpdate()
        {
            // The Inputs are defined in the Input Manager
            // get value for horizontal axis
            h = Input.GetAxis("Horizontal");

            // get value for vertical axis
            v = Input.GetAxis("Vertical");

            speed = new Vector2(h, v).sqrMagnitude;

            // Used to get values on console
            Debug.Log(string.Format("H:{0} - V:{1} - Speed:{2}", h, v, speed));

            animator.SetFloat("Speed", speed);
            animator.SetFloat("Horizondar", h);
            animator.SetFloat("Vertical", v);
        }
    }
}
