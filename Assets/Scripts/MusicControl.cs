using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour {

	
	public AudioMixerSnapshot Verse;
	public AudioMixerSnapshot Chorus;
	public AudioMixerSnapshot VerseSlow;
	public AudioMixerSnapshot ChorusSlow;
	public float bpm = 129;


	private float m_TransitionIn;
	private float m_TransitionOut;
	private float m_QuarterNote;

	// Use this for initialization
	void Start () 
	{
		m_QuarterNote = 60 / bpm;
		m_TransitionIn = m_QuarterNote;
		m_TransitionOut = m_QuarterNote * 2;
	
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("MusicChange"))
		{
				Chorus.TransitionTo(m_TransitionIn);
		}
		if (other.CompareTag("VerseSlower"))
		{
				VerseSlow.TransitionTo(m_TransitionIn);
		}
		if (other.CompareTag("ChorusSlower"))
		{
				ChorusSlow.TransitionTo(m_TransitionIn);
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("MusicChange"))
		{
			Verse.TransitionTo(m_TransitionOut);
		}
		if (other.CompareTag("VerseSlower"))
		{
			Verse.TransitionTo(m_TransitionOut);
		}
		if (other.CompareTag("ChorusSlower"))
		{
			Chorus.TransitionTo(m_TransitionOut);
		}
	}

}
