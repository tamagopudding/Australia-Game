using UnityEngine;

public class Area1Trigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        Shader.SetGlobalVector("_AreaPosition1", transform.position);
    }
}
