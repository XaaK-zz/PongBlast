﻿// Author : Henri Couvreur for hiloqo, 2019
// Contact : couvreurhenri@gmail.com, hiloqo.games@gmail.com

using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The main class of the hinput package, from which you can access gamepads.
/// </summary>
public static class hinput {
	// --------------------
	// GAMEPADS
	// --------------------

	private static hGamepad _anyGamepad;
	/// <summary>
	/// A virtual gamepad that returns the inputs of every gamepad at once.
	/// Its name, full name, index and type are those of the gamepad that is currently being pushed (except if you use
	/// "internal" properties).
	/// </summary>
	/// <remarks>
	/// This gamepad returns the biggest value for buttons and triggers, and averages every pushed stick.
	/// </remarks>
	/// <example>
	/// - If player 1 pushed their A button and player 2 pushed their B button,
	/// both the A and the B button of anyGamepad will be pressed.
	/// - If player 1 pushed their left trigger by 0.24 and player 2 pushed theirs by 0.46,
	/// the left trigger of anyGamepad will have a position of 0.46.
	/// - If player 1 positioned their right stick at (-0.21, 0.88) and player 2 has theirs at (0.67, 0.26),
	/// the right stick of anyGamepad will have a position of (0.23, 0.57).
	/// </example>
	public static hGamepad anyGamepad { 
		get { 
			hUpdater.CheckInstance();
			if (_anyGamepad == null) {
				_anyGamepad = new hAnyGamepad();
			} else {
				hUpdater.UpdateGamepads ();
			}

			return _anyGamepad; 
		}
	}

	private static List<hGamepad> _gamepad;
	/// <summary>
	/// A list of 8 gamepads, labelled 0 to 7.
	/// </summary>
	/// <remarks>
	/// Gamepad disconnects are handled by the driver, and as such will yield different results depending on your operating system.
	/// </remarks>
	public static List<hGamepad> gamepad { 
		get {
			hUpdater.CheckInstance();
			if (_gamepad == null) {
				syncGamePads();
			} else {
				hUpdater.UpdateGamepads ();
			} 

			return _gamepad; 
		} 
	}

	public static void syncGamePads()
	{
		_gamepad = new List<hGamepad>();
		string[] names = Input.GetJoystickNames();
		for (int i = 0; i < System.Math.Min(names.Length, hUtils.maxGamepads); i++)
		{
			if (names[i] != "")
			{
				_gamepad.Add(new hGamepad(i));
			}
		}
	}
	
	/// <summary>
	/// A virtual button that returns every input of every gamepad at once.
	/// It shares its name, full name and gamepad with the input that is currently being pushed (except if you use
	/// "internal" properties).
	/// </summary>
	public static hPressable anyInput { get { return anyGamepad.anyInput; } }
}