using UnityEngine;

public class PlayerPositionDetection : MonoBehaviour
{
    public BodySourceManager bodySourceManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        List<Vector2> positions = GetPlayerPositions();
        if (positions.Count == 0) return;
        
        Debug.Log($"Player Position: {positions[0].x}, {positions[0].y}");
    }

    private List<Vector2> GetPlayerPositions()
    {
        Body[] data = bodySourceManager.GetData();
        List<Vector2> positions = new List<Vector2>();
        foreach (var body in data)
        {
            footLeft = body.Joints[Kinect.JointType.FootLeft];
            footRight = body.Joints[Kinect.JointType.FootRight];
            playerPosition = AverageJointPosition(footLeft, footRight);
            positions.Add(playerPosition);
        }
        return positions;
    }

    private Vector2 AverageJointPosition(joint1, joint2) {
        Vector2 v1 = GetVector2FromJoint(joint1);
        Vector2 v2 = GetVector2FromJoint(joint2);

        return 0.5f * (v1 + v2);
    }

    private Vector2 GetVector2FromJoint(Kinect.Joint joint)
    {
        return new Vector2(joint.Position.X, joint.Position.Z);
    }
}
