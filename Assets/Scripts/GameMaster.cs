using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	public class GameMaster : MonoBehaviour {

		// Use this for initialization
		private void Start ()
		{
		    DontDestroyOnLoad(this);
		}
	
		// Update is called once per frame
		private void Update ()
		{
		
		}

		public void StartGame()
		{
			//start level
			SceneManager.LoadScene("Awakening");
		}
	}
}
