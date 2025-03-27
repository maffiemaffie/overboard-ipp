using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/* Author: Andrew Black
 * Since: 3/27/25
 * CustomSceneManager is what allows and easy change between screens. Currently, it's only utilized 
 * for an easy shift to the Calibration scene.
 * It utilizes DontDestroyOnLoad to be relevant across all Scenes
 */
public class CustomSceneManager : MonoBehaviour
{
    // instance of Config for self reference - i.e., DontDestroyOnLoad safety
    public static CustomSceneManager instance;

    // reference to a previous string
    private string previousSceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        // upon creation, if there is no instance, make one of itself. This is so if we wrap around to the scene where its
        // created, the 'new' Config GameObjects will see an instance is already in place and destroy themselves
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    // Update listens for the ` screen to switch Scenes.
    void Update()
    {
        // Listen for the ` key to toggle Calibration scene
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            ToggleCalibrationScene();
        }
    }

    // ToggleClibrationScene just utilizes the SceneManager to load in Scenes. 
    // Right now, this means switching to Calibration if it's not the active Screen
    // and returning to the previous Scene if Calibration is active
    private void ToggleCalibrationScene()
    {
        // if we are already in the Calibration scene, return to the previous scene
        // or else go to calibration
        if (SceneManager.GetActiveScene().name == "Calibration")
        {
            // return to the previous scene (name is set in the else)
            if (!string.IsNullOrEmpty(previousSceneName))
            {
                SceneManager.LoadScene(previousSceneName);
            }
        }
        else
        {
            // save the current scene to return to later
            previousSceneName = SceneManager.GetActiveScene().name;

            // load the Calibration scene
            SceneManager.LoadScene("Calibration");
        }
    }
}
