using UnityEngine;

public class DragOperation
{
    private Transform target;
    private Vector3 offset;
    private readonly Vector3 min, max;
    private readonly SwipeDetector swipe;

    public DragOperation(Vector2 min, Vector2 max, float swipeThreshold)
    {
        this.min = min;
        this.max = max;
        this.swipe = new SwipeDetector(swipeThreshold);
    }

    public void Begin(Transform t, Vector3 pointerWorld)
    {
        target = t;
        offset = t.position - pointerWorld;
        swipe.Reset(t.position);
    }

    public float? UpdatePosition(Vector3 pointerWorld, float deltaTime)
    {
        if (target == null) return null;
        var pos = pointerWorld + offset;
        Debug.Log($"pointerWorld={pointerWorld}, offset={offset}, pos(before clamp)={pos}, min={min}, max={max}");
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        pos.z = 0f;
        target.position = pos;
        return swipe.Update(pos, deltaTime);
    }

    public void End() => target = null;
    public bool IsActive => target != null;
}
