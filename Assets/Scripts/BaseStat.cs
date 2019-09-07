using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
	public BaseStat( int baseValue,string statName,
		string statDesc )
	{
		this.BaseAdditives = new List<StatBonus>();
		this.BaseValue = baseValue;
		this.StatName = statName;
		this.StatDesc = statDesc;
	}

	public void AddStatBonus( StatBonus toAdd )
	{
		this.BaseAdditives.Add( toAdd );
	}

	public void RemoveStatBonus( StatBonus toRemove )
	{
		this.BaseAdditives.Remove( toRemove );
	}

	public int GetCalculatedStatValue()
	{
		this.BaseAdditives.ForEach(
			x => this.FinalValue += x.BonusValue );
		FinalValue += BaseValue;

		return FinalValue;
	}

	public List<StatBonus> BaseAdditives { get; set; }
	public int BaseValue { get; set; }
	public string StatName { get; set; }
	public string StatDesc { get; set; }
	public int FinalValue { get; set; }
}
