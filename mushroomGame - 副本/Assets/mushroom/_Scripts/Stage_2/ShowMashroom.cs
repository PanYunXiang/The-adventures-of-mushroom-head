using UnityEngine;

public class ShowMashroom : MonoBehaviour
{
    public static ShowMashroom _instance;

    public GameObject mashroom;

    private int _count;

    public int Count
    {
        get { return _count; }
        set { _count = value; }
    }

    void Awake()
    {
        _instance = this;
    }

    void Update()
    {
        if (!mashroom.activeInHierarchy)
        {
            if (Count == 7)
                mashroom.SetActive(true);
        }
    }
}
