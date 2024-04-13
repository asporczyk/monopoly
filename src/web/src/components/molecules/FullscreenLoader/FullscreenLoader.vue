<script setup lang="ts">
import ProgressCircular from '@/components/atoms/ProgressCircular/ProgressCircular.vue'

defineProps<{ isLoading: boolean }>()
</script>
<template>
  <v-overlay :model-value="isLoading" class="align-center justify-center">
    <ProgressCircular />
  </v-overlay>
</template>
