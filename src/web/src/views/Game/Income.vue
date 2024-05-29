<script setup lang="ts">
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import { useI18n } from 'vue-i18n'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'

const { t } = useI18n()

const gameStore = useGameStore()

const { income } = storeToRefs(gameStore)

const confirm = () => {
  gameStore.clearIncome()
}
</script>
<template>
  <CenteredModal v-model="income">
    <template #title>{{ t('payment') }}</template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <TextBody>{{ t(`payment-details-${income?.type}`) }}</TextBody>
        <TextBody>{{ t('price', { price: income?.amount }) }} </TextBody>
        <TextButton variant="positive" @click="confirm">{{
          t('common.ok')
        }}</TextButton>
      </div>
    </template>
  </CenteredModal>
</template>
<i18n>
{
  "en": {
    "payment": "Payment",
    "payment-details-bonus": "You receive a bonus for passing the start",
    "payment-details-rent": "You receive a payment for rent",
    "price": "In the amount of {price}$"
  },
  "pl": {
    "payment": "Płatność",
    "payment-details-bonus": "Otrzymujesz premię za przejście przez start",
    "payment-details-rent": "Otrzymujesz płatność za czynsz",
    "price": "W wysokości {price}$"
  }
}
</i18n>
