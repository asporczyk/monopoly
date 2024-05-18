<script setup lang="ts">
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import { useI18n } from 'vue-i18n'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { ref } from 'vue'
import CardsModal from '@/views/Game/Players/Cards/CardsModal.vue'

interface PlayerProps {
  player: Player
}

defineProps<PlayerProps>()

const { t } = useI18n()

const openCardsModal = ref(false)
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
    <TextButton v-if="player.isActivePlayer" @click="openCardsModal = true">{{
      t('cards')
    }}</TextButton>
  </div>
  <CardsModal v-model="openCardsModal" @close="openCardsModal = false" />
</template>
<i18n>
{
  "en": {
    "bank": "Bank: ${amount}",
    "cards": "Cards"
  },
  "pl": {
    "bank": "Konto: ${amount}",
    "cards": "Karty"
  }
}
</i18n>
