<script setup lang="ts">
import HeadlineXS from '@/components/atoms/Typography/HeadlineXS.vue'
import TextCaption from '@/components/atoms/Typography/TextCaption.vue'
import { useI18n } from 'vue-i18n'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { ref } from 'vue'
import CardsModal from '@/views/Game/Players/Cards/CardsModal.vue'
import TextBody from '@/components/atoms/Typography/TextBody.vue'

interface PlayerProps {
  player: Player
  isInLobby?: boolean
}

defineProps<PlayerProps>()

const { t } = useI18n()

const openCardsModal = ref(false)
</script>
<template>
  <div class="d-flex flex-column align-center">
    <v-card
      :color="player?.color ?? 'white'"
      width="120px"
      height="120px"
      class="d-flex align-center justify-center rounded"
    >
      <v-avatar
        v-if="player"
        :image="`https://picsum.photos/80?random=${player?.id}`"
        size="100"
        rounded="0"
      />
      <TextBody v-else>{{ t('empty') }}</TextBody>
    </v-card>
    <div class="d-flex flex-row align-center">
      <HeadlineXS>{{ player?.nickname }}</HeadlineXS>
      <v-icon
        v-if="isInLobby && player?.isReady"
        color="green"
        icon="mdi-check"
      />
    </div>
    <div v-if="!isInLobby && !player.isBankrupt">
      <TextCaption>{{ t('bank', { amount: player?.money }) }}</TextCaption>
      <TextButton
        v-if="player?.isActivePlayer"
        @click="openCardsModal = true"
        >{{ t('cards') }}</TextButton
      >
    </div>
    <TextCaption v-else-if="player.isBankrupt">{{ t('bankrupt') }}</TextCaption>
  </div>
  <CardsModal v-model="openCardsModal" @close="openCardsModal = false" />
</template>
<i18n>
{
  "en": {
    "bank": "Bank: ${amount}",
    "cards": "Cards",
    "ready": "Ready",
    "empty": "Empty",
    "bankrupt": "Bankrupt"
  },
  "pl": {
    "bank": "Konto: ${amount}",
    "cards": "Karty",
    "ready": "Gotowy",
    "empty": "Puste",
    "bankrupt": "Bankrut"
  }
}
</i18n>
