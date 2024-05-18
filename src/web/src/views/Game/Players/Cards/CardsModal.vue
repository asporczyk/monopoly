<script setup lang="ts">
import CenteredModal from '@/components/organisms/CenteredModal/CenteredModal.vue'
import { ref } from 'vue'
import Card from '@/views/Game/Players/Cards/Card.vue'
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'
import { useI18n } from 'vue-i18n'

defineEmits(['close'])

const { t } = useI18n()

const cards = ref<Card[]>([
  {
    id: 1,
    name: 'Card 1',
    description: 'Description 1',
    price: 100,
    rent: 10,
    color: 'red',
    isProperty: true,
  },
  {
    id: 2,
    name: 'Card 2',
    description: 'Description 2',
    price: 200,
    rent: 20,
    color: 'blue',
    isProperty: true,
  },
  {
    id: 3,
    name: 'Card 3',
    description: 'Description 3',
    price: 300,
    rent: 30,
    color: 'green',
    isProperty: true,
  },
  {
    id: 4,
    name: 'Card 4',
    description: 'Description 4',
    price: 400,
    rent: 40,
    color: 'yellow',
    isProperty: true,
  },
  {
    id: 5,
    name: 'Card 5',
    description: 'Description 5',
    price: 500,
    rent: 50,
    color: 'purple',
    isProperty: true,
  },
  {
    id: 6,
    name: 'Card 6',
    description: 'Description 6',
    price: 600,
    rent: 60,
    color: 'orange',
    isProperty: true,
  },
  {
    id: 7,
    name: 'Card 7',
    description: 'Description 7',
    price: 700,
    rent: 70,
    color: 'pink',
    isProperty: true,
  },
  {
    id: 8,
    name: 'Card 8',
    description: 'Description 8',
    price: 800,
    rent: 80,
    color: 'brown',
    isProperty: true,
  },
  {
    id: 9,
    name: 'Card 9',
    description: 'Description 9',
    price: 900,
    rent: 90,
    color: 'black',
    isProperty: true,
  },
  {
    id: 10,
    name: 'Card 10',
    description: 'Description 10',
    price: 1000,
    rent: 100,
    color: 'white',
    isProperty: true,
  },
])
</script>
<template>
  <CenteredModal @on-close="$emit('close')">
    <template #title>
      <HeadlineL>
        {{ t('your-cards') }}
      </HeadlineL>
    </template>
    <template #body>
      <div class="d-flex flex-row overflow">
        <Card v-for="card in cards" v-bind:key="card.id" :card="card" />
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
    "your-cards": "Your cards"
  },
  "pl": {
    "your-cards": "Twoje karty"
  }
}
</i18n>
