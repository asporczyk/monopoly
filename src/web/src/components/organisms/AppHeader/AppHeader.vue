<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import TextButtonWithIcon from '@/components/atoms/Buttons/TextButtonWithIcon.vue'
import { connection } from '@/api/SignalRConnection'
import router from '@/router'

const { t } = useI18n()

const restart = () => {
  connection.invoke('ResetGame')
}

connection.on('GameReset', () => {
  connection.stop()
  router.replace('/')
})
</script>
<template>
  <v-app-bar>
    <HeadlineXS>{{ t('app-name') }}</HeadlineXS>
    <template #append>
      <TextButtonWithIcon icon="mdi-reload" @click="restart">{{
        t('restart')
      }}</TextButtonWithIcon>
    </template>
  </v-app-bar>
</template>
<i18n>
{
  "en": {
    "restart": "Restart game"
  },
  "pl": {
    "restart": "Zrestartuj grę"
  }
}
</i18n>
