using UnityEngine;

public class PlayerMove : MonoBehaviour
{
  Vector2 V_pos;
  Rigidbody2D comp_RGBD2D;
  public float speed = 5;

//   public GameObject gameObj = eulerAngles;

  private Animator animus;
  void Awake()
  {
    V_pos = new Vector2();
    comp_RGBD2D = GetComponent<Rigidbody2D>();
    animus = GetComponent<Animator>();
  }


  void Update()
  {
    V_pos.x = Input.GetAxisRaw("Horizontal") * speed;
    V_pos.y = Input.GetAxisRaw("Vertical") * speed;
    
    comp_RGBD2D.velocity = V_pos;

    if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) animus.SetBool("isRun", true);
    if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) animus.SetBool("isRun", false);

    
  }

//   void Rotate() { 
    
//   }
}
