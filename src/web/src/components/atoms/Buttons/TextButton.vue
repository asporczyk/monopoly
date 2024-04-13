<script setup lang="ts">
defineProps<{
  fullWidth?: boolean
  variant?: 'primary' | 'secondary' | 'positive' | 'negative'
  loading?: boolean
}>()
</script>
<template>
  <v-btn
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
    class="my-2"
    :variant="variant === 'secondary' ? 'tonal' : 'elevated'"
    :loading="loading"
  >
    <slot />
  </v-btn>
</template>
