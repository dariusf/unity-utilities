using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility {
	public static void Assert(bool condition, string message) {
		if (!condition) {
			throw new Exception("Assertion failure: " + message);
		}
	}

	public static List<int> Range(int startInclusive, int endExclusive) {
		List<int> result = new List<int>();
		for (int i=startInclusive; i<endExclusive; i++) {
			result.Add(i);
		}
		return result;
	}

	public static string Stringify<TSource>(IEnumerable<TSource> source) {
		string s = "";
		foreach (TSource element in source) {
			s += element.ToString() + " ";
		}
		return s;
	}

	public static Color Colour(string str) {
		if (str.StartsWith ("#")) {
			str = str.Substring(1);
		}
		if (str.Length < 6) return Color.white;
		float r = Convert.ToInt32 (str.Substring(0, 2), 16) / 255.0f;
		float g = Convert.ToInt32 (str.Substring(2, 2), 16) / 255.0f;
		float b = Convert.ToInt32 (str.Substring(4, 2), 16) / 255.0f;
		if (str.Length == 8) {
			float a = Convert.ToInt32 (str.Substring(6, 8), 16) / 255.0f;
			return new Color (r, g, b, a);
		} else {
			return new Color (r, g, b);
		}
	}

	public static string TimeFormat(int secs) {
		int mins = secs / 60;
		secs = secs % 60;
		return mins + ":" + (secs < 10 ? "0" : "") + secs;
	}

	public static T AnyOf<T>(params T[] stuff) {
		return stuff[UnityEngine.Random.Range(0, stuff.Length)];
	}

	public static string Reverse(string s) {
		char[] charArray = s.ToCharArray();
		Array.Reverse( charArray );
		return new string( charArray );
	}
}
