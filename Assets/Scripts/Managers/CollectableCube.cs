using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableCube : MonoBehaviour
{
    public bool isCollected;
    public GameObject firstCube;
    public AudioSource gemSound;

    public AudioSource boxSound;
    void Start()
    {
        isCollected = false;
    }
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && !IsCollected())
        {
            if (this.gameObject.tag=="Gem")
            {
                gemSound.Play();
                GemUpdater.gemCount +=1;
                Destroy(gameObject);
            }
            else
            {
                this.gameObject.transform.parent = firstCube.transform;
                firstCube.transform.position += Vector3.up * 1;
                transform.localPosition = Vector3.down * (firstCube.transform.childCount-1);
                MakeCollected();
            }
        }
        else if(other.gameObject.tag == "Collectable")
        {
            if(other.gameObject.GetComponent<CollectableCube>().IsCollected() && !IsCollected())
            {
                if (this.gameObject.tag=="Gem")
                {
                    gemSound.Play();
                    GemUpdater.gemCount +=1;
                    Destroy(gameObject);
                }
                else
                {
                    this.gameObject.transform.parent = firstCube.transform;
                    firstCube.transform.position += Vector3.up * 1;
                    transform.localPosition = Vector3.down * (firstCube.transform.childCount-1);
                    MakeCollected();
                }
            }
        }
        else if (other.gameObject.tag=="Obstacle" && IsCollected())
        {
            this.gameObject.transform.SetParent(null,true);
        }

    }

    public bool IsCollected()
    {
        return isCollected;
    }

    public void MakeCollected()
    {
        isCollected = true;
        boxSound.Play();
    }
}
