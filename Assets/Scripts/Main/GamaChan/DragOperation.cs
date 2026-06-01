using UnityEngine;

public class DragOperation
{
    private Transform target;
    private Vector3 offset;
    private Vector3 prevPos;
    private readonly Vector3 min, max;
    private bool wasSwiping;
    private readonly float threshold;
    private readonly SwipeDetector swipe;

    public DragOperation(Vector2 min, Vector2 max, float swipeThreshold)
    {
        this.min = min;
        this.max = max;
        threshold = swipeThreshold;
    }

    public void Begin(Transform t, Vector3 pointerWorld)
    {
        target = t;
        offset = t.position - pointerWorld;
        prevPos = t.position;
        wasSwiping = false;
    }

    public float UpdatePosition(Vector3 pointerWorld, float deltaTime,float shakecharge)
    {
        if (target == null) return 0;
        float speed = 0;
        var pos = pointerWorld + offset;
        //Debug.Log($"pointerWorld={pointerWorld}, offset={offset}, pos(before clamp)={pos}, min={min}, max={max}");
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        pos.z = 0f;
        target.position = pos;

        if(shakecharge!=0)
        {
            Vector2 dir = (pos - prevPos).normalized;

            if(dir!=new Vector2(0.0f,0.0f))
            {
                speed += 4;
            }
        }
        else
        {
            speed = (pos - prevPos).magnitude / Mathf.Max(deltaTime, 1e-5f);
        }

        prevPos = pos;

        return speed;
    }

    public void End() => target = null;
    public bool IsActive => target != null;
}
