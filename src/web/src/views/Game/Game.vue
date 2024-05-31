<script setup lang="ts">
import Board from '@/views/Game/Board.vue'
import PlayersWrapper from '@/views/Game/Players/PlayersWrapper.vue'
import GameActions from '@/views/Game/GameActions.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'
import { connection } from '@/api/SignalRConnection'
import Payment from '@/views/Game/Payment.vue'
import Income from '@/views/Game/Income.vue'
import { ref } from 'vue'
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useI18n } from 'vue-i18n'

const winner = ref<Player | null>(null)

const { t } = useI18n()

const gameStore = useGameStore()

const { isActivePlayersTurn, players } = storeToRefs(gameStore)

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

connection.on('PlayerLeftJail', (data) => {
  gameStore.setPlayerLeftJail(data.id)
})

connection.on('PayIncomeTax', (data) => {
  gameStore.setPayment('tax', data.incomeTax, data.id)
})

connection.on('Rent', (data) => {
  gameStore.setPayment('rent', data.rent, data.senderId)
  gameStore.setIncome('rent', data.rent, data.recipientId)
})

connection.on('PlayerMovedThroughGo', (data) => {
  gameStore.setIncome('bonus', 200, data.id)
})

connection.on('PlayerBankrupt', (data) => {
  gameStore.setIsPlayerBankrupt(data.id)
})

connection.on('Winner', (data) => {
  winner.value = players.value.filter(
    (player) => player.id === data.winnerId,
  )[0]
})

connection.on('FieldBought', (data) => {
  gameStore.setPlayerProperties(data.id, {
    name: data.name,
    price: data.price,
  })
  gameStore.setCanActivePlayerBuyProperty(false)
})
</script>
<template>
  <PlayersWrapper>
    <Board />
  </PlayersWrapper>
  <GameActions v-if="isActivePlayersTurn" />
  <Payment />
  <Income />
  <CenteredModal v-model="winner">
    <template #title>{{ t('winner') }}</template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <TextBody>{{ winner?.nickname }}</TextBody>
        <TextBody>{{ t('won') }}</TextBody>
      </div>
    </template>
  </CenteredModal>
</template>
<i18n>
{
  "en": {
    "winner": "Winner",
    "won": "won"
  },
  "pl": {
    "winner": "Zwycięzca",
    "won": "wygrał"
  }
}
</i18n>
