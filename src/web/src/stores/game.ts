import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useGameStore = defineStore('game', () => {
  const players = ref<Player[]>([
    { id: 1, name: 'Player 1', bank: 100, color: 'red', position: 0 },
    { id: 2, name: 'Player 2', bank: 200, color: 'blue', position: 1 },
    { id: 3, name: 'Player 3', bank: 150, color: 'green', position: 2 },
    { id: 4, name: 'Player 4', bank: 1000, color: 'yellow', position: 3 },
  ])

  const lastDiceRoll = ref(0)

  const isLastRollDouble = ref(false)

  function saveDiceRoll(rolls: number[]) {
    lastDiceRoll.value = rolls[0] + rolls[1]
    isLastRollDouble.value = rolls[0] === rolls[1]
  }

  return { lastDiceRoll, isLastRollDouble, saveDiceRoll, players }
})
