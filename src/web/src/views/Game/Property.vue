<script setup lang="ts">
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { useI18n } from 'vue-i18n'
import { ref } from 'vue'
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import { useGameStore } from '@/stores/game'
import { storeToRefs } from 'pinia'
import TextBody from '@/components/atoms/Typography/TextBody.vue'

const { t } = useI18n()

const openModal = ref(false)

const gameStore = useGameStore()

const { propertyToBuy } = storeToRefs(gameStore)

const buyProperty = () => {
  // TODO - buy property
}
</script>
<template>
  <TextButton @click="openModal = true">{{ t('buy-property') }}</TextButton>
  <CenteredModal v-model="openModal" class="d-flex flex-row">
    <template #title>{{ t('buy-property') }}</template>
    <template #body>
      <div class="d-flex flex-column align-center">
        <TextBody>{{ propertyToBuy?.name }}</TextBody>
        <TextBody>{{ t('price', { price: propertyToBuy?.price }) }}</TextBody>
        <TextButton variant="negative" @click="openModal = false">{{
          t('common.cancel')
        }}</TextButton>
        <TextButton variant="positive" @click="buyProperty">{{
          t('buy')
        }}</TextButton>
      </div>
    </template>
  </CenteredModal>
</template>
<i18n>
{
  "en": {
    "buy-property": "Buy property",
    "buy": "Buy",
    "price": "For {price}$"
  },
  "pl": {
    "buy-property": "Kup nieruchomość",
    "buy": "Kup",
    "price": "Za {price}$"
  }
}
</i18n>
