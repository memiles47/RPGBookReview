using UnityEngine;

namespace Assets.Scripts
{
    public class DoNotDestroy : MonoBehaviour {

        // Use this for initialization
        private void Start ()
        {
            DontDestroyOnLoad(this);
        }
	
        // Update is called once per frame
        private void Update ()
        {
		
        }
    }
}
