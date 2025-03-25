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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.canvasPos = uiCanvas.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (kinect != null)
        {
            this.playerPosition = kinect.GetPlayerPosition();
            updateDotPositions();
            updateText();
        }
    }

    private void updateDotPositions()
    {
        redDotLeft.transform.position = canvasPos + playerPosition.leftFoot;
        redDotRight.transform.position = canvasPos + playerPosition.rightFoot;
    }

    private void updateText()
    {
        
        
            leftFootText.text = DEFAULT_LEFT_FOOT_TEXT + playerPosition.leftFoot.ToString();
            rightFootText.text = DEFAULT_RIGHT_FOOT_TEXT + playerPosition.rightFoot.ToString();
            kinectStatusText.text = DEFAULT_KINECT_STATUS_TEXT + (kinectStatus ? "Connected" : "Disconnected");
        
    }
}
