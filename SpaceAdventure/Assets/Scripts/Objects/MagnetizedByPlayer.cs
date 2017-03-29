using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MagnetizedByPlayer : MonoBehaviour
{
    public enum Type { Attract, Repel }

    [SerializeField]
    private float RepelForce = 1000.0f;

    [SerializeField]
    private float MinimumDistance = 1.0f;

    [SerializeField]
    private Type MagnetizeType = Type.Repel;

    private GameObject mPlayer;
    private Rigidbody mBody;

    void Awake()
    {
        mPlayer = GameObject.FindGameObjectWithTag("Player");
        mBody = GetComponent<Rigidbody>();
    }

	void Update()
    {
        if( mPlayer != null)
        {
            Vector3 difference = MagnetizeType == Type.Repel ? transform.position - mPlayer.transform.position : mPlayer.transform.position - transform.position;
            if( difference.magnitude <= MinimumDistance )
            {
                if (this.tag == "Enemy" && difference.magnitude <= 20.0f)
                {
                    mBody.velocity = Vector3.zero;
                    transform.RotateAround(Vector3.zero, Vector3.up, 20 * Time.deltaTime);
                }
                else
                {
                    mBody.AddForce(difference * RepelForce * Time.deltaTime);
                }
            }
        }		
	}
}
