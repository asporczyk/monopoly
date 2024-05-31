<script setup lang="ts">
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import { useI18n } from 'vue-i18n'
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'

const { t } = useI18n()

const gameStore = useGameStore()

const { payment } = storeToRefs(gameStore)

const confirm = () => {
  gameStore.clearPayment()
}
</script>
<template>
  <CenteredModal v-model="payment">
    <template #title>{{ t('payment') }}</template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <TextBody>{{ t(`payment-details-${payment?.type}`) }}</TextBody>
        <TextBody>{{ t('price', { price: payment?.amount }) }} </TextBody>
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
    "payment-details-tax": "Income tax has been charged",
    "payment-details-rent": "Rent has been charged",
    "payment-details-bail": "Bail has been paid",
    "price": "In the amount of {price}$"
  },
  "pl": {
    "payment": "Płatność",
    "payment-details-tax": "Został naliczony podatek",
    "payment-details-rent": "Został naliczony czynsz",
    "payment-details-bail": "Została zapłacona kaucja",
    "price": "W wysokości {price}$"
  }
}
</i18n>
