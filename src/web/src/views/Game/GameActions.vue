<script setup lang="ts">
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'
import Dice from '@/views/Game/Dice/Dice.vue'
import { useI18n } from 'vue-i18n'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'
import Property from '@/views/Game/Property.vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { connection } from '@/api/SignalRConnection'

const { t } = useI18n()

const gameStore = useGameStore()
const { canActivePlayerRoll, canActivePlayerBuyProperty, players } =
  storeToRefs(gameStore)

const activePlayer = players.value.find((player) => player.isActivePlayer)

const endTurnInJail = () => {
  gameStore.decreseActivePlayersJailTurns()

  if (activePlayer?.jailTurns === 0) {
    connection.invoke('LeaveJail')
  }
}

const payBail = () => {
  connection.invoke('PayBail')
  gameStore.setPayment('bail', 50, activePlayer?.id)
}

const endTurn = () => {
  if (activePlayer?.isInJail) {
    endTurnInJail()
  }

  connection.invoke('EndTurn')
  gameStore.setCanActivePlayerBuyProperty(false)
  gameStore.setIsActivePlayersTurn(false)
}
</script>
<template>
  <div
    class="d-flex flex-column align-center position-absolute border rounded-xl semi-transparent-bg"
  >
    <HeadlineM>{{
      activePlayer?.isInJail ? t('in-jail') : t('select-what-you-want-to-do')
    }}</HeadlineM>
    <Dice v-if="canActivePlayerRoll" />
    <Property v-if="canActivePlayerBuyProperty" />
    <TextButton v-if="activePlayer?.isInJail" @click="payBail">{{
      t('pay-bail')
    }}</TextButton>
    <TextButton @click="endTurn">{{
      activePlayer?.isInJail
        ? t('end-turn-jail', { turnsLeft: activePlayer.jailTurns })
        : t('end-turn')
    }}</TextButton>
  </div>
</template>
<style lang="scss">
.semi-transparent-bg {
  background-color: rgba(0, 0, 0, 0.45);
  color: white;
}
</style>
<i18n>
{
  "en": {
    "select-what-you-want-to-do": "Select what you want to do",
    "end-turn": "End turn",
    "in-jail": "You are in jail",
    "end-turn-jail": "End turn ({turnsLeft} turns)",
    "pay-bail": "Pay bail"
  },
  "pl": {
    "select-what-you-want-to-do": "Wybierz co chcesz zrobić",
    "end-turn": "Zakończ turę",
    "in-jail": "Jesteś w więzieniu",
    "end-turn-jail": "Zakończ turę ({turnsLeft} tury)",
    "pay-bail": "Zapłać kaucję"
  }
}
</i18n>
