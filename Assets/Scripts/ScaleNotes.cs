using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleNotes : Singleton<ScaleNotes>
{
    [SerializeField]
    private AudioSource audioSource;
    public AudioSource AudioSource => audioSource;

    [SerializeField]
    private AudioClip c6;
    public AudioClip C6 => c6;

    [SerializeField]
    private AudioClip d6;
    public AudioClip D6 => d6;

    [SerializeField]
    private AudioClip e6;
    public AudioClip E6 => e6;

    [SerializeField]
    private AudioClip f6;
    public AudioClip F6 => f6;

    [SerializeField]
    private AudioClip g6;
    public AudioClip G6 => g6;

    [SerializeField]
    private AudioClip a6;
    public AudioClip A6 => a6;

    [SerializeField]
    private AudioClip b6;
    public AudioClip B6 => b6;

    [SerializeField]
    private AudioClip c7;
    public AudioClip C7 => c7;

    [SerializeField]
    private AudioClip d7;
    public AudioClip D7 => d7;
}
