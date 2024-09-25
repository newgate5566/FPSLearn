using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class player : MonoBehaviour
{
    public Rigidbody rb;
    public float movespeed;
    public float lookspeed;
    private float anglex, angley;
    public Animator animator;
    public float jump;
    public Transform qinagkou;
    public GameObject xue;
    public GameObject gress;
    public GameObject fenshe;
    public GameObject shugan;
    public GameObject huishe;
    public GameObject lu;
    public GameObject lanshe;
    public float attackcd;
    public float decattackcd;
    public GameObject texiao;
    public GameObject qiangxiao;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        look();
        Attack();
        jumps();
    }
    public void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 momentv = transform.forward * v * movespeed * Time.deltaTime;
        transform.position += momentv;
        Vector3 momenth = transform.right * h * movespeed * Time.deltaTime;
        transform.position += momenth;
    }
    public void look()
    {
        float mousex = Input.GetAxis("Mouse X");
        float lookrigt = mousex * lookspeed;
        anglex = lookrigt + anglex;
        float mousey = -Input.GetAxis("Mouse Y");      
        float lookup = mousey * lookspeed;
        angley =Mathf.Clamp(angley+lookup,-60,60);

        transform.eulerAngles = new Vector3(angley, anglex, transform.eulerAngles.z);
    }
    private void Attack()
    {
       
        if (Input.GetMouseButtonDown(0)&&Time.time-decattackcd<=attackcd)
        {
            animator.SetTrigger("Attack");
            RaycastHit hit;
            attackcd= Time.time;
            if (Physics.Raycast(qinagkou.position, qinagkou.forward,out hit, 5))
            {
                //if (hit.collider.CompareTag("diren"))
                //{
                //    Instantiate(xue,hit.point,Quaternion.identity);
                //}
                switch (hit.collider.tag)
                {
                    case "diren":
                        Instantiate(xue, hit.point, Quaternion.identity);
                        break;
                    case "gress":
                        Instantiate(gress, hit.point, Quaternion.identity);
                        break;      
                    case "fenshe":
                        Instantiate(fenshe, hit.point, Quaternion.identity);
                        break;
                    case "shugan":
                        Instantiate(shugan, hit.point, Quaternion.identity);
                        break;
                    case "huishe":
                        Instantiate(huishe, hit.point, Quaternion.identity);
                        break;
                    case "lu":
                        Instantiate(lu, hit.point, Quaternion.identity);
                        break;
                    case "lanshe":
                        Instantiate(lanshe, hit.point, Quaternion.identity);
                        break;
                    

                }
            }
        }
       
        
    }
    public void jumps()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jump*Vector3.up);
        }
    }
}
