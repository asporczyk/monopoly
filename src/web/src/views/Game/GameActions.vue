<script setup lang="ts">
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'
import Dice from '@/views/Game/Dice/Dice.vue'
import { useI18n } from 'vue-i18n'

const { t } = useI18n()
</script>
<template>
  <div
    class="d-flex flex-column align-center position-absolute border rounded-xl semi-transparent-bg"
  >
    <HeadlineM>{{ t('select-what-you-want-to-do') }}</HeadlineM>
    <Dice />
  </div>
</template>
<style lang="scss">
.semi-transparent-bg {
  background-color: rgba(0, 0, 0, 0.45);
  color: white;
}
</style>
<i18n>
{
  "en": {
    "select-what-you-want-to-do": "Select what you want to do"
  },
  "pl": {
    "select-what-you-want-to-do": "Wybierz co chcesz zrobić"
  }
}
</i18n>
