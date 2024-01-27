using UnityEngine;
using UnityEngine.Serialization;

public enum WireColor { blue, green, red, yellow };

public class PoweredWireStats : MonoBehaviour
{
    [SerializeField] public bool movable = false;
    [SerializeField] public bool moving = false;
    [SerializeField] public Vector3 startPosition;
    [FormerlySerializedAs("color")] [SerializeField] public WireColor wireColor;
    [SerializeField] public bool connected = false;
    [SerializeField] public Vector3 connectedPos;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
}
