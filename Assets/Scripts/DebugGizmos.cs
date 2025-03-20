using UnityEngine;

public class DebugGizmos : MonoBehaviour
{
    public GameObject spawnManager;
    public GameObject player;

    void OnDrawGizmos()
    {
        DrawBounds();
        DrawPlayer();
    }

    private void DrawPlayer() {
        Vector3 position = player.transform.position;
        float radius = player.GetComponent<CapsuleCollider>().radius;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(position, radius);
    }

    private void DrawBounds()
    {
        FlotsamManager flotsamManager = spawnManager.GetComponent<FlotsamManager>();
        Vector3 minGlobalBoundary = flotsamManager.minGlobalBoundary;
        Vector3 maxGlobalBoundary = flotsamManager.maxGlobalBoundary;

        Vector3 center = (minGlobalBoundary + maxGlobalBoundary) / 2;
        Vector3 size = maxGlobalBoundary - minGlobalBoundary;

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(center, size);
    }
}
