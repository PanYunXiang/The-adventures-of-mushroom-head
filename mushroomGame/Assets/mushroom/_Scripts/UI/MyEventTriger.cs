using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// 自定义按钮事件
/// </summary>
public class MyEventTriger : EventTrigger
{
    public delegate void VoidDelegate(GameObject go);

    public VoidDelegate onDown;
    public VoidDelegate onUp;

    public static MyEventTriger GetEvent(GameObject go)
    {
        MyEventTriger listener = go.GetComponent<MyEventTriger>();
        if (listener == null)
        {
            listener = go.AddComponent<MyEventTriger>();
        }
        return listener;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        if (onDown != null)
            onDown(gameObject);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (onUp != null)
            onUp(gameObject);
    }
}
