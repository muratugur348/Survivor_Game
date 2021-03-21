using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mermiCarpisma : MonoBehaviour
{
    private GameObject hedef;
    private Text skor;
    public GameObject kalp;
    private float mesafe;
    private int skorPuan;
    // Start is called before the first frame update
    void Start()
    {

        hedef = GameObject.Find("oyuncu");
        GameObject textObject = GameObject.FindGameObjectWithTag("skor");
        skor = textObject.GetComponent<Text>();
        skorPuan = int.Parse(skor.text);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider collision)
    {        
        if (collision.gameObject.tag == "terrain")
            Destroy(gameObject);
        if (collision.gameObject.tag == "zombi")
        {
            mesafe = Vector3.Distance(collision.gameObject.transform.position, hedef.transform.position);
            if(mesafe>30)
            {
                skorPuan += 20;
                skor.text = skorPuan.ToString();
            }
            else if (mesafe > 15)
            {
                skorPuan += 10;
                skor.text = skorPuan.ToString();
            }
            else if (mesafe > 5)
            {
                skorPuan += 5;
                skor.text = skorPuan.ToString();
            }
            Instantiate(kalp, collision.gameObject.transform.position, Quaternion.identity);
            collision.gameObject.tag = "deadzombie";
            

            collision.gameObject.GetComponentInChildren<Animation>().Play("Zombie_Death_01");
            collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            collision.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            Quaternion ikinci = new Quaternion(collision.gameObject.transform.rotation.x - 90f,
                collision.gameObject.transform.rotation.y, collision.gameObject.transform.rotation.z, 
                collision.gameObject.transform.rotation.w);
            collision.gameObject.transform.LookAt(hedef.transform.position);
            Destroy(collision.gameObject, 1.667f);
            Destroy(gameObject);
            
        }
        if (collision.gameObject.tag == "deadzombie")
        {

            Destroy(gameObject);
        }
    }
}
