using UnityEngine;

namespace Script
{
    public class SceneManager : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
        
        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void SceneChange()
        {
            if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("InGame");
            }
            else if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 0)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainWindow");
            }
        }
    }
}
