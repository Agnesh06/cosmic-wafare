
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform Crossheir;
    [SerializeField] Transform Target;
    [SerializeField] float TargetDistance = 10f;
    bool isFiring = false;
    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MoveCrossheir();
        MoveTarget();
        Aimtargets();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    public void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmissionModule = laser.GetComponent<ParticleSystem>().emission;
            emmissionModule.enabled = isFiring;
        }
    }
    public void MoveCrossheir()
    {
        Crossheir.position = Input.mousePosition;
    }
    public void MoveTarget()
    {
        Vector3 targetPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, TargetDistance);
        Target.position = Camera.main.ScreenToWorldPoint(targetPosition);
    }
    public void Aimtargets()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 targetDirection = Target.position - this.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(targetDirection);
            laser.transform.rotation = rotationToTarget;

        }
    }
    private void OnDisable()
    {
        // Stop firing immediately when the script is disabled
        isFiring = false;

        foreach (GameObject laser in lasers)
        {
            if (laser != null)
            {
                var emissionModule = laser.GetComponent<ParticleSystem>().emission;
                emissionModule.enabled = false;
            }
        }
    }
}