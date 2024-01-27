using UnityEngine;

public enum Color { blue, green, red, yellow };

public class PoweredWireStats : MonoBehaviour
{
    [SerializeField] public bool movable = false;
    [SerializeField] public bool moving = false;
    [SerializeField] public Vector3 startPosition;
    [SerializeField] public Color color;
    [SerializeField] public bool connected = false;
    [SerializeField] public Vector3 connectedPos;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }
}
