using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class GameMaster : MonoBehaviour {

        // Use this for initialization
        void Start ()
        {
		
        }
	
        // Update is called once per frame
        void Update ()
        {
		
        }

        void StartGame()
        {
            //You should put in the name of the scene that represents your
            //start level
            SceneManager.LoadScene("Awakening");
        }
    }
}
