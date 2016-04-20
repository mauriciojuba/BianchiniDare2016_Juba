using UnityEngine;
using System.Collections;

public class MakeTransparent : MonoBehaviour {

    private Renderer Render;
    private string initialShader;
    public bool turnOpaque = false;
    public bool beTransparent;
    float timer;
    private Color alphaDown;


    void Start()
    {
        Render = GetComponent<Renderer>();
    }
    void Update()
    {

        Debug.Log(timer);
        if (beTransparent)
        {
            Render.material.shader = Shader.Find("Transparent/Diffuse");
            timer = 0;
            alphaDown.a = 0.2f;
            Render.material.color = alphaDown;
            beTransparent = false;
        }
        
        if(!beTransparent)
        {
            timer += Time.deltaTime;
            if(timer >= 0.5f)
            {
                Destroy(this);
            }
        }
    }
    public void makeTransparent()
    {
        if (initialShader == null) {
            initialShader = Render.material.shader.name;
        }
        Mudar();
    }
    void Mudar()
    {
        beTransparent = true;
    }
    void OnDestroy()
    {
        Render.material.shader = Shader.Find(""+initialShader);
    }
}
