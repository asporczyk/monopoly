<script setup lang="ts">
interface DiceIconProps {
  value: number
}

defineProps<DiceIconProps>()
</script>
<template>
  <div>
    <v-icon size="x-large" :icon="`mdi-dice-${value}`" />
  </div>
</template>
