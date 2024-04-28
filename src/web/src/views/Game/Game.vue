<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import Dice from '@/views/Game/Dice/Dice.vue'
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'

const { t } = useI18n()
</script>
<template>
  <div class="d-flex flex-column align-center">
    <HeadlineM>{{ t('select-what-you-want-to-do') }}</HeadlineM>
    <Dice />
  </div>
</template>
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
