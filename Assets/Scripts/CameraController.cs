using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cSpeed;
    GameObject player;
    public void Start()
    {
        player = transform.parent.gameObject;
    }
    public void MoveCamera(Vector3 dir)
    {
        Vector3 dirCamera = new Vector3(dir.y, 0, 0)
              , dirPlayer = new Vector3(0, dir.x, 0);

        //Debug.Log("Camera movement vector: " + dir);
        this.transform.Rotate(dirCamera * cSpeed * Time.deltaTime * -1);
        player.transform.Rotate(dirPlayer *  cSpeed * Time.deltaTime);
    }
}
