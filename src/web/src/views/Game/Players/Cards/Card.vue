<script setup lang="ts">
import TextBody from '@/components/atoms/Typography/TextBody.vue'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'

interface CardProps {
  card: Card
}

defineProps<CardProps>()
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
        <TextBody>{{ card.description }}</TextBody>
        <TextBody>{{ card.price }}</TextBody>
        <TextBody>{{ card.rent }}</TextBody>
      </div>
    </template>
  </v-card>
</template>
<style scoped lang="scss"></style>
