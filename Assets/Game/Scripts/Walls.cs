using UnityEngine;

namespace FG
{
    public class Walls : MonoBehaviour
    {
        private Camera cam;
        private EdgeCollider2D edge;
        private Vector2[] edgePoints;
        private Vector2 bottomLeft;
        private Vector2 topLeft;
        private Vector2 topRight;
        private Vector2 bottomRight;

        private void Awake()
        {
            cam = Camera.main;
            
            bottomLeft = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
            topLeft = cam.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, cam.nearClipPlane));
            topRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.pixelHeight, cam.nearClipPlane));
            bottomRight = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, 0, cam.nearClipPlane));

            edge = GetComponent<EdgeCollider2D>();
            edgePoints = new Vector2[] { bottomLeft, topLeft, topRight, bottomRight, bottomLeft };
            edge.points = edgePoints;
        }
    }
}
