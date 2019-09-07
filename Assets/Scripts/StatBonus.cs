using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBonus
{
	public StatBonus( int bonusValue )
	{
		this.BonusValue = bonusValue;

		Debug.Log( "New stat bonus initiated." );
	}

	public int BonusValue { get; set; }
}
