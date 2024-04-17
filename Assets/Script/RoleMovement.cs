using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleMovement : MonoBehaviour{
[SerializeField]
private float _moveSpeed;
private bool _isMoving = false;
private Vector2 _input;
[SerializeField]
private Rigidbody2D _role;
    void Start(){ 
        _role = GetComponent<Rigidbody2D>(); 
    }

    void FixedUpdate(){
        if(!_isMoving){
            _input.x = Input.GetAxisRaw("Horizontal");
            _input.y = Input.GetAxisRaw("Vertical");
            if(_input.x != 0){_input.y = 0;}
            _role.MovePosition(_role.position + _input*_moveSpeed * Time.fixedDeltaTime);
        }
    }
    // IEnumerator Move(Vector3 targetPos){
    //     while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon){
    //         transform.position
    //     }
    // }
}
