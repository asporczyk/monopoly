<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'

const { t } = useI18n()
</script>
<template>
  <v-app-bar>
    <HeadlineXS>{{ t('app-name') }}</HeadlineXS>
  </v-app-bar>
</template>
