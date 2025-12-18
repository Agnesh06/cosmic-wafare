using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float Xlimit = 5f;
    [SerializeField] float Ylimit = 5f;
    [SerializeField] float RollFactor = 20f;
    [SerializeField] float PitchFactor = 10f;
    [SerializeField] float RotationSpeed = 2f;
    Vector2 movement;
    void OnEnable()   
    {
        Debug.Log("Script started — waiting for input...");
    }

    void FixedUpdate()
    {
        MovementTranslation();
    }
    
    void Update()
    {
        MovementTranslation();
        ProcessRotation();
    }


    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    // This line will prove if the input is working
    Debug.Log("Input Received: " + movement);
        movement = value.Get<Vector2>();

    }
    private void MovementTranslation()
    {
        float xoffset = movement.x * controlSpeed * Time.deltaTime;
        float yoffset = movement.y * controlSpeed * Time.deltaTime;
        float rawxpos = transform.localPosition.x + xoffset;
        float rawypos = transform.localPosition.y + yoffset;
        float clampx = Mathf.Clamp(rawxpos, -Xlimit, Xlimit);
        float clampy = Mathf.Clamp(rawypos, -Ylimit, Ylimit);
        transform.localPosition = new Vector3(clampx, clampy, 0f);
    }
private void ProcessRotation()
{
    Quaternion TargetRotationX = Quaternion.Euler(0f, 0f, -RollFactor * movement.x);
    Quaternion TargetRotationY = Quaternion.Euler(-PitchFactor * movement.y, 0f, 0f);


    Quaternion combinedTarget = TargetRotationX * TargetRotationY;

    transform.localRotation = Quaternion.Lerp(transform.localRotation, combinedTarget, Time.deltaTime * RotationSpeed);
}

}