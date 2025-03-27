using UnityEngine;

/* Author: Andrew Black
 * Since: 3/27/25
 * Config is a GameObject responsible for holding various information useful for configuring the game.
 * Currently, it only holds the Calibration settings for the Kinect.
 * It utilizes DontDestroyOnLoad to be relevant across all Scenes
 */
public class Config : MonoBehaviour
{

    // calibration settings
    public Vector3 leftFoot;
    public Vector3 rightFoot;

    // instance of Config for self reference - i.e., DontDestroyOnLoad safety
    private static Config instance; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
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

    void Update()
    {
        
    }

    // the only current method updates the Calibration
    public void UpdateCalibration(Vector3 leftFoot, Vector3 rightFoot)
    {
        this.leftFoot = leftFoot;
        this.rightFoot = rightFoot;
    }
}
