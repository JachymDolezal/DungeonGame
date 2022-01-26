using Godot;
using System;

public class Player : KinematicBody2D
{
	//Variables
	Vector2 direction;
	float movementSpeed = 200;
	float gravity = 20;
	float maxFallSpeed = 500;
	float minFallSpeed = 5;
	float jumpForce = 600;
	Sprite sprite;
	
	public override void _Ready()
	{
	sprite=(Sprite)GetNode("Sprite");
	}
	

 public override void _Process(float delta)
 {
	//player gravity
	direction.y += gravity;
	if(direction.y>maxFallSpeed){
		direction.y = maxFallSpeed;
	}
	if(IsOnFloor()){
		direction.y = minFallSpeed;
	}
	//movement controls
	 direction.x = Input.GetActionStrength("move_right")-Input.GetActionStrength("move_left");
	 direction.x*=movementSpeed;
	
	//player jump
	if(IsOnFloor()&&Input.IsActionJustPressed("jump")){
		direction.y = -jumpForce;
	}
	GD.Print(direction.y);
	
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
