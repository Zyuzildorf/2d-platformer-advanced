using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    
    public bool OnMouseButtonPressed { get; private set; }
    public bool OnSpacebarPressed { get; private set; }
    public float Direction { get; private set; }
    
    private void Update()
    {
        CheckKeyboardinput();
        CheckMouseInput();
        CheckSpaceBarInput();
    }

    private void CheckMouseInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnMouseButtonPressed = true;
        }
        else
        {
            OnMouseButtonPressed = false;
        }
    }

    private void CheckKeyboardinput()
    {
        Direction = Input.GetAxis(Horizontal);
    }

    private void CheckSpaceBarInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnSpacebarPressed = true;
        }
        else
        {
            OnSpacebarPressed = false;
        }
    }
}