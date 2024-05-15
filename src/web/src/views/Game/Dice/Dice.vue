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

const { t } = useI18n()
const currentDiceRoll = ref<number[]>([])
const openModal = ref(false)

const gameStore = useGameStore()

const { lastDiceRoll } = storeToRefs(gameStore)

const { rollDice } = useRollDice()

const handleRollDice = () => {
  currentDiceRoll.value[0] = rollDice()
  currentDiceRoll.value[1] = rollDice()
  openModal.value = true
  gameStore.saveDiceRoll(currentDiceRoll.value)
}
</script>
<template>
  <TextButton @click="handleRollDice">{{ t('roll-dice') }}</TextButton>
  <CenteredModal v-model="openModal" class="d-flex flex-row">
    <template #title> Wylosowane liczby </template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <div class="d-flex flex-row">
          <DiceIcon :value="currentDiceRoll[0]" />
          <DiceIcon :value="currentDiceRoll[1]" />
        </div>
        <TextBody
          >{{ currentDiceRoll[0] }} + {{ currentDiceRoll[1] }} =
          {{ lastDiceRoll }}
        </TextBody>
        <TextButton @click="openModal = false">{{ t('common.ok') }}</TextButton>
      </div>
    </template>
  </CenteredModal>
</template>
<i18n>
{
  "en": {
    "roll-dice": "Roll dice"
  },
  "pl": {
    "roll-dice": "Rzuć kostką"
  }
}
</i18n>
