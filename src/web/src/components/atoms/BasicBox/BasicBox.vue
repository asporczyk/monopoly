<script setup lang="ts">
defineProps<{ height?: string; width?: string; maxWidth?: string }>()
</script>
<template>
  <v-sheet
    border
    rounded="xl"
    :elevation="15"
    :height="height ?? 'auto'"
    :width="width ?? 'auto'"
    :max-width="maxWidth"
  >
    <slot />
  </v-sheet>
</template>
