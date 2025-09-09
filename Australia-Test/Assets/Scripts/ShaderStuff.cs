using UnityEngine;

public class ShaderStuff : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float radius = 1.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shader.SetGlobalVector("_Position", transform.position);
        Shader.SetGlobalFloat("_Radius", radius);
    }
}
