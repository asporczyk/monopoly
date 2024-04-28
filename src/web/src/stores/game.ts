import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useGameStore = defineStore('game', () => {
  const lastDiceRoll = ref(0)

  const isLastRollDouble = ref(false)

  function saveDiceRoll(rolls: number[]) {
    lastDiceRoll.value = rolls[0] + rolls[1]
    isLastRollDouble.value = rolls[0] === rolls[1]
  }

  return { lastDiceRoll, isLastRollDouble, saveDiceRoll }
})
