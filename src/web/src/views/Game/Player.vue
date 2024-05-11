<script setup lang="ts">
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import { useI18n } from 'vue-i18n'

interface PlayerProps {
  player: Player
}

defineProps<PlayerProps>()

const { t } = useI18n()
</script>
<template>
  <div class="d-flex flex-column align-center">
    <v-card
      :color="player.color"
      width="120px"
      height="120px"
      class="d-flex align-center justify-center rounded"
    >
      <v-avatar
        :image="`https://picsum.photos/80?random=${player.id}`"
        size="100"
        rounded="0"
      />
    </v-card>
    <HeadlineXS>{{ player.name }}</HeadlineXS>
    <TextCaption>{{ t('bank', { amount: player.bank }) }}</TextCaption>
  </div>
</template>
<i18n>
{
  "en": {
    "bank": "Bank: ${amount}"
  },
  "pl": {
    "bank": "Konto: ${amount}"
  }
}
</i18n>
