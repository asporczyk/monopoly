<script setup lang="ts">
import { useI18n } from 'vue-i18n'

const { t } = useI18n()
</script>
<template>
  <div>
    <h1>{{ t('app-name') }}</h1>
    <h2>{{ t('game') }}</h2>
  </div>
</template>
<i18n>
{
  "en": {
    "game": "Game"
  },
  "pl": {
    "game": "Gra"
  }
}
</i18n>
