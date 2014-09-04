using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

static class ListExtensions {
	public static List<T> PickRandom<T>(this IList<T> list, int number) {
		List<T> other = new List<T>(list);
		other.Shuffle();
		other.RemoveRange(number, list.Count - number);
		return other;
	}

	public static void Shuffle<T>(this IList<T> list) {  
		System.Random rng = new System.Random();
		int n = list.Count;
		while (n > 1) {
			n--;
			int k = rng.Next(n + 1);
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
	}
	
	public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> f) {
		foreach (TSource element in source) {
			yield return f.Invoke(element);
		}
	}
	public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> pred) {
		foreach (TSource element in source) {
			if (pred.Invoke(element)) {
				yield return element;
			}
		}
	}
	public static TResult FoldL<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult, TResult> op, TResult initial) {
		TResult result = initial;
		foreach (TSource element in source) {
			result = op(element, result);
		}
		return result;
	}
	public static TResult FoldR<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult, TResult> op, TResult initial) {
		List<TSource> intermediate = new List<TSource>(source);
		intermediate.Reverse();
		return intermediate.FoldL(op, initial);
	}
}
