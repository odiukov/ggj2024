using System;
using Minigames;
using UnityEngine;

public class PoweredWireBehavior : MonoBehaviour
{
    bool mouseDown = false;
    [SerializeField] private PoweredWireStats poweredWireS;
    LineRenderer lineRenderer;

    [SerializeField] private float xOffsetSecondPoint = 0.4f;
    [SerializeField] private float xOffsetThirdPoint = 0.1f;

    public event Action MouseUp; 

    // Start is called before the first frame update
    void Start()
    {
        poweredWireS = gameObject.GetComponent<PoweredWireStats>();
        lineRenderer = gameObject.GetComponentInParent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ConnectLinesMinigameWindow1.Blocked)
        {
            return;
        }
        
        MoveWire();
        lineRenderer.SetPosition(3,
            new Vector3(gameObject.transform.position.x - xOffsetSecondPoint, gameObject.transform.position.y,
                gameObject.transform.position.z));
        lineRenderer.SetPosition(2,
            new Vector3(gameObject.transform.position.x - xOffsetThirdPoint, gameObject.transform.position.y,
                gameObject.transform.position.z));
    }

    void OnMouseDown()
    {
        mouseDown = true;
    }

    void OnMouseOver()
    {
        poweredWireS.movable = true;
    }

    void OnMouseExit()
    {
        if (!poweredWireS.moving)
        {
            poweredWireS.movable = false;
        }
    }

    void OnMouseUp()
    {
        mouseDown = false;
        if (!this.poweredWireS.connected)
            gameObject.transform.position = poweredWireS.startPosition;
        else
            gameObject.transform.position = poweredWireS.connectedPos;
        MouseUp?.Invoke();
    }

    void MoveWire()
    {
        if (mouseDown && poweredWireS.movable)
        {
            poweredWireS.moving = true;
            float mouseX = Input.mousePosition.x;
            float mouseY = Input.mousePosition.y;

            var screenToWorldPoint =
                Camera.main.ScreenToWorldPoint(new Vector3(mouseX, mouseY, transform.parent.position.z));
            screenToWorldPoint.z = 0;
            gameObject.transform.position = screenToWorldPoint;
        }
        else
            poweredWireS.moving = false;
    }
}