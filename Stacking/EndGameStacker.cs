using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameStacker : MonoBehaviour
{
    public Stack<Transform> Stack { get { return _stack; } }
    Stack<Transform> _stack = new Stack<Transform>();

    [SerializeField] public ParticleSystem Fx;

}
