using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class InputManager : MonoBehaviour
{
    public UnityEvent<Vector3> HorizontalMovement;
    public UnityEvent VerticalMovement;
    public UnityEvent<Vector3> CameraMovement;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start ()
    {
        if (HorizontalMovement == null) { HorizontalMovement = new UnityEvent<Vector3>(); }
        if (VerticalMovement == null) { VerticalMovement = new UnityEvent(); }
        if (CameraMovement == null) { CameraMovement = new UnityEvent<Vector3>(); }
            

    }

    // Update is called once per frame
    void Update ()
    {
        Vector3 hVec = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        hVec = hVec.normalized;
        HorizontalMovement.Invoke(hVec);
        
        if (Input.GetKeyDown(KeyCode.Space)) { Debug.Log("Jump pressed");  VerticalMovement.Invoke(); }
        Vector3 cVec = Input.mousePositionDelta;
        CameraMovement.Invoke(cVec);
        
    }
}
