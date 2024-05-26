<script setup lang="ts">
import { useI18n } from 'vue-i18n'
import HeadlineM from '@/components/atoms/Typography/HeadlineM.vue'
import TextButton from '@/components/atoms/Buttons/TextButton.vue'
import { ref } from 'vue'
import { connection } from '@/api/SignalRConnection'
import router from '@/router'
import { useGameStore } from '@/stores/game'

const { t } = useI18n()

const userName = ref('')

const gameStore = useGameStore()

const submit = () => {
  connection
    .start()
    .then(() => {
      connection.invoke('JoinGame', userName.value)
    })
    .then(() => {
      router.push('lobby')
    })
}

connection.on('ReceiveConnectionId', (data) => {
  gameStore.setActivePlayerId(data)
})

connection.on('PlayerJoined', (data) => {
  gameStore.setPlayers(data.players)
})
</script>
<template>
  <div>
    <HeadlineM>{{ t('join-game') }}</HeadlineM>
    <v-form
      @submit.prevent="submit"
      class="w-100 ma-5 d-flex flex-column align-center justify-center"
    >
      <v-text-field v-model="userName" :label="t('user-name')" class="w-100" />
      <TextButton type="submit">{{ t('join') }}</TextButton>
    </v-form>
  </div>
</template>
<i18n>
{
  "en": {
    "join-game": "Join game",
    "user-name": "User name (optional)",
    "join": "Join"
  },
  "pl": {
    "join-game": "Dołącz do gry",
    "user-name": "Nazwa użytkownika (opcjonalnie)",
    "join": "Dołącz"
  }
}
</i18n>
