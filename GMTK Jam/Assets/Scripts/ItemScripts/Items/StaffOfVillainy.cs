using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffOfVillainy : Item
{
    public string itemName = "Staff of Villainy";
    public Sprite sprite = null;
    public override void OnMeleeHit(GameObject enemy) {
        PlayerStats.hp -= 1;
    }

    public override void OnRangeHit(GameObject enemy) {
        PlayerStats.hp += 1;
        enemy.GetComponent<Stats>().hp += 1;
    }

    public override void OnMeleeUse(GameObject attack) {
        
    }

    public override void OnRangeUse(GameObject attack) {
        
    }

    public override void OnGain() {
        base.OnGain();
    }

    public override void OnDrop() {
        base.OnDrop();
    }

    public override void OnHurt() {
        
    }

    public override string GetName() {
        return itemName;
    }
    public override Sprite GetSprite() {
        return sprite;
    }
}
