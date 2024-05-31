<script setup lang="ts">
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import Card from '@/views/Game/Players/Cards/Card.vue'
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'
import { useI18n } from 'vue-i18n'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'

defineEmits(['close'])

const { t } = useI18n()

const gameStore = useGameStore()

const { activePlayerProperties } = storeToRefs(gameStore)
</script>
<template>
  <CenteredModal>
    <template #title>
      <HeadlineL>
        {{ t('your-cards') }}
      </HeadlineL>
    </template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <div
          v-if="activePlayerProperties.length"
          class="d-flex flex-row overflow"
        >
          <Card
            v-for="card in activePlayerProperties"
            v-bind:key="card.name"
            :card="card"
          />
        </div>
        <HeadlineM v-else>{{ t('empty') }}</HeadlineM>
        <TextButton @click="$emit('close')">{{ t('close') }}</TextButton>
      </div>
    </template>
  </CenteredModal>
</template>
<style scoped lang="scss">
.overflow {
  width: 700px;
  height: 300px;
  overflow-x: scroll;
  flex-wrap: nowrap;
}
</style>
<i18n>
{
  "en": {
    "your-cards": "Your cards",
    "close": "Close",
    "empty": "Empty"
  },
  "pl": {
    "your-cards": "Twoje karty",
    "close": "Zamknij",
    "empty": "Pusto"
  }
}
</i18n>
