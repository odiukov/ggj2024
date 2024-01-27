using UnityEngine;
using UnityEngine.Serialization;

public class UnpoweredWireStats : MonoBehaviour
{

    [SerializeField] public bool connected = false;
    [FormerlySerializedAs("color")] [SerializeField] public WireColor wireColor;
    [SerializeField] public GameObject poweredLight;
    [SerializeField] public GameObject unpoweredLight;
}
