using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Windows.Kinect;
using Kinect = Windows.Kinect;

public class PlayerPositionDetection : MonoBehaviour
{
    public BodySourceManager bodySourceManager;
    public GameObject player;
    private Vector3 playerPosition;

    void Start()
    {
        playerPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        List<Vector3> positions = GetPlayerPositions();
        if (positions.Count == 0) return;
        
        player.transform.position = positions[0];

        Debug.Log(positions.Count);
        foreach (var position in positions)
        {
            if (position.x == 0 && position.y == 0 && position.z == 0) continue;
            if (position.x < -14.5) continue;
            Debug.Log($"Player Position: {position.x}, {position.y}, {position.z}");
            playerPosition = new Vector3(position.x, position.y, position.z);
            return;
        }

    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition;
    }

    public List<Vector3> GetPlayerPositions()
    {
        Body[] data = bodySourceManager.GetData();
        List<Vector3> positions = new List<Vector3>();
        foreach (var body in data)
        {
            Kinect.Joint footLeft = body.Joints[Kinect.JointType.FootLeft];
            Kinect.Joint footRight = body.Joints[Kinect.JointType.FootRight];
            Vector3 playerPosition = AverageJointPosition(footLeft, footRight);
            positions.Add(playerPosition);
        }
        return positions;
    }

    private Vector3 AverageJointPosition(Kinect.Joint joint1, Kinect.Joint joint2) {
        Vector3 v1 = GetVector3FromJoint(joint1);
        Vector3 v2 = GetVector3FromJoint(joint2);

        return new Vector3(
            0.5f * (v1.x + v2.x), 
            0.5f * (v1.y + v2.y),
            0.5f * (v1.z + v2.z)
        );
    }

    private Vector3 GetVector3FromJoint(Kinect.Joint joint)
    {
        return new Vector3(joint.Position.X * 10, joint.Position.Y * 10, joint.Position.Z * -10);
    }
}