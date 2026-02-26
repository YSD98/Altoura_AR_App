using UnityEngine;
using UnityEngine.SceneManagement;

namespace AR_Assessment.Misc
{
    public class SceneSwitch : MonoBehaviour
    {
        public void TransitToScene(string sceneName)
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}