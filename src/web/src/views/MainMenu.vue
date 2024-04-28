<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import HeadlineL from '@/components/atoms/Typography/HeadlineL.vue'
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import router from '@/router'

const { t } = useI18n()

const goToGame = () => {
  router.push('game')
}
</script>
<template>
  <div>
    <HeadlineL>{{ t('app-name') }}</HeadlineL>
    <HeadlineM>{{ t('game') }}</HeadlineM>
    <TextButton @click="goToGame">{{ t('start') }}</TextButton>
  </div>
</template>
<i18n>
{
  "en": {
    "game": "Game",
    "start": "Start"
  },
  "pl": {
    "game": "Gra",
    "start": "Start"
  }
}
</i18n>
