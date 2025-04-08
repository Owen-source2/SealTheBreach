using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    Camera cam;
    Vector3 pos = new Vector3(200, 200, 0);
    Vector2 camMove;
    CharacterController control;
    [SerializeField]GameObject house;
    [SerializeField]float scrollSpeed;
    [SerializeField]GameObject scoreboard;
    void Start()
    {
        cam = GetComponent<Camera>();
        control=GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 realMove = new Vector3(camMove.x,0,camMove.y);
        control.Move(realMove*Time.deltaTime*100);
    }
    void OnMove(InputValue movement)
    {
        camMove=movement.Get<Vector2>();
    }
    void OnAttack()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            //place house
            Instantiate(house,hit.point,Quaternion.identity);
            Debug.Log(hit.point);
        }
        
    }
    void OnZoom(InputValue zoom)
    {
        if(zoom.Get<float>()>0.0f)
        {
            control.Move(transform.forward*-1*scrollSpeed*Time.deltaTime);
            Debug.Log("zooming out");
        }
        if(zoom.Get<float>()>0.0f)
        {
            control.Move(transform.forward*scrollSpeed*Time.deltaTime);
            Debug.Log("zooming in");
        }
        
    }
}
