<script setup lang="ts">
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useI18n } from 'vue-i18n'
import { ref } from 'vue'
import { useRollDice } from '@/views/Game/Dice/useRollDice'
import DiceIcon from '@/views/Game/Dice/DiceIcon.vue'
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'
import { connection } from '@/api/SignalRConnection'

const { t } = useI18n()
const currentDiceRoll = ref<number[]>([])
const openModal = ref(false)

const gameStore = useGameStore()

const { lastDiceRoll, isLastRollDouble, players } = storeToRefs(gameStore)

const activePlayer = players.value.find((player) => player.isActivePlayer)

const { rollDice } = useRollDice()

const handleRollDice = () => {
  currentDiceRoll.value[0] = rollDice()
  currentDiceRoll.value[1] = rollDice()
  openModal.value = true
  gameStore.saveDiceRoll(currentDiceRoll.value)
}

const movePlayer = () => {
  connection.invoke('MovePlayer', lastDiceRoll.value)
  openModal.value = false
  gameStore.setCanActivePlayerRoll(isLastRollDouble.value)
}

const leaveJail = () => {
  connection.invoke('LeaveJail')
  openModal.value = false
}

const handleNotRolledDoubleInJail = () => {
  gameStore.setCanActivePlayerRoll(false)
  openModal.value = false
}

const handleConfirm = () => {
  if (activePlayer?.isInJail) {
    isLastRollDouble.value ? leaveJail() : handleNotRolledDoubleInJail()
  } else {
    isLastRollDouble.value ? handleRollDice() : movePlayer()
  }
}
</script>
<template>
  <TextButton @click="handleRollDice">{{ t('roll-dice') }}</TextButton>
  <CenteredModal v-model="openModal" class="d-flex flex-row">
    <template #title>{{ t('rolled-numbers') }}</template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <div class="d-flex flex-row">
          <DiceIcon :value="currentDiceRoll[0]" />
          <DiceIcon :value="currentDiceRoll[1]" />
        </div>
        <TextBody
          >{{ currentDiceRoll[0] }} + {{ currentDiceRoll[1] }} =
          {{ currentDiceRoll[0] + currentDiceRoll[1] }}
        </TextBody>
        <TextBody v-if="isLastRollDouble">{{ t('double') }}</TextBody>
        <TextButton @click="handleConfirm">{{ t('common.ok') }}</TextButton>
      </div>
    </template>
  </CenteredModal>
</template>
<i18n>
{
  "en": {
    "roll-dice": "Roll dice",
    "rolled-numbers": "Rolled numbers",
    "double": "Double, roll again!"
  },
  "pl": {
    "roll-dice": "Rzuć kostką",
    "rolled-numbers": "Wylosowane liczby",
    "double": "Dublet, rzuć jeszcze raz!"
  }
}
</i18n>
