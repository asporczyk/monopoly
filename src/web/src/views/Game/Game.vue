<script setup lang="ts">
import Board from '@/views/Game/Board.vue'
import PlayersWrapper from '@/views/Game/Players/PlayersWrapper.vue'
import GameActions from '@/views/Game/GameActions.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'
import { connection } from '@/api/SignalRConnection'

const gameStore = useGameStore()

const { isActivePlayersTurn } = storeToRefs(gameStore)

connection.on('YourTurn', () => {
  gameStore.setIsActivePlayersTurn(true)
})

connection.on('PlayerMoved', (data) => {
  gameStore.setPlayerPosition(data.id, data.playerPosition)
})

connection.on('CanBuyField', (data) => {
  gameStore.setCanActivePlayerBuyProperty(true, data.name, data.price)
})

connection.on('PlayerGoToJail', (data) => {
  gameStore.setPlayerGoToJail(data.id)
})

// TODO - handle leave jail

connection.on('PayIncomeTax', (data) => {
  gameStore.setPayment('tax', data.incomeTax, data.id)
})

connection.on('Rent', (data) => {
  gameStore.setPayment('rent', data.rent, data.senderId)
  gameStore.setIncome('rent', data.rent, data.recipientId)
})

connection.on('PlayerMovedThroughGo', (data) => {
  gameStore.setIncome('bonus', data.money, data.id)
})

connection.on('PlayerBankrupt', (data) => {
  gameStore.setIsPlayerBankrupt(data.id)
})
</script>
<template>
  <PlayersWrapper>
    <Board />
  </PlayersWrapper>
  <GameActions v-if="isActivePlayersTurn" />
</template>
