using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEye : Item
{
   public void onMeleeHit(GameObject enemy) {

   }

    public void onRangeHit(GameObject enemy) {

    }

    public void onMeleeUse(GameObject player, GameObject attack) {

    }

    public void onRangeUse(GameObject player, GameObject attack) {
        
    }

    public void onGain(GameObject player) {
        Stats playerStats = player.GetComponent<Stats>()
        playerStats.hp *= 3;

    }

    public void onDrop(GameObject player) {

    }

    public void onHit(GameObject player) {

    }
}
