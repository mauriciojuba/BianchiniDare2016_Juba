using UnityEngine;
using System.Collections;

public class FloatingTextController : MonoBehaviour
{
    
    public FloatingText popupText;
    private GameObject canvas;
    public static FloatingTextController Instance;
    void Start()
    {
        Instance = this;
        canvas = GameObject.Find("Canvas");
    }

    public void CreateFloatingText(string text, Transform location)
    {
        FloatingText instance = Instantiate(popupText);
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(new Vector3(location.position.x + Random.Range(-.2f, .2f), location.position.y + Random.Range(-.2f, .2f), location.position.z));

        instance.transform.SetParent(canvas.transform, false);
        instance.transform.position = screenPosition;
        instance.SetText(text);
    }
}