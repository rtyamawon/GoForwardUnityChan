using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {

	// キューブの移動速度
	private float speed = -0.2f;

	// 消滅位置
	private float deadLine = -10;
        AudioSource audioSource;

        public AudioClip impact;

        // 地面の位置
        private float groundLevel = -3.0f;

        private bool isGround = false;


	// Use this for initialization
	void Start () {
                this.audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		// キューブを移動させる
		transform.Translate (this.speed, 0, 0);

                 isGround = (transform.position.y > this.groundLevel) ? false : true;
		
		// 画面外に出たら破棄する
		if (transform.position.x < this.deadLine){
			Destroy (gameObject);
		}
		
	}

	void OnCollisionEnter2D (Collision2D other) {
             if (other.gameObject.tag == "Ground") {
                this.audioSource.Play();
             }
             if (other.gameObject.tag == "Block") {
               this.audioSource.Play();
               }
	}

}
