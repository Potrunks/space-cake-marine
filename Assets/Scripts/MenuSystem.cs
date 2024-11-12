using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuSystem : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject FirstButtonHighlighted { get; private set; }

        public void SetSelectedGameObject()
        {
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(FirstButtonHighlighted);
        }

        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            Time.timeScale = 1f;
        }

        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1f;
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}
