using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {

    public Rigidbody _player;
    public float timeStamp;
    public abstract void Execute();
}

class MoveLeft : Command
{

    private float _force;

    public MoveLeft(Rigidbody player, float force)
    {
        _player = player;
        _force = force;
    }
    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        _player.AddForce(-_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
class MoveRight : Command
{

    private float _force;

    public MoveRight(Rigidbody player, float force)
    {
        _player = player;
        _force = force;
    }
    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        _player.AddForce(_force * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }

    
}

class MoveForward : Command
{
    private float _force;

    public MoveForward(Rigidbody player, float force)
    {
        _player = player;
        _force = force;
    }
    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        _player.AddForce(0, 0, _force * Time.deltaTime, ForceMode.VelocityChange);
    }
}

class MoveBackwards : Command
{
    private float _force;

    public MoveBackwards(Rigidbody player, float force)
    {
        _player = player;
        _force = force;
    }
    public override void Execute()
    {
        timeStamp = Time.timeSinceLevelLoad;
        _player.AddForce(0, 0, -_force * Time.deltaTime, ForceMode.VelocityChange);
    }
}
