using System;

public struct Maybe<T>
{
	private readonly bool hasValue;
	public bool HasValue { get { return hasValue; } }
	
	private readonly T value;
	public T Value
	{
		get
		{
			if (!hasValue)
			{
				throw new InvalidOperationException();
			}
			return value;
		}
	}
	
	public Maybe(T value)
	{
		this.hasValue = true;
		this.value = value;
	}
	
	public static implicit operator Maybe<T>(T value)
	{
		return new Maybe<T>(value);
	}
}