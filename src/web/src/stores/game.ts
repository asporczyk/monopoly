import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useGameStore = defineStore('game', () => {
  const players = ref<Player[]>([])

  const activePlayerId = ref('')

  const areAllPlayersReady = ref(false)

  const lastDiceRoll = ref(0)

  const isLastRollDouble = ref(false)

  const saveDiceRoll = (rolls: number[]) => {
    lastDiceRoll.value = rolls[0] + rolls[1]
    isLastRollDouble.value = rolls[0] === rolls[1]
  }

  const setActivePlayerId = (id: string) => {
    activePlayerId.value = id
  }

  const setPlayers = (newPlayers: Player[]) => {
    newPlayers.forEach((player, index) => {
      if (player.id === activePlayerId.value) {
        player.isActivePlayer = true
      }

      switch (index) {
        case 0:
          player.color = 'red'
          break
        case 1:
          player.color = 'blue'
          break
        case 2:
          player.color = 'green'
          break
        case 3:
          player.color = 'yellow'
          break
      }
    })
    players.value = newPlayers
  }

  const setPlayerReady = (playerId: string) => {
    players.value.map((player) => {
      if (player.id === playerId) {
        player.isReady = true
      }
      return player
    })

    if (players.value.every((player) => player.isReady)) {
      areAllPlayersReady.value = true
    }
  }

  const setAreAllPlayersReady = (value: boolean) => {
    areAllPlayersReady.value = value
  }

  return {
    lastDiceRoll,
    isLastRollDouble,
    saveDiceRoll,
    players,
    setPlayers,
    setPlayerReady,
    areAllPlayersReady,
    setAreAllPlayersReady,
    setActivePlayerId,
  }
})
