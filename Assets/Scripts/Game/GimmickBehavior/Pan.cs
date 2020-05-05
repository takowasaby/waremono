using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Pan : MonoBehaviour
{
    private SoundHolder soundHolder;

    [Inject]
    public void Construct(SoundHolder soundHolder)
    {
        this.soundHolder = soundHolder;
    }

    private void OnCollisionEnter2D(Collision2D _)
    {
        this.soundHolder.pan.Play();
    }
}
