using UnityEngine;
using UnityEngine.InputSystem;

public class Control : MonoBehaviour
{
    Camera cam;
    Vector3 pos = new Vector3(200, 200, 0);
    Vector2 camMove;
    CharacterController control;
    [SerializeField]GameObject placedObject;
    [SerializeField]float scrollSpeed;
    [SerializeField]GameObject ui;
    GameObject built;
    LayerMask blockPlacement;
    LayerMask blockPlacementRay;
    public string selected;
    void Start()
    {
        blockPlacement = LayerMask.GetMask("IgnoreRaycast","Default");
        blockPlacementRay = LayerMask.GetMask("TransparentFX");
        built=placedObject;
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
        if(Physics.Raycast(ray, out hit,999f,blockPlacementRay))
        {
            //check if house would touch anything 
            Collider[] hitColliders = Physics.OverlapBox(hit.point, built.GetComponent<BoxCollider>().size, built.transform.rotation,blockPlacement);
            //place house
            if(hitColliders==null||hitColliders.Length==0)
            {
                built=Instantiate(placedObject,hit.point + new Vector3(0.0f,hit.point.y+1f,0.0f),Quaternion.identity);
            }
            else
            {
                if(true)
                {
                    Debug.Log(hitColliders[0]);
                }
                Debug.Log("can't place");
            }
            
        }
        //Debug.Log(hit);
        
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
    public void SwitchBuilding(string nowBuilding)
    {
        selected=nowBuilding;
        if(nowBuilding=="House")
        {
            placedObject=Resources.Load<GameObject>("House");
            Debug.Log(placedObject);
        }
        else if(nowBuilding=="Soldier")
        {
            placedObject=Resources.Load<GameObject>("Archer");
        }
    }
}
