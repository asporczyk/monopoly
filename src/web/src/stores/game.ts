import { defineStore } from 'pinia'
import { ref } from 'vue'

export const useGameStore = defineStore('game', () => {
  const players = ref<Player[]>([])

  const activePlayerId = ref('')

  const areAllPlayersReady = ref(false)

  const lastDiceRoll = ref(0)

  const isLastRollDouble = ref(false)

  const canActivePlayerRoll = ref(false)

  const canActivePlayerBuyProperty = ref(false)

  const isActivePlayersTurn = ref(false)

  const propertyToBuy = ref<Property | null>(null)

  const payment = ref<Payment | null>(null)

  const income = ref<Income | null>(null)

  const saveDiceRoll = (rolls: number[]) => {
    if (rolls[0] === rolls[1]) {
      if (isLastRollDouble.value) {
        console.log('TODO - go to prison')
        isLastRollDouble.value = false
        return
      }

      lastDiceRoll.value = lastDiceRoll.value + rolls[0] + rolls[1]
      isLastRollDouble.value = true
      return
    }

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

  const setIsActivePlayersTurn = (value: boolean) => {
    isActivePlayersTurn.value = value
    canActivePlayerRoll.value = true
  }

  const setPlayerPosition = (playerId: string, position: number) => {
    players.value.map((player) => {
      if (player.id === playerId) {
        player.position = position
      }
      return player
    })
  }

  const setCanActivePlayerBuyProperty = (
    value: boolean,
    name?: string,
    price?: number,
  ) => {
    canActivePlayerBuyProperty.value = value
    if (value) {
      propertyToBuy.value = { name: name!, price: price! }
    } else {
      propertyToBuy.value = null
    }
  }

  const setCanActivePlayerRoll = (value: boolean) => {
    canActivePlayerRoll.value = value
  }

  const setPlayerGoToJail = (playerId: string) => {
    players.value.map((player) => {
      if (player.id === playerId) {
        player.position = 10
        player.isInJail = true
        player.jailTurns = 3
      }
      return player
    })
  }

  const setPayment = (
    type: 'rent' | 'tax',
    amount: number,
    playerId: string,
  ) => {
    players.value.filter((player) => player.id === playerId)[0].money -= amount
    if (playerId === activePlayerId.value) {
      payment.value = { type, amount }
    }
  }

  const clearPayment = () => {
    payment.value = null
  }

  const setIncome = (
    type: 'rent' | 'bonus',
    amount: number,
    playerId: string,
  ) => {
    players.value.filter((player) => player.id === playerId)[0].money += amount
    if (playerId === activePlayerId.value) {
      income.value = { type, amount }
    }
  }

  const clearIncome = () => {
    income.value = null
  }

  const setIsPlayerBankrupt = (playerId: string) => {
    players.value.map((player) => {
      if (player.id === playerId) {
        player.isBankrupt = true
      }
      return player
    })
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
    isActivePlayersTurn,
    setIsActivePlayersTurn,
    setPlayerPosition,
    canActivePlayerRoll,
    canActivePlayerBuyProperty,
    setCanActivePlayerBuyProperty,
    setCanActivePlayerRoll,
    propertyToBuy,
    setPlayerGoToJail,
    setPayment,
    payment,
    clearPayment,
    income,
    setIncome,
    clearIncome,
    setIsPlayerBankrupt,
  }
})
