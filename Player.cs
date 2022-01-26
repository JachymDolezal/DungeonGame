using Godot;
using System;

public class Player : KinematicBody2D
{
	//Variables
	Vector2 direction;
	float _movementSpeed = 200;
	float _gravity = 30;
	float _maxFallSpeed = 500;
	float _minFallSpeed = 5;
	float _jumpForce = 500;
	Sprite sprite;
	public override void _Ready()
	{
	sprite=(Sprite)GetNode("Sprite");
	}
	public static void _Attack(){
		GD.Print("ok");
		//Todo implement attacking
	}
	public override void _PhysicsProcess(float delta)
	{
		//player gravity
		direction.y += _gravity;
		if(direction.y>_maxFallSpeed){
			direction.y = _maxFallSpeed;
		}
		if(IsOnFloor()){
			direction.y = _minFallSpeed;
		}
		//movement controls
		direction.x = Input.GetActionStrength("move_right")-Input.GetActionStrength("move_left");
		direction.x*= _movementSpeed;
		//player jump
		if(IsOnFloor()&&Input.IsActionJustPressed("jump")){
			direction.y = -_jumpForce;
		}
		//Player attack
		if(Input.IsActionJustPressed("attack")){
			_Attack();
		}
		//direction of sprite
		if(direction.x > 0){
			sprite.FlipH = false;
		}
		else if(direction.x < 0){
			sprite.FlipH=true;
		}
		direction=MoveAndSlide(direction,Vector2.Up);
	}

}


