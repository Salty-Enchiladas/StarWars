using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FireMissile : MonoBehaviour {

    public GameObject missile;
    public float missileRechargeLength;
    public float missileCooldown;    
    public GameObject target;
    public int missileCount;
    public int missileMax;
    public GameObject missile1Img;
    public GameObject missile2Img;
    public GameObject missile3Img;

    float lastShot;

    // Use this for initialization
    void Start () {
        //missileZone = GameObject.Find("MissileZone");
        //InvokeRepeating("FindEnemy", 1f, 0.5f);
    }
	
	// Update is called once per frame
	void Update () {
        FindEnemy();

        if (Input.GetButtonDown("Fire2") && Time.time > (lastShot + missileCooldown) && target != null && missileCount > 0)
        {
            Missile();
        }
        else if(Input.GetButtonDown("Fire2") && target == null)
        {
            print("no target");
        }

        switch (missileCount)
        {
            case 3:
                missile1Img.SetActive(true);
                missile2Img.SetActive(true);
                missile3Img.SetActive(true);
                break;
            case 2:
                missile1Img.SetActive(true);
                missile2Img.SetActive(true);
                missile3Img.SetActive(false);
                break;
            case 1:
                missile1Img.SetActive(true);
                missile2Img.SetActive(false);
                missile3Img.SetActive(false);
                break;
            case 0:
                missile1Img.SetActive(false);
                missile2Img.SetActive(false);
                missile3Img.SetActive(false);
                break;
            default:
                break;
        }
    }

    void Missile()
    {
        lastShot = Time.time;
        Instantiate(missile, transform.position, transform.rotation);
        missileCount--;
        if (missileCount < missileMax && !(missileCount >= missileMax))
        {
            Invoke("MissileRecharge", missileRechargeLength);
        }
    }

    void MissileRecharge()
    {
        missileCount++;
    }

    void FindEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Enemy");
        if(target == null)
        {
            print("no target");
            
        }
        else if(!target.activeInHierarchy)
        {
            print("no target");
        }
        else if(target.activeInHierarchy)
        {
            target.GetComponent<EnemyState>().isTarget = true;
        }

        //if(target == null)
        //{
        //    target = missileZone.GetComponent<MissileZone>().targetList[1];
        //}   
        //else if(target != null)
        //{
        //    missileZone.GetComponent<MissileZone>().targetList.Sort();
        //}        
        
        
    }

}
