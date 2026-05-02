using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int LayerCount;
    void Start()
    {
        LayerCount = layers.Length;
    }
    void Update()
    {
        for(int i = 0; i < LayerCount; i++)
        {
            layers[i].position = transform.position * coeff[i];
        }
    }
}
