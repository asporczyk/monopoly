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
const { canActivePlayerRoll, canActivePlayerBuyProperty } =
  storeToRefs(gameStore)

const endTurn = () => {
  connection.invoke('EndTurn')
  gameStore.setCanActivePlayerBuyProperty(false)
  gameStore.setIsActivePlayersTurn(false)
}
</script>
<template>
  <div
    class="d-flex flex-column align-center position-absolute border rounded-xl semi-transparent-bg"
  >
    <HeadlineM>{{ t('select-what-you-want-to-do') }}</HeadlineM>
    <Dice v-if="canActivePlayerRoll" />
    <Property v-if="canActivePlayerBuyProperty" />
    <TextButton @click="endTurn">{{ t('end-turn') }}</TextButton>
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
    "end-turn": "End turn"
  },
  "pl": {
    "select-what-you-want-to-do": "Wybierz co chcesz zrobić",
    "end-turn": "Zakończ turę"
  }
}
</i18n>
