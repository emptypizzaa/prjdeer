using UnityEngine;
using UnityEngine.EventSystems;

public class Stick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IDragHandler,
    IEndDragHandler
{
    [SerializeField] Camera cam;
    [SerializeField] RectTransform rt;
    [SerializeField] RectTransform parentRt;
    Vector2 dragBeginPos;
    Vector2 startPos;

    void Awake()
    {
        Instance = this;
    }

    public static Stick Instance;

    public Vector2 NormalizedDirection => rt.anchoredPosition;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRt, eventData.position, cam,
                out var localPoint))
        {
            dragBeginPos = localPoint;
            startPos = rt.anchoredPosition;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRt, eventData.position, cam,
                out var localPoint))
        {
            rt.anchoredPosition = startPos + localPoint - dragBeginPos;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // RectTransformUtility.ScreenPointToLocalPointInRectangle(rt, eventData.position, cam,
        //     out dragBeginLocalPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        rt.anchoredPosition = Vector2.zero;
    }
}