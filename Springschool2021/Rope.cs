using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public GameObject origin;
    [Tooltip("Can be left empty")]
    public GameObject connectedTo;

    [Header("Rope Options")]
    public Vector3 segmentGravity = new Vector3(0f, -1.5f, 0f);
    public Vector3 lastSegmentGravity = new Vector3(0f, -1.5f, 0f);
    public float ropeSegLength = 0.25f;
    public int vertices = 35;
    public int elastic = 100;

    private List<RopeSegment> ropeSegments = new List<RopeSegment>();
    private float lineWidth = 0.1f;

    // Use this for initialization
    void Start()
    {
        Vector3 ropeStartPoint = origin.transform.position;

        for (int i = 0; i < vertices; i++)
        {
            ropeSegments.Add(new RopeSegment(ropeStartPoint));
            ropeStartPoint.y -= ropeSegLength;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        DrawRope();
    }

    private void FixedUpdate()
    {
        Simulate();
    }

    private void Simulate()
    {

        for (int i = 1; i < vertices; i++)
        {
            RopeSegment segment = ropeSegments[i];
            Vector3 velocity = segment.posNow - segment.posOld;
            segment.posOld = segment.posNow;
            segment.posNow += velocity;
            if(i == vertices -1 && connectedTo != null)
            {
                segment.posNow = connectedTo.transform.position;
            }
            else
            {
                segment.posNow += segmentGravity * Time.fixedDeltaTime;
            }
            ropeSegments[i] = segment;
        }

        //CONSTRAINTS
        for (int i = 0; i < elastic; i++)
        {
            ApplyConstraint();
        }
    }

    private void ApplyConstraint()
    {
        //Constraint to object
        RopeSegment firstSegment = ropeSegments[0];
        firstSegment.posNow = origin.transform.position;
        ropeSegments[0] = firstSegment;

        for (int i = 0; i < vertices - 1; i++)
        {
            RopeSegment firstSeg = ropeSegments[i];
            RopeSegment secondSeg = ropeSegments[i + 1];

            float dist = (firstSeg.posNow - secondSeg.posNow).magnitude;
            float error = dist - ropeSegLength;
            Vector3 changeDir = (firstSeg.posNow - secondSeg.posNow).normalized;
            Vector3 changeAmount = changeDir * error;

            if (i != 0)
            {
                firstSeg.posNow -= changeAmount * 0.5f;
                ropeSegments[i] = firstSeg;
                secondSeg.posNow += changeAmount * 0.5f;
                ropeSegments[i + 1] = secondSeg;
            }
            else
            {
                secondSeg.posNow += changeAmount;
                ropeSegments[i + 1] = secondSeg;
            }
        }
    }

    private void DrawRope()
    {
        Vector3[] ropePositions = new Vector3[vertices];
        for (int i = 0; i < vertices; i++)
        {
            ropePositions[i] = ropeSegments[i].posNow;
        }

        lineRenderer.positionCount = ropePositions.Length;
        lineRenderer.SetPositions(ropePositions);
    }

    public struct RopeSegment
    {
        public Vector3 posNow;
        public Vector3 posOld;

        public RopeSegment(Vector3 pos)
        {
            posNow = pos;
            posOld = pos;
        }
    }
}