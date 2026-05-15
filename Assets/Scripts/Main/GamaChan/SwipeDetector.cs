using UnityEngine;

public class SwipeDetector
{
    private readonly float threshold;
    private Vector3 prevPos;
    private bool wasSwiping;
    public SwipeDetector(float speedThreshold)
    {
        threshold = speedThreshold;
    }

    public void Reset(Vector3 startPos)
    {
        prevPos = startPos;
        wasSwiping = false;
    }

    public float? Update(Vector3 currentPos, float deltaTime)
    {
        float speed = (currentPos - prevPos).magnitude / Mathf.Max(deltaTime, 1e-5f);

        bool isSwiping = speed > threshold;

        float? swipeStartSpeed = (!wasSwiping && isSwiping) ? speed : (float?)null;

        wasSwiping = isSwiping;
        prevPos = currentPos;
        return swipeStartSpeed;
    }
}
