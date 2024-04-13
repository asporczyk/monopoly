<script setup lang="ts">
import BasicBox from '@/components/atoms/BasicBox/BasicBox.vue'

defineProps<{ height?: string; width?: string; maxWidth?: string }>()
</script>
<template>
  <div class="fill-height d-flex">
    <BasicBox
      class="mx-auto my-auto d-flex flex-column px-10 py-5"
      :height="height ?? 'auto'"
      :width="width ?? 'auto'"
      :max-width="maxWidth"
    >
      <slot />
    </BasicBox>
  </div>
</template>
