using System.Collections;
using UnityEngine;

public class Controller : MonoBehaviour {

    // Use this for initialization

    public float moveSpeed = 6;
    

    Rigidbody rigidbody;
    

    Camera viewCamera;
    
    Vector3 velocity;

    AudioSource walkSound;

    float currentAxisHorizontal = 0;
    float currentAxisVertical = 0;
    
    void Start () {

        rigidbody = GetComponent<Rigidbody>();
        viewCamera = Camera.main;
        walkSound = GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        
        transform.LookAt(mousePos + Vector3.up * transform.position.y);
        
        velocity = this.getVector3DirectionWalk().normalized * moveSpeed;

    }

    void FixedUpdate() {

        rigidbody.MovePosition(rigidbody.position + velocity * Time.fixedDeltaTime);
        

    }
    void walkEvents() {        
        if(this.isWalking()) {
            if (!walkSound.isPlaying) {
                walkSound.Play();
            }
        }
        else{
            if (walkSound.isPlaying) {
                walkSound.Stop();
            }
        }
        
    }
    bool isWalking(){
        if ((currentAxisHorizontal == 0)&&(currentAxisVertical == 0)){
            return false;
        }
        return true;
    }
    Vector3 getVector3DirectionWalk(){
        currentAxisHorizontal = Input.GetAxisRaw("Horizontal");
        currentAxisVertical = Input.GetAxisRaw("Vertical");
        this.walkEvents();

        return new Vector3(currentAxisHorizontal,0,currentAxisVertical);
    }
}
