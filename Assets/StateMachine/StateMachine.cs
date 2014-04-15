﻿using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {
	public enum Transition { Enter = 0, Stay, Exit }

	public State current;

	private Transition _transition;
	private State _next;

	public void Move(State next) {
		_next = next;
		_transition = Transition.Exit;
	}

	void Update () {
		if (current == null)
			return;

		switch (_transition) {
		case Transition.Enter:
			if (current.Enter != null)
				current.Enter(this, current);
			_transition = Transition.Stay;
			break;
		case Transition.Stay:
			if (current.Stay != null)
				current.Stay(this, current);
			break;
		case Transition.Exit:
			if (current.Exit != null)
				current.Exit(this, current);
			current = _next;
			_transition = Transition.Enter;
			break;
		}
	}
}
