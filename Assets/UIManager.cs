using TMPro;
using UnityEngine;
using Windows.Kinect;

public class UIManager : MonoBehaviour
{
    public Canvas uiCanvas;

    public TextMeshProUGUI leftFootText;
    public TextMeshProUGUI rightFootText;
    public TextMeshProUGUI kinectStatusText;

    public GameObject redDotLeft;
    public GameObject redDotRight;

    public PlayerPositionDetection kinect;

    private const string DEFAULT_LEFT_FOOT_TEXT = "Left Foot: ";
    private const string DEFAULT_RIGHT_FOOT_TEXT = "Right Foot: ";
    private const string DEFAULT_KINECT_STATUS_TEXT = "Kinect Status: ";

    private bool kinectStatus = true;

    private PlayerPositionDetection.PlayerPosition playerPosition;
    
    private Vector3 canvasPos;

    private Vector3 leftFootCalibration = new Vector3(0,0);
    private Vector3 rightFootCalibration = new Vector3(0,0);
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.canvasPos = uiCanvas.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Left Foot Controls (Arrow Keys)
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftFootCalibration.x -= 0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            leftFootCalibration.x += 0.1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            leftFootCalibration.z += 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            leftFootCalibration.z -= 0.1f;
        }

        // Right Foot Controls (WASD Keys)
        if (Input.GetKey(KeyCode.A))
        {
            rightFootCalibration.x -= 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rightFootCalibration.x += 0.1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            rightFootCalibration.z += 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rightFootCalibration.z -= 0.1f;
        }

        if (kinect != null)
        {
            this.playerPosition = kinect.GetPlayerPosition();
            updateDotPositions();
            updateText();
        }
    }

    private void updateDotPositions()
    {
        Vector3 newPosition = playerPosition.leftFoot + leftFootCalibration;
        newPosition.x *= -110.0f;
        newPosition += canvasPos;
        redDotLeft.transform.position = newPosition;

        newPosition = playerPosition.rightFoot + rightFootCalibration;
        newPosition.x *= 110.0f;
        newPosition += canvasPos;
        redDotRight.transform.position = newPosition;
    }

    private void updateText()
    {
        
        
            leftFootText.text = DEFAULT_LEFT_FOOT_TEXT + playerPosition.leftFoot.ToString();
            rightFootText.text = DEFAULT_RIGHT_FOOT_TEXT + playerPosition.rightFoot.ToString();
            kinectStatusText.text = DEFAULT_KINECT_STATUS_TEXT + (kinectStatus ? "Connected" : "Disconnected");
        
    }
}
