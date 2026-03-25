using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    [SerializeField] private Transform[] layers;
    [SerializeField] private float[] coeff;

    private int LayerConst;
    void Start()
    {
        LayerConst = layers.Length;
    }
    void Update()
    {
        for(int i = 0; i < LayerConst; i++)
        {
            layers[i].position = transform.position * coeff[i];
        }
    }
}
