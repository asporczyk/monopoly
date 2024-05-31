<script setup lang="ts">
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import { useI18n } from 'vue-i18n'

interface CardProps {
  card: Card
}

defineProps<CardProps>()

const { t } = useI18n()
</script>
<template>
  <v-card
    height="300px"
    width="200px"
    color="white"
    border="lg"
    class="inline position-relative mx-2 flex-shrink-0"
  >
    <template #title>
      <HeadlineXS :class="`bg-${card.color}`">{{ card.name }}</HeadlineXS>
    </template>
    <template #text>
      <div>
        <TextBody>{{ t('price', { price: card.price }) }}</TextBody>
      </div>
    </template>
  </v-card>
</template>
<i18n>
{
  "en": {
    "price": "Price: {price}$"
  },
  "pl": {
    "price": "Cena: {price}$"
  }
}
</i18n>
