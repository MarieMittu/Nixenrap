using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Parent class responsible for extracting beats from..
/// ..spectrum value given by AudioSpectrum.cs
/// </summary>
public class AudioSyncer : MonoBehaviour
{

	public float bias;
	public float timeStep;
	public float timeToBeat;
	public float restSmoothTime;

	private float m_previousAudioValue;
	private float m_audioValue;
	private float m_timer;

	protected bool m_isBeat;

	int numBeat = 0;
	int numPressed = 0;
	private bool beatCatch = false;

	/// <summary>
	/// Inherit this to cause some behavior on each beat
	/// </summary>
	public virtual void OnBeat()
	{
		numBeat += 1;
		Debug.Log("beat" + numBeat);
	

			beatCatch = true;
		StartCoroutine(CatchBeat());


		m_timer = 0;
		m_isBeat = true;
	}

	private IEnumerator CatchBeat()
    {
		beatCatch = true;
		yield return new WaitForSeconds(0.1f);
		beatCatch = false;
    }

	/// <summary>
	/// Inherit this to do whatever you want in Unity's update function
	/// Typically, this is used to arrive at some rest state..
	/// ..defined by the child class
	/// </summary>
	public virtual void OnUpdate()
	{
		// update audio value
		m_previousAudioValue = m_audioValue;
		m_audioValue = AudioSpectrum.spectrumValue;

		// if audio value went below the bias during this frame
		if (m_previousAudioValue > bias &&
			m_audioValue <= bias)
		{
			// if minimum beat interval is reached
			if (m_timer > timeStep)
				OnBeat();
		}

		// if audio value went above the bias during this frame
		if (m_previousAudioValue <= bias &&
			m_audioValue > bias)
		{
			// if minimum beat interval is reached
			if (m_timer > timeStep)
				OnBeat();
		}

		m_timer += Time.deltaTime;

		
	}

	private void Update()
	{
		OnUpdate();
	
		if(beatCatch && Input.GetKeyDown(KeyCode.Return))
        {
			numPressed += 1;
			Debug.Log("beat return " + numPressed);
		} else if (!beatCatch && Input.GetKeyDown(KeyCode.Return))
        {
			numPressed -= 1;
			Debug.Log("boooooo!" + numPressed);
        }

	}

}