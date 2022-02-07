using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    /// <summary>
    /// Number of points to calculate on the line
    /// </summary>
    private int _numPoints = 50;

    /// <summary>
    /// The three key points for the bezier calculations
    /// </summary>
    [Tooltip("The three key points for the bezier calculations")]
    [SerializeField] private Transform _point0, _point1, _point2;

    /// <summary>
    /// The list of positions on the line
    /// </summary>
    private Vector3[] _positions;

    /// <summary>
    /// LineRenderer reference
    /// </summary>
    private LineRenderer _lineRenderer;

    /// <summary>
    /// Unity Start
    /// </summary>
    private void Start()
    {
        _positions = new Vector3[_numPoints];
        _lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        DrawQuadraticCurve();
    }

    /// <summary>
    /// Draws a curve using a line renderer
    /// </summary>
    private void DrawQuadraticCurve()
    {
        for (int i = 1; i < _numPoints + 1; i++)
        {
            float t = i / (float)_numPoints;
            _positions[i - 1] = CalculateQuadraticBezierPoint(t, _point0.position, _point1.position, _point2.position);
        }

        _lineRenderer.SetPositions(_positions);
    }

    /// <summary>
    /// Calculate a point on a bezier curve
    /// </summary>
    /// <param name="t">Step</param>
    /// <param name="p0">Point 0</param>
    /// <param name="p1">Point 1</param>
    /// <param name="p2">Point 2</param>
    /// <returns>A point in the bezier quadratic curve</returns>
    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;
        Vector3 p = uu * p0;
        p += 2 * u * t * p1;
        p += tt * p2;
        return p;
    }
}
