using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float hSpeed, hSpeedMax, vSpeed;
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
        //prevPosition = transform.position;
    }
    public void MoveHorizontal (Vector3 dir)
    {
        playerBody.AddRelativeForce(hSpeed * dir);
    }
    public void MoveVertical()
    {
        if (jumps > 0)
        {
            jumps--;
            playerBody.AddForce(Vector3.up * vSpeed, ForceMode.VelocityChange);
        }
    }
    void clampHorizontalMovement()
    {
        Vector3 dxz = new Vector3(playerBody.linearVelocity.x, 0, playerBody.linearVelocity.z);
        if (dxz.magnitude > hSpeedMax) { dxz = dxz.normalized * hSpeedMax; }
        playerBody.linearVelocity = new Vector3 (dxz.x, playerBody.linearVelocity.y, dxz.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumps = maxJumps;
        }
    }
}
