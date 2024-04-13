<script setup lang="ts">
import { useDisplay } from 'vuetify'

defineProps<{
  fullWidth?: boolean
  variant?: 'primary' | 'secondary' | 'positive' | 'negative'
  icon: string
  forceText?: boolean
}>()

const { mobile } = useDisplay()
</script>
<template>
  <v-btn
    v-if="!mobile || forceText"
    :max-width="!fullWidth ? '300px' : ''"
    :width="fullWidth ? '100%' : ''"
    rounded="lg"
    :color="
      variant === 'primary'
        ? 'primary'
        : variant === 'positive'
          ? 'green'
          : variant === 'negative'
            ? 'red'
            : ''
    "
    :prepend-icon="icon"
    class="my-2"
    :variant="variant === 'secondary' ? 'tonal' : 'elevated'"
  >
    <slot />
  </v-btn>
  <v-btn
    v-else
    :icon="icon"
    rounded="lg"
    density="comfortable"
    :color="
      variant === 'primary'
        ? 'primary'
        : variant === 'positive'
          ? 'green'
          : variant === 'negative'
            ? 'red'
            : ''
    "
    :variant="variant === 'secondary' ? 'tonal' : 'elevated'"
  />
</template>
