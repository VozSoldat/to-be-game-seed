using UnityEngine;

public class StatBar : MonoBehaviour
{
    public float Point, MaxPoint, Width, Height;
    [SerializeField]
    private RectTransform PointBar;
    void Update()
    {
        
        if (Point <= 5)
        {
            SetPoint(Point);
        }
    }
    public void SetPoint(float point)
    {
        Point = point;
        float newWidth = (Point / MaxPoint) * Width;
        PointBar.sizeDelta = new Vector2(newWidth, Height);
    }

}
