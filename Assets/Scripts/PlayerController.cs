using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hSpeed, hSpeedMax, vSpeed, dSpeed, dSpeedMax, dDuration, dTimer;
    private bool isDashing = false, canDash;
    private Rigidbody playerBody;
    [SerializeField] private int maxJumps;
    private int jumps;

    //private Vector3 prevPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerBody = GetComponent<Rigidbody>();
        jumps = maxJumps;
    }
    private void Update()
    {
        clampHorizontalMovement();
        if (isDashing) { dTimer -= Time.deltaTime; }
        if (dTimer <= 0 && isDashing) { StopDash(); isDashing = false; }
        //prevPosition = transform.position;
    }
    public void MoveHorizontal (Vector3 dir)
    {
        playerBody.AddRelativeForce(hSpeed * dir, ForceMode.VelocityChange);
    }
    public void MoveVertical()
    {
        if (jumps > 0)
        {
            jumps--;
            playerBody.AddForce(Vector3.up * vSpeed, ForceMode.Impulse);
        }
    }
    public void MoveDash()
    {
        if (isDashing || !canDash) { return; }
        isDashing = true; canDash = false;
        hSpeed += dSpeed; hSpeedMax += dSpeedMax;
        dTimer = dDuration;
    }
    private void StopDash ()
    {
        hSpeed -= dSpeed; hSpeedMax -= dSpeedMax;
        playerBody.linearVelocity = playerBody.linearVelocity * 0.1f;
    }
    void clampHorizontalMovement()
    {
        Vector3 dxz = new Vector3(playerBody.linearVelocity.x, 0, playerBody.linearVelocity.z);
        if (dxz.magnitude > hSpeedMax) { dxz = dxz.normalized * hSpeedMax; }
        playerBody.linearVelocity = new Vector3 (dxz.x, playerBody.linearVelocity.y, dxz.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            jumps = maxJumps;
            canDash = true;
        }
    }
}
